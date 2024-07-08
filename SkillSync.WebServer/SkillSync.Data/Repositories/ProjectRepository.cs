using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public ProjectRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<Project> GetProjectAllDetailsById(Guid id)
        {
            var query = await _repositoryContext.Set<Project>()
                .Where(p => p.Id == id)
                .Include(p => p.Pictures)
                .Include(p => p.Video)
                .Include(p => p.Documents)
                .Include(p => p.Freelancer)
                .ThenInclude(f => f.User)
                .Include(p => p.FrequentlyAskedQuestions)
                .Include(p => p.Reviews)
                .ThenInclude(r => r.Reviewer)
                .Include(p => p.Features)
                .ThenInclude(p => p.Feature)
                .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            var query = await _repositoryContext.Set<Project>()
                .Where(p => p.Id == projectId)
                .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<Project> GetProjectByIdWithFeatures(Guid projectId)
        {
            var query = await _repositoryContext.Set<Project>()
               .Where(p => p.Id == projectId)
               .Include(p => p.Features)
               .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<Project> GetProjectByIdWithReviews(Guid projectId)
        {
            var query = await _repositoryContext.Set<Project>()
               .Where(p => p.Id == projectId)
               .Include(p => p.Reviews)
               .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<Project> GetProjectByIdWithFrequentlyAskedQuestions(Guid projectId)
        {
            var query = await _repositoryContext.Set<Project>()
               .Where(p => p.Id == projectId)
               .Include(p => p.FrequentlyAskedQuestions)
               .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<Project> GetProjectByIdWithMedia(Guid projectId)
        {
            var query = await _repositoryContext.Set<Project>()
               .Where(p => p.Id == projectId)
               .Include(p => p.Pictures)
               .Include(p => p.Video)
               .Include(p => p.Documents)
               .ToListAsync();

            return query.FirstOrDefault();
        }

        public async Task<List<string>> GetAllProjectsTitle()
        {
            return await _repositoryContext.Set<Project>().Select(p => p.Title).ToListAsync();
        }

        public async Task<List<string>> GetProjectsTitleBySubCategoryId(Guid id)
        {
            return await _repositoryContext.Set<Project>().Where(p => p.Skill.SkillSubcategoryId == id).Select(p => p.Title).ToListAsync();
        }

        public async Task<List<string>> GetProjectsTitleBySkillId(Guid id)
        {
            return await _repositoryContext.Set<Project>().Where(p => p.SkillId == id).Select(p => p.Title).ToListAsync();
        }

        public async Task<List<Project>> FindProjectsByTitles(IEnumerable<string> projectsTitles)
        {
            var query = PrepareQueryForGetProjectPreview();

            query = query.Where(p => projectsTitles.Contains(p.Title));

            return await query.ToListAsync();
        }

        public async Task<List<Project>> GetAllProjectsForPreview()
        {
            var query = PrepareQueryForGetProjectPreview();

            return await query.ToListAsync();
        }

        public async Task<List<Project>> GetProjectProjectsForPreviewBySubcategoryId(Guid id)
        {
            var query = PrepareQueryForGetProjectPreview();

            query = query.Where(p => p.Skill.SkillSubcategoryId == id && p.IsPublished);

            return await query.ToListAsync();
        }

        public async Task<List<Project>> GetProjectsForPreviewBySkillId(Guid id)
        {
            var query = PrepareQueryForGetProjectPreview();

            query = query.Where(p => p.Skill.Id.Equals(id) && p.IsPublished);

            return await query.ToListAsync();
        }

        public async Task<List<Project>> GetFreelancerProjects(Guid freelancerId)
        {
            return await _repositoryContext.Set<Project>()
                .Where(p => p.FreelancerId == freelancerId)
                .ToListAsync();
        }

        public async Task<List<Project>> GetFreelancerProjectsByPublishStatus(Guid freelancerId, bool isPublish)
        {
            return await _repositoryContext.Set<Project>()
                .Where(p => p.FreelancerId == freelancerId && p.IsPublished == isPublish)
                .Include(p => p.Pictures)
                .Include(p => p.Features.Where(f => f.Feature.Name == "Price"))
                .ToListAsync();
        }

        public async Task<List<Project>> GetFreelancerProjectsForPreview(Guid freelancerId)
        {
            return await _repositoryContext.Set<Project>()
                .Where(p => p.FreelancerId == freelancerId && p.IsPublished)
                .Include(p => p.Features)
                .ThenInclude(f => f.Feature)
                .Include(p => p.Pictures)
                .Include(p => p.Video)
                .Include(p => p.Reviews)
                .ThenInclude(r => r.Reviewer)
                .ToListAsync();
        }

        private IQueryable<Project> PrepareQueryForGetProjectPreview()
        {
            return _repositoryContext.Set<Project>()
            .Include(p => p.Pictures)
            .Include(p => p.Video)
            .Include(p => p.Reviews)
            .Include(p => p.Features)
            .ThenInclude(f => f.Feature)
            .Include(p => p.Freelancer).ThenInclude(f => f.User);
        }
    }
}