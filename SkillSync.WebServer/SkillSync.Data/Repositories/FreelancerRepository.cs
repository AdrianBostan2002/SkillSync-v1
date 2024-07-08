using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class FreelancerRepository : RepositoryBase<Freelancer>, IFreelancerRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public FreelancerRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<Freelancer> GetFreelancerByIdIncludeAllDetails(Guid freelancerId)
        {
            var query = await _repositoryContext.Set<Freelancer>()
                .Where(f => f.Id == freelancerId)
                .Include(f => f.User)
                .Include(f => f.FreelancerSkills)
                .ThenInclude(f => f.Skill)
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<Freelancer> GetByUserIdAsync(string userId)
        {
            return await _repositoryContext.Set<Freelancer>().Where(f => f.UserId == userId).FirstOrDefaultAsync();
        }
    }
}