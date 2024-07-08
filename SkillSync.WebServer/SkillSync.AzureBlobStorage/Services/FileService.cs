using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.Enums;

namespace SkillSync.AzureBlobStorage.Services
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;

        private const string profilePicturesContainerName = "skillsyncpictures";

        private const string projectPicturesContainer = "skillsync-projects-pictures";
        private const string projectVideosContainer = "skillsync-projects-videos";
        private const string projectDocumentsContainer = "skillsync-projects-documents";
        private const string chatPicturesContainer = "skillsync-chat-pictures";
        private const string chatVideosContainer = "skillsync-chat-videos";
        private const string chatDocumentsContainer = "skillsync-chat-documents";
        private const string picturesOrderContentContainer = "skillsync-order-content-pictures";
        private const string videosOrderContentContainer = "skillsync-order-content-videos";
        private const string documentsOrderContentContainer = "skillsync-order-content-documents";
        private const string audiosOrderContentContainer = "skillsync-order-content-audios";

        private const string resumeContainer = "skillsync-resumes";

        private int profilePictureExpirationTime;
        private int basicFilExpirationTime;

        public FileService(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient ?? throw new ArgumentNullException(nameof(blobServiceClient));

            profilePictureExpirationTime = int.Parse(configuration.GetSection("AzureBlobStorage:ProfilePictureExpirationTime").Value);
            basicFilExpirationTime = int.Parse(configuration.GetSection("AzureBlobStorage:BasicFileExpirationTime").Value);
        }

        public async Task UploadProfilePictureAsync(UploadFileDto request)
        {
            await Upload(request, profilePicturesContainerName);
        }

        public async Task UploadProjectPictureAsync(UploadFileDto request)
        {
            await Upload(request, projectPicturesContainer);
        }

        public async Task UploadProjectVideoAsync(UploadFileDto request)
        {
            await Upload(request, projectVideosContainer);
        }

        public async Task UploadDocumentAsync(UploadFileDto request)
        {
            await Upload(request, projectDocumentsContainer);
        }

        public async Task UploadChatMediaAsync(UploadFileDto request, ChatMessageType messageType)
        {
            switch (messageType)
            {
                case ChatMessageType.Image:
                    await UploadChatPictureAsync(request);
                    break;
                case ChatMessageType.Video:
                    await UploadChatVideoAsync(request);
                    break;
                case ChatMessageType.File:
                    string contentType = "application/pdf";
                    if (request.File.FileName.Contains("pdf"))
                    {
                        contentType = "application/pdf";
                    }
                    else if (request.File.FileName.Contains("doc"))
                    {
                        contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    }
                    request.ContentType = contentType;
                    await UploadChatDocumentAsync(request);
                    break;
                default:
                    throw new Exception("Invalid message type");
            }
        }

        private async Task UploadChatPictureAsync(UploadFileDto request)
        {
            await Upload(request, chatPicturesContainer);
        }

        private async Task UploadChatVideoAsync(UploadFileDto request)
        {
            await Upload(request, chatVideosContainer);
        }

        private async Task UploadChatDocumentAsync(UploadFileDto request)
        {
            var blobClient = CreateBlobClient(request.Name, chatDocumentsContainer);

            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = request.ContentType
                }
            };

            await blobClient.UploadAsync(request.File.OpenReadStream(), options, cancellationToken: default);
        }

        public async Task UploadOrderContentPictureAsync(UploadFileDto request)
        {
            await Upload(request, picturesOrderContentContainer);
        }

        public async Task UploadOrderContentVideoAsync(UploadFileDto request)
        {
            await Upload(request, videosOrderContentContainer);
        }

        public async Task UploadOrderContentDocumentAsync(UploadFileDto request)
        {
            await Upload(request, documentsOrderContentContainer);
        }

        public async Task UploadOrderContentAudioAsync(UploadFileDto request)
        {
            await Upload(request, audiosOrderContentContainer);
        }

        public async Task UploadResume(UploadFileDto request)
        {
            await Upload(request, resumeContainer);
        }

        private async Task Upload(UploadFileDto request, string containerName)
        {
            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = request.ContentType
                }
            };

            var blobClient = CreateBlobClient(request.Name, containerName);

            await blobClient.UploadAsync(request.File.OpenReadStream(), options, cancellationToken: default);
        }

        public string GetProfilePicture(string name)
        {
            return GetFileAsync(name, profilePicturesContainerName, profilePictureExpirationTime);
        }

        public string GetProjectImage(string name)
        {
            return GetFileAsync(name, projectPicturesContainer, basicFilExpirationTime);
        }

        public string GetProjectVideo(string name)
        {
            return GetFileAsync(name, projectVideosContainer, basicFilExpirationTime);
        }

        public string GetProjectDocument(string name)
        {
            return GetFileAsync(name, projectDocumentsContainer, basicFilExpirationTime);
        }

        public string GetChatPicture(string name)
        {
            return GetFileAsync(name, chatPicturesContainer, basicFilExpirationTime);
        }

        public string GetChatVideo(string name)
        {
            return GetFileAsync(name, chatVideosContainer, basicFilExpirationTime);
        }

        public string GetChatDocument(string name)
        {
            return GetFileAsync(name, chatDocumentsContainer, basicFilExpirationTime);
        }

        public string GetOrderContentPicture(string name)
        {
            return GetFileAsync(name, picturesOrderContentContainer, basicFilExpirationTime);
        }

        public string GetOrderContentVideo(string name)
        {
            return GetFileAsync(name, videosOrderContentContainer, basicFilExpirationTime);
        }

        public string GetOrderContentDocument(string name)
        {
            return GetFileAsync(name, documentsOrderContentContainer, basicFilExpirationTime);
        }

        public string GetOrderContentAudio(string name)
        {
            return GetFileAsync(name, audiosOrderContentContainer, basicFilExpirationTime);
        }

        public string GetResume(string name)
        {
            return GetFileAsync(name, resumeContainer, basicFilExpirationTime);
        }

        private string GetFileAsync(string fileName, string containerName, int expirationTime)
        {
            BlobClient blobClient = CreateBlobClient(fileName, containerName);

            var policy = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = fileName,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5), 
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(expirationTime),
                Protocol = SasProtocol.Https, 
            };

            policy.SetPermissions(BlobSasPermissions.Read);

            var pictureWithSasToken = blobClient.GenerateSasUri(policy);

            return pictureWithSasToken.ToString();
        }

        public async Task<(Stream, string)> DownloadOrderContentAsync(string name, OrderContentType type)
        {
            BlobClient blobClient;

            switch (type)
            {
                case OrderContentType.Image:
                    blobClient = CreateBlobClient(name, picturesOrderContentContainer);
                    break;
                case OrderContentType.Video:
                    blobClient = CreateBlobClient(name, videosOrderContentContainer);
                    break;
                case OrderContentType.Document:
                    blobClient = CreateBlobClient(name, documentsOrderContentContainer);
                    break;
                case OrderContentType.Audio:
                    blobClient = CreateBlobClient(name, audiosOrderContentContainer);
                    break;
                default:
                    throw new Exception("Invalid order content type");
            }

            var blobDownload = await blobClient.DownloadAsync();

            (Stream, string) result = (blobDownload.Value.Content, blobDownload.Value.ContentType);

            return result;
        }

        private string GetFileExtension(OrderContentType type)
        {
            switch (type)
            {
                case OrderContentType.Image:
                    return ".jpg";
                case OrderContentType.Video:
                    return ".mp4";
                case OrderContentType.Document:
                    return ".docx";
                case OrderContentType.Audio:
                    return ".mp3";
                default:
                    throw new Exception("Invalid order content type");
            }
        }

        public void DeleteOrderContentVideo(string name)
        {
            DeleteFile(name, videosOrderContentContainer);
        }

        public void DeleteOrderContentDocument(string name)
        {
            DeleteFile(name, documentsOrderContentContainer);
        }

        public void DeleteOrderContentAudio(string name)
        {
            DeleteFile(name, audiosOrderContentContainer);
        }

        public void DeleteOrderContentPicture(string name)
        {
            DeleteFile(name, picturesOrderContentContainer);
        }

        public void DeleteProfilePicture(string name)
        {
            DeleteFile(name, profilePicturesContainerName);
        }

        public void DeleteProjectPicture(string name)
        {
            DeleteFile(name, projectPicturesContainer);
        }

        public void DeleteProjectVideo(string name)
        {
            DeleteFile(name, projectVideosContainer);
        }

        public void DeleteProjectDocument(string name)
        {
            DeleteFile(name, projectDocumentsContainer);
        }

        private void DeleteFile(string name, string containerName)
        {
            var blobClient = CreateBlobClient(name, containerName);

            blobClient.DeleteIfExists();
        }

        private BlobClient CreateBlobClient(string name, string containerName)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = containerInstance.GetBlobClient(name);
            return blobClient;
        }
    }
}