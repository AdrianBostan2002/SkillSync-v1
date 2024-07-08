using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IFreelancerService
    {
        Task<bool> HasCompletedExperienceInformationsAsync(string email);
        Task CompleteExperienceInformationsAsync(string email, CompleteFreelancerExperienceInfoRequest request);
        Task SetCompleteExperienceInformationsAsync(string email, bool hasCompleted);
        Task<FreelancerDto> GetFreelancerDtoById(Guid freelancerId);
        Task<Freelancer> GetFreelancerAsync(User user);
        Task<Freelancer> GetFreelancerAsync(string email);
        Task<Freelancer> GetFreelancerById(Guid freelancerId);
        Task<List<FreelancerProjectDto>> GetFreelancerProjectsByPublishStatusAsync(string freelancerEmail, bool publishStatus);
    }
}