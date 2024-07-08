namespace SkillSync.Domain.DTOs.Resume
{
    public class ResumeDataDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FullAddress { get; set; }

        public string? Nationality { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ResumeBlobUri { get; set; }
    }
}