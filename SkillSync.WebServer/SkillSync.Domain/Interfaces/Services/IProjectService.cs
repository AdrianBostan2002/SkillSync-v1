using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Review;
using SkillSync.Domain.Models;
using SkillSync.Domain.QueryParams;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IProjectService
    {
        Task AddProjectAsync(PostProjectRequest request, string email);
        Task<Guid> AddProjectOverviewAsync(OverviewStepDto request, string email);
        Task<List<GetProjectPreviewDto>> GetAllProjectsPreviewAsync();
        Task<DescriptionFaqStepDto> GetProjectDescriptionAndFaqStepAsync(Guid projectId);
        Task<GetPricingStepDto> GetPricingStepAsync(Guid projectId);
        Task<ProjectDto> GetProjectAllDetailsByIdAsync(Guid projectId);
        Task<OverviewStepDto> GetProjectOverviewStepAsync(Guid projectlId);
        Task<ProjectPreviewDto> GetProjectsPreviewBySkillId(Guid skillId, string userWhoMadeRequestEmail, ProjectQueryParams queryParams);
        Task<Guid> UpdateProjectOverviewAsync(OverviewStepDto request, Guid projectId, string email);
        Task UpsertDescriptionAndFaqStepAsync(DescriptionFaqStepDto request, Guid projectId, string email);
        Task UpsertPricingStepAsync(UpsertPricingStepDto request, Guid projectId, string email);
        Task UpsertProjectGalleryStepAsync(UpsertProjectGalleryStepDto request, Guid projectId, string email);
        Task<GetProjectGalleryStepDto> GetProjectGalleryStepAsync(Guid projectId);
        Task ModifyProjectPublishStatusAsync(Guid projectId, bool newStatus, string email);
        Task<bool> GetProjectPublishStatusAsync(Guid projectId);
        List<string> GetProjectPicturesFromBlobStorage(Project project);
        string GetProjectVideoFromBlobStorage(Project project);
        List<string> GetProjectDocumentsFromBlobStorage(Project project);
        Task MapProjectPreviewDto(List<Project> projects, List<GetProjectPreviewDto> projectsPreview, User userWhoMadeRequest);
        Task<Project> GetProjectById(Guid projectId);
        Task AddProjectReview(string skillScoutEmail, Guid projectId, PostReviewDto request);
        string GetProjectPictureFromBlobStorage(string pictureName);
        Task<ProjectPreviewDto> GetProjectsPreviewBySubcategoryId(Guid subcategoryId, string userWhoMadeRequestEmail, ProjectQueryParams queryParams);
        Task<List<FreelancerProjectDto>> GetFreelancerProjectsByPublishStatus(Freelancer freelancer, bool isPublish);
        Task DeleteProjectAsync(string freelancerEmail, Guid projectId);
        Task<List<GetProjectPreviewDto>> SearchAllProjectsByTitle(string searchText);
        Task<List<GetProjectPreviewDto>> SearchProjectsHavingSkillSubcategoryIdByTitle(Guid id, string searchText);
        Task<List<GetProjectPreviewDto>> SearchProjectsHavingSkillIdByTitle(Guid id, string searchText);
    }
}