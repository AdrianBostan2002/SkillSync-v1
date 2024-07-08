using AutoMapper;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.DTOs.Review;
using SkillSync.Domain.Exceptions.Freelancer;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IMapper _mapper;

        private readonly IUsersRepository _usersRepository;
        private readonly IFreelancerRepository _freelancersRepository;
        private readonly IProjectRepository _projectRepository;

        private readonly IUserService _userService;
        private readonly IProjectService _projectService;

        public FreelancerService
        (
            IMapper mapper,
            IUsersRepository usersRepository,
            IFreelancerRepository freelancersRepository,
            IProjectRepository projectRepository,
            IUserService userService,
            IProjectService projectService
        )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _freelancersRepository = freelancersRepository ?? throw new ArgumentNullException(nameof(freelancersRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        public async Task<FreelancerDto> GetFreelancerDtoById(Guid freelancerId)
        {
            var freelancer = await _freelancersRepository.GetFreelancerByIdIncludeAllDetails(freelancerId);

            if (freelancer == null)
            {
                throw new FreelancerNotFoundException();
            }

            var freelancerDto = _mapper.Map<FreelancerDto>(freelancer);
            freelancerDto.ProfilePicture = await _userService.GetProfilePictureAsync(freelancer.User.Email);

            var freelancerProjects = await _projectRepository.GetFreelancerProjectsForPreview(freelancerId);

            freelancerDto.Projects = new List<GetProjectPreviewDto>();
            await _projectService.MapProjectPreviewDto(freelancerProjects, freelancerDto.Projects, null);

            freelancerDto.Reviews = new FreelancerReviewsDto
            {
                UsersProfilePicture = new Dictionary<string, string>(),
                Projects = new Dictionary<Guid, ProjectReviewDataDto>(),
                Reviews = new List<GetFreelancerReviewDto>()
            };

            double reviewRatingSum = 0d;
            foreach (var project in freelancerProjects)
            {
                foreach (var review in project.Reviews)
                {
                    var reviewerName = GetFullName(review.Reviewer);
                    if (!freelancerDto.Reviews.UsersProfilePicture.ContainsKey(reviewerName))
                    {
                        freelancerDto.Reviews.UsersProfilePicture.Add(reviewerName, await _userService.GetProfilePictureAsync(review.Reviewer.Email));
                    }

                    if (!freelancerDto.Reviews.Projects.ContainsKey(project.Id))
                    {
                        var projectDto = new ProjectReviewDataDto
                        {
                            Name = project.Title,
                            Picture = _projectService.GetProjectPictureFromBlobStorage(project.Pictures.FirstOrDefault().Name)
                        };

                        freelancerDto.Reviews.Projects.Add(project.Id, projectDto);
                    }

                    var reviewDto = new GetFreelancerReviewDto
                    {
                        ReviewerName = reviewerName,
                        ProjectId = project.Id,
                        ReviewAt = review.ReviewAt,
                        Stars = review.Stars,
                        Content = review.Content,
                    };
                    reviewRatingSum += review.Stars;

                    freelancerDto.Reviews.Reviews.Add(reviewDto);
                }
            }
            if (reviewRatingSum != 0)
            {
                var averageRating = reviewRatingSum / freelancerDto.Reviews.Reviews.Count;
                freelancerDto.Reviews.ReviewStatistics = new ReviewStatisticsDto
                {
                    AverageRating = Math.Round(averageRating, 1, MidpointRounding.AwayFromZero),
                    TotalReviews = freelancerDto.Reviews.Reviews.Count
                };
            }

            return freelancerDto;
        }

        public async Task<List<FreelancerProjectDto>> GetFreelancerProjectsByPublishStatusAsync(string freelancerEmail, bool publishStatus)
        {
            Freelancer freelancer = await GetFreelancerAsync(freelancerEmail);

            var freelancerProjects = await _projectService.GetFreelancerProjectsByPublishStatus(freelancer, publishStatus);

            return freelancerProjects;
        }

        private static string GetFullName(User reviewer)
        {
            return $"{reviewer.FirstName} {reviewer.LastName}";
        }

        public async Task<Freelancer> GetFreelancerById(Guid freelancerId)
        {
            var freelancer = await _freelancersRepository.SingleByCondition(f => f.Id == freelancerId);

            if (freelancer == null)
            {
                throw new FreelancerNotFoundException();
            }

            return freelancer;
        }

        public async Task<bool> HasCompletedExperienceInformationsAsync(string email)
        {
            Freelancer freelancer = await GetFreelancerAsync(email);

            return await Task.FromResult(freelancer.HasCompletedExperienceInformations);
        }

        public async Task SetCompleteExperienceInformationsAsync(string email, bool hasCompleted)
        {
            var freelancer = await GetFreelancerAsync(email);

            freelancer.HasCompletedExperienceInformations = hasCompleted;

            await _freelancersRepository.UpdateAsync(freelancer);
        }

        public async Task CompleteExperienceInformationsAsync(string email, CompleteFreelancerExperienceInfoRequest request)
        {
            Freelancer freelancer = await GetFreelancerAsync(email);

            if (freelancer.FreelancerSkills == null)
            {
                freelancer.FreelancerSkills = new List<FreelancerSkills>();
            }

            foreach (var skill in request.Skills)
            {
                var mappedSkill = _mapper.Map<Skill>(skill);

                var newFreelancerSkill = new FreelancerSkills
                {
                    Freelancer = freelancer,
                    Skill = mappedSkill,
                    Experience = Domain.Enums.SkillExperienceLevel.LessThenOneYear
                };

                freelancer.FreelancerSkills.Add(newFreelancerSkill);
            }

            freelancer.ScopeDescription = request.ScopeDescription;
            freelancer.HasCompletedExperienceInformations = true;

            await _freelancersRepository.UpdateAsync(freelancer);
        }

        public async Task<Freelancer> GetFreelancerAsync(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            return await GetFreelancerAsync(user);
        }

        public async Task<Freelancer> GetFreelancerAsync(User user)
        {
            var freelancer = await _freelancersRepository.GetByUserIdAsync(user.Id);

            if (freelancer == null)
            {
                throw new FreelancerNotFoundException();
            }

            return freelancer;
        }
    }
}
