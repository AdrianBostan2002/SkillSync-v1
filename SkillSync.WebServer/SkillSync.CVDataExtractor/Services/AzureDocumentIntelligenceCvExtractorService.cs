using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.CVDataExtractor.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.DTOs.Resume;

namespace SkillSync.CVDataExtractor.Services
{
    public class AzureDocumentIntelligenceCvExtractorService : ICVDataExtractorService
    {
        private string _endpoint;
        private string _apiKey;
        private string _modelId;

        private readonly IFileService _fileService;

        public AzureDocumentIntelligenceCvExtractorService(IConfiguration config, IFileService fileService)
        {
            _endpoint = config["AzureDocumentIntelligence:Endpoint"];
            _apiKey = config["AzureDocumentIntelligence:ApiKey"];
            _modelId = config["AzureDocumentIntelligence:ModelId"];

            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        private async Task UploadResumeToBlobStorageAsync(IFormFile resume, string name)
        {
            var uploadFile = new UploadFileDto
            {
                File = resume,
                Name = name,
                ContentType = resume.ContentType,
            };

            await _fileService.UploadResume(uploadFile);
        }

        public async Task<ResumeDataDto> ExtractResumeDataAsync(IFormFile resume)
        {
            var resumeName = Guid.NewGuid().ToString();

            await UploadResumeToBlobStorageAsync(resume, resumeName);

            var resumeUri = _fileService.GetResume(resumeName);

            AnalyzeResult result = await ExtractData(resumeUri);

            ResumeDataDto resumeData = MapExtractedDataToDto(result);

            resumeData.ResumeBlobUri = resumeUri;

            return resumeData;
        }

        private async Task<AnalyzeResult> ExtractData(string resumeUri)
        {
            AzureKeyCredential credential = new AzureKeyCredential(_apiKey);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(_endpoint), credential);

            Uri fileUri = new Uri(resumeUri);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, _modelId, fileUri);
            AnalyzeResult result = operation.Value;
            return result;
        }

        private static ResumeDataDto MapExtractedDataToDto(AnalyzeResult result)
        {
            var resumeData = new ResumeDataDto();

            foreach (AnalyzedDocument document in result.Documents)
            {
                Console.WriteLine($"Document of type: {document.DocumentType}");

                if (document.Fields.ContainsKey("firstName"))
                {
                    resumeData.FirstName = document.Fields["firstName"]?.Content;
                }

                if (document.Fields.ContainsKey("lastName"))
                {
                    resumeData.LastName = document.Fields["lastName"]?.Content;
                }

                if (document.Fields.ContainsKey("emailAddress"))
                {
                    resumeData.EmailAddress = document.Fields["emailAddress"]?.Content;
                }

                if (document.Fields.ContainsKey("phoneNumber"))
                {
                    resumeData.PhoneNumber = document.Fields["phoneNumber"]?.Content;
                }

                if (document.Fields.ContainsKey("fullAddress"))
                {
                    resumeData.FullAddress = document.Fields["fullAddress"]?.Content;
                }

                if (document.Fields.ContainsKey("nationality"))
                {
                    resumeData.Nationality = document.Fields["nationality"]?.Content;
                }

                if (document.Fields.ContainsKey("dateOfBirth") && DateTime.TryParse(document.Fields["dateOfBirth"]?.Content, out DateTime dateOfBirth))
                {
                    resumeData.DateOfBirth = dateOfBirth;
                }
            }

            return resumeData;
        }
    }
}