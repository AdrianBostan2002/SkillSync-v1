using Microsoft.AspNetCore.Http;

namespace SkillSync.Domain.DTOs.Order
{
    public class OrderContentFileDto
    {
        public IFormFile? File { get; set; }

        public string? Description { get; set; }
    }
}