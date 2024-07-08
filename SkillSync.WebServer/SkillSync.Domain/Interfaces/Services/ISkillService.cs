using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Register;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface ISkillService
    {
        Task AddFreelancerSkills(string email, RegisterFreelancerSkillsRequest request);
        Task<SkillDto> GetById(Guid id);
    }
}