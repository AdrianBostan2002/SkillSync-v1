using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.Enums;

namespace SkillSync.AzureBlobStorage.Interfaces
{
    public interface IFileService
    {
        Task UploadProfilePictureAsync(UploadFileDto request);
        Task UploadProjectPictureAsync(UploadFileDto request);
        Task UploadProjectVideoAsync(UploadFileDto request);
        Task UploadDocumentAsync(UploadFileDto request);
        string GetProfilePicture(string name);
        string GetProjectImage(string name);
        string GetProjectVideo(string name);
        string GetProjectDocument(string name);
        void DeleteProfilePicture(string name);
        void DeleteProjectPicture(string name);
        void DeleteProjectVideo(string name);
        void DeleteProjectDocument(string name);
        string GetChatPicture(string name);
        string GetChatVideo(string name);
        string GetChatDocument(string name);
        Task UploadChatMediaAsync(UploadFileDto request, ChatMessageType messageType);
        void DeleteOrderContentVideo(string name);
        void DeleteOrderContentDocument(string name);
        void DeleteOrderContentPicture(string name);
        Task UploadOrderContentPictureAsync(UploadFileDto request);
        Task UploadOrderContentVideoAsync(UploadFileDto request);
        Task UploadOrderContentDocumentAsync(UploadFileDto request);
        string GetOrderContentPicture(string name);
        string GetOrderContentVideo(string name);
        string GetOrderContentDocument(string name);
        void DeleteOrderContentAudio(string name);
        string GetOrderContentAudio(string name);
        Task UploadOrderContentAudioAsync(UploadFileDto request);
        Task<(Stream, string)> DownloadOrderContentAsync(string name, OrderContentType type);
        string GetResume(string name);
        Task UploadResume(UploadFileDto request);
    }
}