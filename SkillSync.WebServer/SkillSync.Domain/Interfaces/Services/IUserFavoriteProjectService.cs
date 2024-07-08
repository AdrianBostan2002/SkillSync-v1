
namespace SkillSync.Domain.Interfaces.Services
{
    public interface IUserFavoriteProjectService
    {
        Task ChangeProjectFavoriteStatusAsync(Guid projectId, bool status, string userWhoMadeRequestEmail);
    }
}