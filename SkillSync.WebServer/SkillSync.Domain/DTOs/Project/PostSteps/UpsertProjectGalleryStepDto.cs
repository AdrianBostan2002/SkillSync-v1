using Microsoft.AspNetCore.Http;

namespace SkillSync.Domain.DTOs.Project.PostSteps
{
    public class UpsertProjectGalleryStepDto
    {
        public IFormFile[]? UploadedPictures { get; set; }

        public IFormFile? UploadedVideo { get; set; }

        public IFormFile[]? UploadedDocuments { get; set; }

        public List<string>? UnModifiedMediaUrls { get; set; }
    }
}