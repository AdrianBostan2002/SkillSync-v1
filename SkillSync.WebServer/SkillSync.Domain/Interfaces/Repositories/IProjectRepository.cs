using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetAllProjectsForPreview();
        Task<List<Project>> GetFreelancerProjects(Guid freelancerId);
        Task<List<Project>> GetFreelancerProjectsForPreview(Guid freelancerId);
        Task<Project> GetProjectAllDetailsById(Guid id);
        Task<Project> GetProjectById(Guid skillId);
        Task<Project> GetProjectByIdWithFeatures(Guid projectId);
        Task<Project> GetProjectByIdWithFrequentlyAskedQuestions(Guid projectId);
        Task<Project> GetProjectByIdWithMedia(Guid projectId);
        Task<Project> GetProjectByIdWithReviews(Guid projectId);
        Task<List<Project>> GetProjectsForPreviewBySkillId(Guid id);
        Task<List<Project>> GetProjectProjectsForPreviewBySubcategoryId(Guid id);
        Task<List<Project>> GetFreelancerProjectsByPublishStatus(Guid freelancerId, bool isPublish);
        Task<List<string>> GetAllProjectsTitle();
        Task<List<Project>> FindProjectsByTitles(IEnumerable<string> projectsTitles);
        Task<List<string>> GetProjectsTitleBySubCategoryId(Guid id);
        Task<List<string>> GetProjectsTitleBySkillId(Guid id);
    }
}