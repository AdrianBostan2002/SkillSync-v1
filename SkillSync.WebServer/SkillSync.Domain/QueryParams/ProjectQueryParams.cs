namespace SkillSync.Domain.QueryParams
{
    public class ProjectQueryParams
    {
        public FilterProjectQueryParams? Filters { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
    }
}