using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IFreelancerRepository : IRepository<Freelancer>
    {
        Task<Freelancer> GetByUserIdAsync(string userId);
        Task<Freelancer> GetFreelancerByIdIncludeAllDetails(Guid freelancerId);
    }
}