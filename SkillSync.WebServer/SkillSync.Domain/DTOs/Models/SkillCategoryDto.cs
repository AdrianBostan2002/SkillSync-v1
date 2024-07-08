namespace SkillSync.Domain.DTOs.Models
{
    public class SkillCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SkillSubcategoryDto> SkillSubcategories { get; set; }
    }
}
