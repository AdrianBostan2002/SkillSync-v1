namespace SkillSync.Domain.DTOs.Models
{
    public class SkillSubcategoryDto
    {
        public Guid Id { get; set; }

        public Guid SkillCategoryId { get; set; }

        public List<SkillDto> Skills { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}