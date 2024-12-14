using tuontaAPI.DTO;

namespace tuontaAPI.Interfaces
{
    public interface IChatItemService
    {
        List<ChatItemDto> GetChatItems();
        ChatItemDto? GetChatItem(int id);
        bool AddChatItem(ChatItemDto chatItemDto);
    }
}


