using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Services
{
    public class SessionChatMessageService : ISessionChatMessageService
    {
        private readonly ISessionChatMessageRepository _sessionChatMessageRepository;

        public SessionChatMessageService(ISessionChatMessageRepository sessionChatMessageRepository)
        {
            _sessionChatMessageRepository = sessionChatMessageRepository;
        }

        public List<SessionChatMessage> GetSessionChatMessages()
        {
            return _sessionChatMessageRepository.GetSessionChatMessages();
        }

        public SessionChatMessage? GetSessionChatMessageById(int id)
        {
            return _sessionChatMessageRepository.GetSessionChatMessageById(id);
        }

        public List<SessionChatMessage> GetSessionChatMessagesBySessionId(int sessionId)
        {
            return _sessionChatMessageRepository.GetSessionChatMessagesBySessionId(sessionId);
        }

        public bool AddSessionChatMessage(SessionChatMessage sessionChatMessage)
        {
            return _sessionChatMessageRepository.AddSessionChatMessage(sessionChatMessage);
        }
    }
}
