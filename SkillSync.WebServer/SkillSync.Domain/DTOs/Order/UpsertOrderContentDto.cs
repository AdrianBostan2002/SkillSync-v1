namespace SkillSync.Domain.DTOs.Order
{
    public class UpsertOrderContentDto
    {
        public OrderContentFileDto[]? UploadedPictures { get; set; }

        public OrderContentFileDto[]? UploadedVideos { get; set; }

        public OrderContentFileDto[]? UploadedDocuments { get; set; }

        public OrderContentFileDto[]? UploadedAudios { get; set; }

        public string? ModifiedNotes { get; set; }

        public List<ModifiedDescriptionDto>? ModifiedDescriptions { get; set; }

        public List<Guid>? DeletedOrderContents { get; set; }
    }
}