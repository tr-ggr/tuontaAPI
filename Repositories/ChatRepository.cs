using Microsoft.EntityFrameworkCore;
using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly TuontaDbContext _context;

        public ChatRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<Chat> GetChats()
        {
            return _context.Chats.Include(c => c.ChatItems).ToList();
        }

        public List<Chat> GetChatsByUser1Id(int userId)
        {
            return _context.Chats
                .Include(c => c.ChatItems)
                .Where(c => c.User1Id == userId || c.User2Id == userId)
                .ToList();
        }

        public Chat? GetChatById(int id)
        {
            return _context.Chats
                .Include(c => c.ChatItems)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}



