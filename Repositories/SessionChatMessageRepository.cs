using tuontaAPI.Models;
using tuontaAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace tuontaAPI.Repositories
{
    public class SessionChatMessageRepository : ISessionChatMessageRepository
    {
        private readonly TuontaDbContext _context;

        public SessionChatMessageRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<SessionChatMessage> GetSessionChatMessages()
        {
            return _context.SessionChatMessages.ToList();
        }

        public SessionChatMessage? GetSessionChatMessageById(int id)
        {
            return _context.SessionChatMessages.FirstOrDefault(scm => scm.Id == id);
        }

        public List<SessionChatMessage> GetSessionChatMessagesBySessionId(int sessionId)
        {
            return _context.SessionChatMessages.Where(scm => scm.Id == sessionId).ToList();
        }

        public bool AddSessionChatMessage(SessionChatMessage sessionChatMessage)
        {
            _context.SessionChatMessages.Add(sessionChatMessage);
            _context.SaveChanges();
            return true;
        }
    }
}
