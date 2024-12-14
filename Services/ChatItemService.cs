using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Repositories;
using tuontaAPI.Models;


namespace tuontaAPI.Services
{
    public class ChatItemService : IChatItemService
    {
        private readonly IChatItemRepository _chatItemRepository;

        public ChatItemService(IChatItemRepository chatItemRepository)
        {
            _chatItemRepository = chatItemRepository;
        }

        public List<ChatItemDto> GetChatItems()
        {
            var chatItems = _chatItemRepository.GetChatItems();
            return chatItems.Select(item => new ChatItemDto
            {
                ChatId = item.ChatId,
                SenderId = item.SenderId,
                Message = item.Message,
                Timestamp = item.Timestamp
            }).ToList();
        }

        public ChatItemDto? GetChatItem(int id)
        {
            var chatItem = _chatItemRepository.GetChatItemByChatId(id);
            if (chatItem == null)
            {
                return null;
            }
            return new ChatItemDto
            {
                ChatId = chatItem.ChatId,
                SenderId = chatItem.SenderId,
                Message = chatItem.Message,
                Timestamp = chatItem.Timestamp
            };
        }

        public bool AddChatItem(ChatItemDto chatItemDto)
        {
            var chatItem = new ChatItem
            {
                ChatId = chatItemDto.ChatId,
                SenderId = chatItemDto.SenderId,
                Message = chatItemDto.Message,
                Timestamp = chatItemDto.Timestamp
            };
            return _chatItemRepository.AddChatItem(chatItem);
        }


    }
}


