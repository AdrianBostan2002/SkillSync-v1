﻿namespace SkillSync.Domain.Models
{
    public class ProjectUploadedFileBase
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public string Name { get; set; }
    }
}