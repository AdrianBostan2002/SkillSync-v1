using Microsoft.AspNetCore.Http;
using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Project
{
    public class PostProjectRequest
    {
        public Guid SkillId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool HasPackages { get; set; }

        public ICollection<ProjectFeatureDto> Features { get; set; }

        public ICollection<FrequentlyAskedQuestionDto>? FrequentlyAskedQuestions { get; set; }

        public IFormFile[]? UploadedPictures { get; set; }

        public IFormFile? UploadedVideo { get; set; }

        public IFormFile[]? UploadedDocuments { get; set; }
    }
}