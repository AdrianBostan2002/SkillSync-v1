namespace SkillSync.Domain.QueryParams
{
    public class FilterProjectQueryParams
    {
        public List<Guid>? FeaturesIds { get; set; }

        public int? Rating { get; set; }

        public List<string>? CountryCodes { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public int? MaxDays { get; set; }
    }
}