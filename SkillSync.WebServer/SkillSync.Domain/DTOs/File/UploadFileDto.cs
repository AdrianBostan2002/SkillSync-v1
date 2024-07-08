using Microsoft.AspNetCore.Http;

namespace SkillSync.Domain.DTOs.File
{
    public class UploadFileDto
    {
        public string Name { get; set; }

        public IFormFile File { get; set; }

        public string? ContentType { get; set; }
    }
}