using AutoMapper;
using Microsoft.AspNetCore.Http;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Chat.DTOs.Chat;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Chat;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Chat.Services
{
    public class ChatService : IChatService
    {
        private readonly IUserChatRepository _userChatRepository;

        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;
        private readonly IFileService _fileService;

        private readonly IMapper _mapper;

        private string GetChatRoomId(string firstUser, string secondUser) => $"{firstUser}-{secondUser}";
        private string GetUploadFileName(string fileName) => $"{fileName}-{Guid.NewGuid().ToString()}";

        public ChatService
        (
            IUserChatRepository userChatRepository,
            IUserService userService,
            ICacheService cacheService,
            IFileService fileService,
            IMapper mapper
        )
        {
            _userChatRepository = userChatRepository ?? throw new ArgumentNullException(nameof(userChatRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<string> SaveMessageAsync<T>(string chatRoomId, ChatMessageDto<T> message)
        {
            var chatRoom = GetChatRoomFromCache(chatRoomId);
            var senderUserId = GetUserIdFromRoomParticipants(message.Sender, chatRoom);

            string messageContent = null;
            if (message.Type != ChatMessageType.Text)
            {
                var messageAsFile = message.Content as IFormFile;
                var fileName = GetUploadFileName(messageAsFile.FileName);
                var request = new UploadFileDto
                {
                    File = messageAsFile,
                    Name = fileName,
                    ContentType = messageAsFile.ContentType
                };

                await _fileService.UploadChatMediaAsync(request, message.Type);
                messageContent = fileName;
            }

            var chatMessage = new ChatMessage
            {
                Content = messageContent ?? message.Content as string,
                SenderId = senderUserId,
                Type = message.Type,
                SentAt = message.SentAt
            };

            if (chatRoom.Chat.Messages == null)
            {
                chatRoom.Chat.Messages = new List<ChatMessage>();
            }

            chatRoom.Chat.Messages.Add(chatMessage);

            await _userChatRepository.UpdateAsync(chatRoom.Chat);

            return chatMessage.Content;
        }

        public string GetMediaFromStorage(string fileName, ChatMessageType type)
        {
            switch (type)
            {
                case ChatMessageType.Image:
                    return _fileService.GetChatPicture(fileName);
                case ChatMessageType.Video:
                    return _fileService.GetChatVideo(fileName);
                case ChatMessageType.File:
                    return _fileService.GetChatDocument(fileName);
                default:
                    throw new Exception("Invalid message type");
            }
        }

        private string GetUserIdFromRoomParticipants(string senderEmail, ChatRoom chatRoom)
        {
            var fromUser = chatRoom.Chat.FirstUser.Email == senderEmail ? chatRoom.Chat.FirstUser.Id : null;
            if (fromUser == null)
            {
                fromUser = chatRoom.Chat.SecondUser.Email == senderEmail ? chatRoom.Chat.SecondUser.Id : null;

                if (fromUser == null)
                {
                    throw new Exception("User is searched in a wrong room");
                }
            }

            return fromUser;
        }

        public async Task<List<ChatRoomDto>> GetAllUserChats(string email, string connectionId)
        {
            var userChats = await _userChatRepository.GetUserChats(email);

            var chatRoomDtos = new List<ChatRoomDto>();

            foreach (var chat in userChats)
            {
                var chatRoom = CreateRoom(chat);
                var otherParticipant = GetOtherParticipant(email, chatRoom);
                var chatRoomDto = await CreateChatRoomDto(otherParticipant, chatRoom);

                if (GetChatRoomFromCache(chatRoom.Id) == null)
                {
                    chatRoomDto.Id = null;
                }

                chatRoomDtos.Add(chatRoomDto);
            }

            return chatRoomDtos;
        }

        public async Task<ChatRoomDto> UpsertRoomAsync(string firstUserEmail, string firstUserConnectionId, string secondUserEmail)
        {
            var existingChat = await _userChatRepository.GetUserChat(firstUserEmail, secondUserEmail);

            if (existingChat == null)
            {
                var room = await CreateChatRoomAsync(firstUserEmail, secondUserEmail);
                var otherParticipant = GetOtherParticipant(firstUserEmail, room);
                ChatRoomDto chatRoomDTO = await CreateChatRoomDto(otherParticipant, room);
                _cacheService.AddChatRoom(room);
                return chatRoomDTO;
            }

            var existingChatInCache = GetChatRoomFromCache(GetChatRoomId(firstUserEmail, secondUserEmail));
            var chatInCache = GetChatRoomFromCache(GetChatRoomId(secondUserEmail, firstUserEmail));


            if (existingChatInCache != null || chatInCache != null)
            {
                var room = existingChatInCache ?? chatInCache;
                var otherParticipant = GetOtherParticipant(firstUserEmail, room);
                ChatRoomDto chatRoomDTO = await CreateChatRoomDto(otherParticipant, room);
                return chatRoomDTO;
            }

            var chatRoom = CreateRoom(existingChat);
            var theOtherParticipant = GetOtherParticipant(firstUserEmail, chatRoom);
            ChatRoomDto chatRoomDto = await CreateChatRoomDto(theOtherParticipant, chatRoom);
            _cacheService.AddChatRoom(chatRoom);

            return chatRoomDto;
        }

        private async Task<ChatRoomDto> CreateChatRoomDto(User otherParticipant, ChatRoom chatRoom)
        {
            var chatRoomDto = _mapper.Map<ChatRoomDto>(chatRoom);

            chatRoomDto.OtherParticipant = new ChatRoomParticipantDto
            {
                Name = $"{otherParticipant.FirstName} {otherParticipant.LastName}",
                Email = otherParticipant.Email,
                ProfilePicture = await _userService.GetProfilePictureAsync(otherParticipant),
                IsActive = _cacheService.GetUserNotificationConnectionId(otherParticipant.Email) != null ? true : false
            };
            return chatRoomDto;
        }

        public User GetOtherParticipant(string currentParticipant, ChatRoom chatRoom)
        {
            return chatRoom.Chat.FirstUser.Email == currentParticipant ? chatRoom.Chat.SecondUser : chatRoom.Chat.FirstUser;
        }

        public async Task<ChatRoom> CreateChatRoomAsync(string firstUserEmail, string secondUserEmail)
        {
            var firstUser = await _userService.GetUserByEmailAsync(firstUserEmail);
            var secondUser = await _userService.GetUserByEmailAsync(secondUserEmail);

            var newChat = new UserChat
            {
                FirstUser = firstUser,
                SecondUser = secondUser,
            };

            await _userChatRepository.AddAsync(newChat);

            var chatRoom = CreateRoom(newChat);

            return chatRoom;
        }

        private ChatRoom CreateRoom(UserChat newChat)
        {
            var chatRoomId = GetChatRoomId(newChat.FirstUser.Email, newChat.SecondUser.Email);

            var chatRoom = new ChatRoom
            {
                Id = chatRoomId,
                Chat = newChat,
            };

            return chatRoom;
        }

        public void DeleteRoomAsync(string roomName) => _cacheService.DeleteChatRoom(roomName);

        public string GetReceiverConnectionId(string chatRoomId, string sender)
        {
            var chatRoom = GetChatRoomFromCache(chatRoomId);

            if (chatRoom == null)
            {
                throw new ChatNotFoundException();
            }

            var otherChatParticipant = chatRoom.Chat.FirstUser.Email == sender ? chatRoom.Chat.SecondUser : chatRoom.Chat.FirstUser;

            var otherChatParticipantConnectionId = GetConnectionId(otherChatParticipant.Email);

            return otherChatParticipantConnectionId;
        }

        public async Task<ChatRoomDto> ShouldReceiverGetNewInitiatedChatRoomAsync(string chatRoomId, string sender)
        {
            var chatRoom = GetChatRoomFromCache(chatRoomId);

            var currentParticipant = chatRoom.Chat.FirstUser.Email == sender ? chatRoom.Chat.FirstUser : chatRoom.Chat.SecondUser;

            var chatRoomDto = await CreateChatRoomDto(currentParticipant, chatRoom);

            return chatRoomDto.Messages != null && chatRoomDto.Messages.Count != 0 ? null : chatRoomDto;
        }

        public ChatRoom GetChatRoomFromCache(string chatRoomName)
        {
            var chatRoom = _cacheService.GetChatRoom(chatRoomName);

            return chatRoom;
        }

        public string GetConnectionId(string email) => _cacheService.GetConnectionId(email);

        public void ConnectUser(string email, string connectionId) => _cacheService.AddUserConnectionId(email, connectionId);

        public void DisconnectUser(string email) => _cacheService.DisconnectUser(email);
    }
}