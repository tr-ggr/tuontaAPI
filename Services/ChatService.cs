using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Repositories;

namespace tuontaAPI.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public List<ChatDto> GetChats()
        {
            var chats = _chatRepository.GetChats();
            return chats.Select(chat => new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                ChatItems = chat.ChatItems.Select(item => new ChatItemDto
                {
                    ChatId = item.ChatId,
                    SenderId = item.SenderId,
                    Message = item.Message,
                    Timestamp = item.Timestamp
                }).ToList()
            }).ToList();
        }

        public List<ChatDto> GetChatsByUser1Id(int userId)
        {
            var chats = _chatRepository.GetChatsByUser1Id(userId);
            return chats.Select(chat => new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                ChatItems = chat.ChatItems.Select(item => new ChatItemDto
                {
                    ChatId = item.ChatId,
                    SenderId = item.SenderId,
                    Message = item.Message,
                    Timestamp = item.Timestamp
                }).ToList()
            }).ToList();
        }

        public ChatDto? GetChatById(int id)
        {
            var chat = _chatRepository.GetChatById(id);
            if (chat == null)
            {
                return null;
            }
            return new ChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                ChatItems = chat.ChatItems.Select(item => new ChatItemDto
                {
                    ChatId = item.ChatId,
                    SenderId = item.SenderId,
                    Message = item.Message,
                    Timestamp = item.Timestamp
                }).ToList()
            };
        }

    }
}



