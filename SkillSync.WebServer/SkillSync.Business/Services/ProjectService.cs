using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Review;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Freelancer;
using SkillSync.Domain.Exceptions.Order;
using SkillSync.Domain.Exceptions.Project;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;
using SkillSync.Domain.QueryParams;
using System.Linq;

namespace SkillSync.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserFavoriteProjectRepository _userFavoriteProjectRepository;

        private readonly IServiceProvider _serviceProvider;
        private readonly IFileService _fileService;
        private readonly IUserService _usersService;
        private readonly IMapper _mapper;

        private string GetUploadFileName(string title, string email) => $"{title}-{email}";
        private string GetPictureName(Guid projectId, Guid pictureId) => $"{projectId}-picture{pictureId}";
        private string GetVideoName(Guid projectId) => $"{projectId}-video";
        private string GetDocumentName(Guid projectId, Guid documentId) => $"{projectId}-document{documentId}";

        public ProjectService
        (
            IUsersRepository usersRepository,
            IFreelancerRepository freelancerRepository,
            IProjectRepository projectRepository,
            IUserFavoriteProjectRepository userFavoriteProjectRepository,
            IServiceProvider serviceProvider,
            IFileService fileService,
            IUserService userService,
            IMapper mapper
        )
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _freelancerRepository = freelancerRepository ?? throw new ArgumentNullException(nameof(freelancerRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _userFavoriteProjectRepository = userFavoriteProjectRepository ?? throw new ArgumentNullException(nameof(userFavoriteProjectRepository));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _usersService = userService ?? throw new ArgumentNullException(nameof(userService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddProjectAsync(PostProjectRequest request, string email)
        {
            Freelancer? freelancer = await GetAndValidateFreelancerByUserEmail(email);

            var project = _mapper.Map<Project>(request);

            project.Freelancer = freelancer;
            project.IsPublished = true;
            project.CreatedAt = DateTime.Now;

            await UploadProjectMedia(request.UploadedPictures, request.UploadedVideo, request.UploadedDocuments, project);

            await _projectRepository.AddAsync(project);
        }

        private async Task UploadProjectMedia(IFormFile[] uploadedPictures, IFormFile uploadedVideo, IFormFile[] uploadedDocuments, Project project)
        {
            await UploadPictures(uploadedPictures, project);
            await UploadVideo(uploadedVideo, project);
            await UploadDocuments(uploadedDocuments, project);
        }

        public async Task<Guid> AddProjectOverviewAsync(OverviewStepDto request, string email)
        {
            Freelancer? freelancer = await GetAndValidateFreelancerByUserEmail(email);

            var freelancerProjects = await _projectRepository.GetFreelancerProjects(freelancer.Id);

            if (freelancerProjects.Any(p => p.Title == request.Title))
            {
                throw new ProjectAlreadyExistsException();
            }

            var project = _mapper.Map<Project>(request);

            project.Freelancer = freelancer;
            project.CreatedAt = DateTime.Now;
            project.IsPublished = false;

            var createdProject = await _projectRepository.AddAsync(project);
            return createdProject.Id;
        }

        public async Task<Guid> UpdateProjectOverviewAsync(OverviewStepDto request, Guid projectId, string email)
        {
            var freelancer = await GetAndValidateFreelancerByUserEmail(email);

            Project project = await GetProjectById(projectId);

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            if (!string.IsNullOrEmpty(request.Title) && project.Title != request.Title)
            {
                project.Title = request.Title;
            }
            if (project.SkillId != request.SkillId)
            {
                project.SkillId = request.SkillId;
            }

            await _projectRepository.UpdateAsync(project);
            return projectId;
        }

        private bool CheckIfFreelancerTryToModifyOwnProject(Freelancer? freelancer, Project project)
        {
            if (project.FreelancerId != freelancer.Id)
            {
                throw new FreelancerUnauthorizedException("Freelancer is not authorize to modify other freelancer project");
            }

            return true;
        }

        public async Task<OverviewStepDto> GetProjectOverviewStepAsync(Guid projectId)
        {
            Project project = await GetProjectById(projectId);

            var overviewStepDto = _mapper.Map<OverviewStepDto>(project);

            return overviewStepDto;
        }

        public async Task UpsertPricingStepAsync(UpsertPricingStepDto request, Guid projectId, string email)
        {
            var freelancer = await GetAndValidateFreelancerByUserEmail(email);

            var project = await _projectRepository.GetProjectByIdWithFeatures(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            if (project.Features == null)
            {
                AddProjectFeatures(project, request);
            }
            else
            {
                UpdateProjectFeatures(project, request);
            }

            project.HasPackages = request.HasPackages;
            await _projectRepository.UpdateAsync(project);
        }

        private void AddProjectFeatures(Project project, UpsertPricingStepDto request)
        {
            project.Features = new List<ProjectFeature>();

            foreach (var featureDto in request.Features)
            {
                if (featureDto.BasicSelectedValue != "false" && featureDto.StandardSelectedValue != "false" && featureDto.PremiumSelectedValue != "false")
                {
                    var feature = _mapper.Map<ProjectFeature>(featureDto);
                    project.Features.Add(feature);
                }
            }
        }

        private void UpdateProjectFeatures(Project project, UpsertPricingStepDto request)
        {
            foreach (var feature in project.Features)
            {
                var requestFeature = request.Features.FirstOrDefault(rf => rf.FeatureId == feature.FeatureId);
                if (requestFeature != null)
                {
                    feature.BasicSelectedValue = requestFeature.BasicSelectedValue;
                    feature.StandardSelectedValue = requestFeature.StandardSelectedValue;
                    feature.PremiumSelectedValue = requestFeature.PremiumSelectedValue;
                }
                if (requestFeature != null && feature.BasicSelectedValue == "false" && feature.StandardSelectedValue == "false" && feature.PremiumSelectedValue == "false")
                {
                    project.Features.Remove(feature);
                    request.Features.Remove(requestFeature);
                }
            }

            var newFeatures = request.Features.Where(rf => !project.Features.Any(pf => pf.FeatureId == rf.FeatureId)).ToList();

            foreach (var featureDto in newFeatures)
            {
                var feature = _mapper.Map<ProjectFeature>(featureDto);
                project.Features.Add(feature);
            }
        }

        public async Task<GetPricingStepDto> GetPricingStepAsync(Guid projectId)
        {
            var project = await _projectRepository.GetProjectByIdWithFeatures(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            var features = _mapper.Map<ICollection<GetProjectFeatureDto>>(project.Features);

            var featuresDictionary = features.ToDictionary(f => f.FeatureId);

            var getPricingDto = new GetPricingStepDto
            {
                Features = featuresDictionary,
                HasPackages = project.HasPackages ?? false
            };

            return getPricingDto;
        }

        public async Task UpsertDescriptionAndFaqStepAsync(DescriptionFaqStepDto request, Guid projectId, string email)
        {
            var freelancer = await GetAndValidateFreelancerByUserEmail(email);

            var project = await _projectRepository.GetProjectByIdWithFrequentlyAskedQuestions(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            if (!string.IsNullOrEmpty(request.Description) && project.Description != request.Description)
            {
                project.Description = request.Description;
            }

            if (request.WasAnyQuestionModified)
            {
                var newQuestions = _mapper.Map<ICollection<ProjectFrequentlyAskedQuestion>>(request.FrequentlyAskedQuestions);

                project.FrequentlyAskedQuestions = new List<ProjectFrequentlyAskedQuestion>();

                foreach (var question in newQuestions)
                {
                    project.FrequentlyAskedQuestions.Add(question);
                }
            }

            await _projectRepository.UpdateAsync(project);
        }

        public async Task<DescriptionFaqStepDto> GetProjectDescriptionAndFaqStepAsync(Guid projectId)
        {
            var project = await _projectRepository.GetProjectByIdWithFrequentlyAskedQuestions(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            var descriptionFaqStepDto = _mapper.Map<DescriptionFaqStepDto>(project);

            return descriptionFaqStepDto;
        }

        public async Task UpsertProjectGalleryStepAsync(UpsertProjectGalleryStepDto request, Guid projectId, string email)
        {
            var freelancer = await GetAndValidateFreelancerByUserEmail(email);

            var project = await _projectRepository.GetProjectByIdWithMedia(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            if (request.UnModifiedMediaUrls != null)
            {
                var picturesToBeDeleted = project.Pictures?.Where(p => !request.UnModifiedMediaUrls.Any(url => url.Contains(p.Name))).ToList();
                if (picturesToBeDeleted != null)
                {
                    foreach (var picture in picturesToBeDeleted)
                    {
                        _fileService.DeleteProjectPicture(picture.Name);
                        project.Pictures.Remove(picture);
                    }
                }
                if (project.Video != null && !request.UnModifiedMediaUrls.Any(um => um.Contains(project.Video.Name)))
                {
                    _fileService.DeleteProjectVideo(project.Video.Name);
                    project.Video = null;
                }
                var documentsToBeDeleted = project.Documents?.Where(d => !request.UnModifiedMediaUrls.Any(um => um.Contains(d.Name))).ToList();
                if (documentsToBeDeleted != null)
                {
                    foreach (var document in documentsToBeDeleted)
                    {
                        _fileService.DeleteProjectDocument(document.Name);
                        project.Documents.Remove(document);
                    }
                }
            }

            await UploadProjectMedia(request.UploadedPictures, request.UploadedVideo, request.UploadedDocuments, project);

            await _projectRepository.UpdateAsync(project);
        }

        public async Task<GetProjectGalleryStepDto> GetProjectGalleryStepAsync(Guid projectId)
        {
            var project = await _projectRepository.GetProjectByIdWithMedia(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            var projectGalleryStepDto = new GetProjectGalleryStepDto
            {
                Pictures = GetProjectPicturesFromBlobStorage(project),
                Video = GetProjectVideoFromBlobStorage(project),
                Documents = GetProjectDocumentsFromBlobStorage(project)
            };

            return projectGalleryStepDto;
        }

        public async Task ModifyProjectPublishStatusAsync(Guid projectId, bool newStatus, string email)
        {
            var freelancer = await GetAndValidateFreelancerByUserEmail(email);

            Project project = await GetProjectById(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            project.IsPublished = newStatus;

            await _projectRepository.UpdateAsync(project);
        }

        public async Task<bool> GetProjectPublishStatusAsync(Guid projectId)
        {
            Project project = await GetProjectById(projectId);

            return project.IsPublished;
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            var project = await _projectRepository.GetProjectById(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            return project;
        }

        public async Task<ProjectDto> GetProjectAllDetailsByIdAsync(Guid projectId)
        {
            var project = await _projectRepository.GetProjectAllDetailsById(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            foreach (var review in project.Reviews)
            {
                review.Reviewer.ProfilePicture = await _usersService.GetProfilePictureAsync(review.Reviewer);
            }
            project.Reviews = project.Reviews.OrderByDescending(r => r.ReviewAt).ToList();

            var projectDto = _mapper.Map<ProjectDto>(project);

            if (!projectDto.HasPackages)
            {
                projectDto.Features.RemoveAll(f => f.BasicSelectedValue == "false");
            }
            else
            {
                projectDto.Features.RemoveAll(f => f.BasicSelectedValue == "false" && f.StandardSelectedValue == "false" && f.PremiumSelectedValue == "false");
            }

            projectDto.Freelancer.ProfilePicture = await _usersService.GetProfilePictureAsync(project.Freelancer.User);
            projectDto.Pictures = GetProjectPicturesFromBlobStorage(project);
            projectDto.Video = GetProjectVideoFromBlobStorage(project);
            projectDto.Documents = GetProjectDocumentsFromBlobStorage(project);

            return projectDto;
        }

        public async Task<List<GetProjectPreviewDto>> GetAllProjectsPreviewAsync()
        {
            var projects = await _projectRepository.GetAllProjectsForPreview();

            var projectsPreview = new List<GetProjectPreviewDto>();
            await MapProjectPreviewDto(projects, projectsPreview, null);

            return projectsPreview;
        }

        public async Task<ProjectPreviewDto> GetProjectsPreviewBySubcategoryId(Guid subcategoryId, string userWhoMadeRequestEmail, ProjectQueryParams queryParams)
        {
            User userWhoMadeRequest = null;
            if (userWhoMadeRequestEmail != null)
            {
                userWhoMadeRequest = await _usersService.GetUserByEmailAsync(userWhoMadeRequestEmail);
            }

            var projects = await _projectRepository.GetProjectProjectsForPreviewBySubcategoryId(subcategoryId);
            List<GetProjectPreviewDto> projectsPreview = await Filter(queryParams, userWhoMadeRequest, projects);
            int totalProjectsCount = AddPagination(queryParams, projects, ref projectsPreview);

            return new ProjectPreviewDto
            {
                Projects = projectsPreview,
                TotalProjectsCount = totalProjectsCount
            };
        }

        private static int AddPagination(ProjectQueryParams queryParams, List<Project> projects, ref List<GetProjectPreviewDto> projectsPreview)
        {
            int totalProjectsCount = projects.Count;
            if (queryParams.PageNumber != null && queryParams.PageSize != null)
            {
                int start = queryParams.PageNumber.Value * queryParams.PageSize.Value;
                int end = queryParams.PageNumber.Value * queryParams.PageSize.Value + queryParams.PageSize.Value;

                totalProjectsCount = projectsPreview.Count;
                projectsPreview = projectsPreview.Skip(start).Take(end - start).ToList();
            }

            return totalProjectsCount;
        }

        private async Task<List<GetProjectPreviewDto>> Filter(ProjectQueryParams queryParams, User userWhoMadeRequest, List<Project> projects)
        {
            FilterProjects(projects, queryParams.Filters);

            var projectsPreview = new List<GetProjectPreviewDto>();
            await MapProjectPreviewDto(projects, projectsPreview, userWhoMadeRequest);

            projectsPreview = FilterByRating(projectsPreview, queryParams.Filters);
            return projectsPreview;
        }

        private void FilterProjects(List<Project> projects, FilterProjectQueryParams queryParams)
        {
            if (queryParams != null)
            {
                if (queryParams.CountryCodes != null)
                {
                    var projectsToRemove = projects.Where(p => !queryParams.CountryCodes.Contains(p.Freelancer.User.CountryCode)).ToList();

                    RemoveProjects(projects, projectsToRemove);
                }

                if (queryParams.FeaturesIds != null)
                {
                    var projectsToRemove = projects.Where(p => !p.Features.Any(f => queryParams.FeaturesIds.Contains(f.FeatureId))).ToList();

                    RemoveProjects(projects, projectsToRemove);
                }

                if (queryParams.MinPrice != null && queryParams.MaxPrice != null)
                {
                    int priceBasicValue;
                    int priceStandardValue;
                    int pricePremiumValue;

                    var projectsToRemove = new List<Project>();

                    foreach (var filteredProject in projects)
                    {
                        var priceFeature = filteredProject.Features.FirstOrDefault(f => f.Feature.Name == "Price");
                        if (priceFeature != null)
                        {
                            if (filteredProject.HasPackages.HasValue && filteredProject.HasPackages.Value)
                            {
                                parsePriceFeatureValues(out priceBasicValue, out priceStandardValue, out pricePremiumValue, priceFeature);

                                int minPrice = Math.Min(priceBasicValue, Math.Min(priceStandardValue, pricePremiumValue));
                                int maxPrice = Math.Max(priceBasicValue, Math.Max(priceStandardValue, pricePremiumValue));

                                if (minPrice < queryParams.MinPrice || maxPrice > queryParams.MaxPrice)
                                {
                                    projectsToRemove.Add(filteredProject);
                                }
                            }
                            else if (filteredProject.HasPackages.HasValue && !filteredProject.HasPackages.Value)
                            {
                                int.TryParse(priceFeature.BasicSelectedValue, out priceBasicValue);

                                if (priceBasicValue < queryParams.MinPrice || priceBasicValue > queryParams.MaxPrice)
                                {
                                    projectsToRemove.Add(filteredProject);
                                }
                            }
                        }
                    }

                    RemoveProjects(projects, projectsToRemove);
                }

                if (queryParams.MaxDays != null)
                {
                    int deliveryBasicValue;
                    int deliveryStandardValue;
                    int deliveryPremiumBasicValue;

                    var projectsToRemove = new List<Project>();

                    foreach (var filteredProject in projects)
                    {
                        var deliveryFeature = filteredProject.Features.FirstOrDefault(f => f.Feature.Name == "Delivery time");

                        if (deliveryFeature != null)
                        {
                            if (filteredProject.HasPackages.HasValue && filteredProject.HasPackages.Value)
                            {
                                int.TryParse(deliveryFeature.BasicSelectedValue, out deliveryBasicValue);
                                int.TryParse(deliveryFeature.StandardSelectedValue, out deliveryStandardValue);
                                int.TryParse(deliveryFeature.PremiumSelectedValue, out deliveryPremiumBasicValue);

                                if (deliveryBasicValue >= queryParams.MaxDays || deliveryStandardValue >= queryParams.MaxDays || deliveryPremiumBasicValue >= queryParams.MaxDays)
                                {
                                    projectsToRemove.Add(filteredProject);
                                }
                            }
                            else
                            {
                                int.TryParse(deliveryFeature.BasicSelectedValue, out deliveryBasicValue);

                                if (deliveryBasicValue >= queryParams.MaxDays)
                                {
                                    projectsToRemove.Add(filteredProject);
                                }
                            }
                        }
                    }

                    RemoveProjects(projects, projectsToRemove);
                }
            }
        }

        private static void RemoveProjects(List<Project> projects, List<Project> projectsToRemove)
        {
            foreach (var projectToRemove in projectsToRemove)
            {
                projects.Remove(projectToRemove);
            }
        }

        private static void parsePriceFeatureValues(out int priceBasicValue, out int priceStandardValue, out int pricePremiumValue, ProjectFeature? priceFeature)
        {
            int.TryParse(priceFeature.BasicSelectedValue, out priceBasicValue);
            int.TryParse(priceFeature.StandardSelectedValue, out priceStandardValue);
            int.TryParse(priceFeature.PremiumSelectedValue, out pricePremiumValue);
        }

        private List<GetProjectPreviewDto> FilterByRating(List<GetProjectPreviewDto> projectsPreview, FilterProjectQueryParams queryParams)
        {
            if (queryParams?.Rating != null)
            {
                projectsPreview = projectsPreview.Where(p => p.ReviewStatistics?.AverageRating >= (double)queryParams.Rating && p.ReviewStatistics?.AverageRating < (double)queryParams.Rating + 1).ToList();
            }

            return projectsPreview;
        }

        public async Task<ProjectPreviewDto> GetProjectsPreviewBySkillId(Guid skillId, string userWhoMadeRequestEmail, ProjectQueryParams queryParams)
        {
            User userWhoMadeRequest = null;
            if (userWhoMadeRequestEmail != null)
            {
                userWhoMadeRequest = await _usersService.GetUserByEmailAsync(userWhoMadeRequestEmail);
            }

            var projects = await _projectRepository.GetProjectsForPreviewBySkillId(skillId);

            List<GetProjectPreviewDto> projectsPreview = await Filter(queryParams, userWhoMadeRequest, projects);
            int totalProjectsCount = AddPagination(queryParams, projects, ref projectsPreview);

            return new ProjectPreviewDto
            {
                Projects = projectsPreview,
                TotalProjectsCount = totalProjectsCount
            };
        }

        public async Task MapProjectPreviewDto(List<Project> projects, List<GetProjectPreviewDto> projectsPreview, User userWhoMadeRequest)
        {
            foreach (var project in projects)
            {
                List<string> projectPictures = GetProjectPicturesFromBlobStorage(project);

                var projectPreview = _mapper.Map<GetProjectPreviewDto>(project);

                if (project.Reviews?.Count > 0)
                {
                    var projectReviewAverage = Math.Round(project.Reviews.Average(r => r.Stars), 1, MidpointRounding.AwayFromZero);

                    projectPreview.ReviewStatistics = new ReviewStatisticsDto
                    {
                        AverageRating = projectReviewAverage,
                        TotalReviews = project.Reviews.Count
                    };
                }

                projectPreview.Pictures = projectPictures;

                if (project.Video != null)
                {
                    projectPreview.Video = _fileService.GetProjectVideo(project.Video.Name);
                }

                int price = -1;
                var priceFeature = project.Features.FirstOrDefault(f => f.Feature.Name == "Price");
                if (priceFeature != null)
                {
                    if (project.HasPackages.Value)
                    {
                        int priceBasicValue;
                        int priceStandardValue;
                        int pricePremiumValue;

                        parsePriceFeatureValues(out priceBasicValue, out priceStandardValue, out pricePremiumValue, priceFeature);

                        price = Math.Min(priceBasicValue, Math.Min(priceStandardValue, pricePremiumValue));
                    }
                    else
                    {
                        price = int.Parse(priceFeature.BasicSelectedValue);
                    }
                }
                projectPreview.Price = price;

                projectPreview.FreelancerProfilePicture = await _usersService.GetProfilePictureAsync(project.Freelancer.User);
                projectPreview.FreelancerName = $"{project.Freelancer.User.FirstName} {project.Freelancer.User.LastName}";

                if (userWhoMadeRequest != null)
                {
                    var favoriteProject = await _userFavoriteProjectRepository.FindByCondition(uf => uf.UserId == userWhoMadeRequest.Id && uf.ProjectId == project.Id);
                    var isFavoriteProject = favoriteProject.FirstOrDefault() != null ? true : false;
                    projectPreview.IsUserWhoMadeRequestFavorite = isFavoriteProject;
                }

                projectsPreview.Add(projectPreview);
            }
        }

        public string GetProjectPictureFromBlobStorage(string pictureName)
        {
            return _fileService.GetProjectImage(pictureName);
        }

        public List<string> GetProjectPicturesFromBlobStorage(Project project)
        {
            var projectPictures = new List<string>();
            if (project.Pictures != null)
            {
                foreach (var picture in project.Pictures)
                {
                    var pictureUrl = _fileService.GetProjectImage(picture.Name);
                    projectPictures.Add(pictureUrl);
                }
            }

            return projectPictures;
        }

        public string GetProjectVideoFromBlobStorage(Project project)
        {
            string video = null;
            if (project.Video != null)
            {
                video = _fileService.GetProjectVideo(project.Video.Name);
            }

            return video;
        }

        public List<string> GetProjectDocumentsFromBlobStorage(Project project)
        {
            var projectDocuments = new List<string>();
            if (project.Documents != null)
            {
                foreach (var document in project.Documents)
                {
                    var documentUrl = _fileService.GetProjectDocument(document.Name);
                    projectDocuments.Add(documentUrl);
                }
            }

            return projectDocuments;
        }

        private async Task UploadDocuments(IFormFile[] uploadedDocuments, Project project)
        {
            if (uploadedDocuments == null)
            {
                return;
            }

            project.Documents = new List<ProjectDocument>();
            for (int i = 0; i < uploadedDocuments.Length; i++)
            {
                var documentName = GetDocumentName(project.Id, Guid.NewGuid());
                var document = new UploadFileDto
                {
                    ContentType = uploadedDocuments[i].ContentType,
                    Name = documentName,
                    File = uploadedDocuments[i]
                };

                await _fileService.UploadDocumentAsync(document);
                project.Documents.Add(new ProjectDocument
                {
                    Name = documentName
                });
            }
        }

        private async Task UploadVideo(IFormFile uploadedVideo, Project project)
        {
            if (uploadedVideo == null)
            {
                return;
            }

            if (uploadedVideo != null)
            {
                var videoName = GetVideoName(project.Id);
                var video = new UploadFileDto
                {
                    ContentType = uploadedVideo.ContentType,
                    Name = videoName,
                    File = uploadedVideo
                };

                await _fileService.UploadProjectVideoAsync(video);
                project.Video = new ProjectVideo
                {
                    Name = videoName
                };
            }
        }

        private async Task UploadPictures(IFormFile[] uploadedPictures, Project project)
        {
            if (uploadedPictures == null)
            {
                return;
            }

            if (project.Pictures == null)
            {
                project.Pictures = new List<ProjectPicture>();
            }

            for (int i = 0; i < uploadedPictures.Length; i++)
            {
                var pictureName = GetPictureName(project.Id, Guid.NewGuid());
                var picture = new UploadFileDto
                {
                    Name = pictureName,
                    File = uploadedPictures[i],
                    ContentType = uploadedPictures[i].ContentType
                };

                await _fileService.UploadProjectPictureAsync(picture);
                project.Pictures.Add(new ProjectPicture
                {
                    Name = pictureName,
                });
            }
        }

        private async Task<Freelancer?> GetAndValidateFreelancerByUserEmail(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var freelancer = await _freelancerRepository.GetByUserIdAsync(user.Id);

            if (freelancer is null)
            {
                throw new FreelancerNotFoundException();
            }

            return freelancer;
        }

        public async Task<List<FreelancerProjectDto>> GetFreelancerProjectsByPublishStatus(Freelancer freelancer, bool isPublish)
        {
            var projects = await _projectRepository.GetFreelancerProjectsByPublishStatus(freelancer.Id, isPublish);

            var freelancerProjects = new List<FreelancerProjectDto>();

            foreach (var project in projects)
            {
                int? basicPrice = null;
                int? standardPrice = null;
                int? premiumPrice = null;

                var priceFeature = project.Features.FirstOrDefault();

                if (priceFeature != null && !string.IsNullOrEmpty(priceFeature?.BasicSelectedValue))
                {
                    basicPrice = int.Parse(priceFeature?.BasicSelectedValue);
                }

                if (priceFeature != null && project.HasPackages.Value)
                {
                    if (!string.IsNullOrEmpty(priceFeature.StandardSelectedValue))
                    {
                        standardPrice = int.Parse(priceFeature?.StandardSelectedValue);
                    }
                    if (!string.IsNullOrEmpty(priceFeature.PremiumSelectedValue))
                    {
                        premiumPrice = int.Parse(priceFeature?.PremiumSelectedValue);
                    }
                }

                var freelancerProject = new FreelancerProjectDto
                {
                    Id = project.Id,
                    Title = project.Title,
                    CreatedAt = project.CreatedAt,
                    Picture = project.Pictures.FirstOrDefault() != null ? GetProjectPictureFromBlobStorage(project.Pictures.FirstOrDefault().Name) : null,
                    BasicPrice = basicPrice,
                    StandardPrice = standardPrice,
                    PremiumPrice = premiumPrice
                };

                freelancerProjects.Add(freelancerProject);
            }

            return freelancerProjects;
        }

        public async Task AddProjectReview(string skillScoutEmail, Guid projectId, PostReviewDto request)
        {
            var skillScout = await _usersService.GetUserByEmailAsync(skillScoutEmail);

            var project = await _projectRepository.GetProjectByIdWithReviews(projectId);

            project.Reviews.Add(new ProjectReview
            {
                Reviewer = skillScout,
                Content = request.Content,
                Stars = request.Stars,
                ReviewAt = DateTime.Now
            });

            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProjectAsync(string freelancerEmail, Guid projectId)
        {
            var project = await _projectRepository.GetProjectAllDetailsById(projectId);

            if (project == null)
            {
                throw new ProjectNotFoundException();
            }

            var freelancer = await GetAndValidateFreelancerByUserEmail(freelancerEmail);

            CheckIfFreelancerTryToModifyOwnProject(freelancer, project);

            var orderService = _serviceProvider.GetRequiredService<IOrderService>();

            var orders = await orderService.GetOrdersByProjectId(projectId);

            if (orders.Any(o => o.Status != OrderStatus.Cancelled))
            {
                throw new DeleteProjectException();
            }

            DeletePicturesFromBlobStorage(project.Pictures);
            DeleteVideoFromBlobStorage(project.Video);
            DeleteDocumentsFromBlobStorage(project.Documents);

            await _projectRepository.DeleteAsync(project);
        }

        public async Task<List<GetProjectPreviewDto>> SearchAllProjectsByTitle(string searchText)
        {
            var allProjectTitles = await _projectRepository.GetAllProjectsTitle();

            List<GetProjectPreviewDto> projectsPreview = await PerformSearchAndRetrieveProjects(searchText, allProjectTitles);

            return projectsPreview;
        }

        public async Task<List<GetProjectPreviewDto>> SearchProjectsHavingSkillSubcategoryIdByTitle(Guid id, string searchText)
        {
            var projectsBySkillSubcateogoryId = await _projectRepository.GetProjectsTitleBySubCategoryId(id);

            List<GetProjectPreviewDto> projectsPreview = await PerformSearchAndRetrieveProjects(searchText, projectsBySkillSubcateogoryId);

            return projectsPreview;
        }

        public async Task<List<GetProjectPreviewDto>> SearchProjectsHavingSkillIdByTitle(Guid id, string searchText)
        {
            var projectsBySkillSubcateogoryId = await _projectRepository.GetProjectsTitleBySkillId(id);

            List<GetProjectPreviewDto> projectsPreview = await PerformSearchAndRetrieveProjects(searchText, projectsBySkillSubcateogoryId);

            return projectsPreview;
        }

        private async Task<List<GetProjectPreviewDto>> PerformSearchAndRetrieveProjects(string searchText, List<string> allProjectTitles)
        {
            var matchedTitles = FindProjectsByApproximateName(searchText, allProjectTitles);

            var projects = await _projectRepository.FindProjectsByTitles(matchedTitles);

            var projectsWithMatchedTitles = new List<Project>();
            foreach (var title in matchedTitles)
            {
                var project = projects.FirstOrDefault(p => p.Title == title);
                if (project != null)
                {
                    projectsWithMatchedTitles.Add(project);
                }
            }

            var projectsPreview = new List<GetProjectPreviewDto>();
            await MapProjectPreviewDto(projectsWithMatchedTitles, projectsPreview, null);
            return projectsPreview;
        }

        private IEnumerable<string> FindProjectsByApproximateName(string searchText, List<string> projectsTitles)
        {
            var matches = FuzzySharp.Process.ExtractTop(searchText, projectsTitles, limit: 10, cutoff: 55);

            var sortedMatches = matches.Select(m => (m.Value, m.Score)).ToList();

            sortedMatches.Sort((x, y) => y.Score.CompareTo(x.Score));

            return sortedMatches.Select(s => s.Value);
        }

        private void DeleteDocumentsFromBlobStorage(ICollection<ProjectDocument> documents)
        {
            foreach (var document in documents)
            {
                _fileService.DeleteProjectDocument(document.Name);
            }
        }

        private void DeleteVideoFromBlobStorage(ProjectVideo video)
        {
            if (video != null)
            {
                _fileService.DeleteProjectVideo(video.Name);
            }
        }

        private void DeletePicturesFromBlobStorage(ICollection<ProjectPicture> pictures)
        {
            foreach (var picture in pictures)
            {
                _fileService.DeleteProjectPicture(picture.Name);
            }
        }
    }
}