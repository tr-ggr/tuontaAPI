using tuontaAPI.DTO;
using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public interface IChatItemRepository
    {
        List<ChatItem> GetChatItems();
        ChatItem? GetChatItemByChatId(int id);
        bool AddChatItem(ChatItem chatItem);

    }
}


