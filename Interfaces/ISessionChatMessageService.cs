using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface ISessionChatMessageService
    {
        List<SessionChatMessage> GetSessionChatMessages();
        SessionChatMessage? GetSessionChatMessageById(int id);
        List<SessionChatMessage> GetSessionChatMessagesBySessionId(int sessionId);
        bool AddSessionChatMessage(SessionChatMessage sessionChatMessage);
    }
}
