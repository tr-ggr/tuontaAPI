using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public class ChatItemRepository : IChatItemRepository
    {
        private readonly TuontaDbContext _context;

        public ChatItemRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<ChatItem> GetChatItems()
        {
            return _context.ChatItems.ToList();
        }

        public ChatItem? GetChatItemByChatId(int id)
        {
            return _context.ChatItems.FirstOrDefault(ci => ci.ChatId == id);
        }

        public bool AddChatItem(ChatItem chatItem)
        {
            _context.ChatItems.Add(chatItem);
            _context.SaveChanges();
            return true;
        }

    }
}


