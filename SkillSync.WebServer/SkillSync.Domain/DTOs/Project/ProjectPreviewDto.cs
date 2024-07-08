namespace SkillSync.Domain.DTOs.Project
{
    public class ProjectPreviewDto
    {
        public List<GetProjectPreviewDto> Projects { get; set; }

        public int TotalProjectsCount { get; set; }
    }
}