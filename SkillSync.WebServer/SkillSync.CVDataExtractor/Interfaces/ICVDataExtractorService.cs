using Microsoft.AspNetCore.Http;
using SkillSync.Domain.DTOs.Resume;

namespace SkillSync.CVDataExtractor.Interfaces
{
    public interface ICVDataExtractorService
    {
        Task<ResumeDataDto> ExtractResumeDataAsync(IFormFile resume);
    }
}