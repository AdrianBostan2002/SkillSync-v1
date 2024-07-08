using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IOrderContentService
    {
        void DeleteSpecificOrderContents(List<Guid> orderContentsIdToBeDeleted, Order order);
        Task<(Stream, string)> DownloadOrderContent(Guid orderContentId);
        OrderContent EnsureTextContentExists(List<OrderContent> orderContents, OrderContentPurpose purpose);
        void UpdateDescriptions(List<ModifiedDescriptionDto> newDescriptions, Order order);
        Task UploadOrderContentMedia(UpsertOrderContentDto request, Order order, OrderContentPurpose purpose);
    }
}