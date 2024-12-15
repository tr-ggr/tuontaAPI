using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IChatSessionMessageService
    {
        List<SessionChatMessageDto> GetChatSessionMessages();
        List<SessionChatMessageDto> GetChatSessionMessagesBySessionId(int sessionId);
        SessionChatMessageDto GetChatSessionMessageById(int id);
    }
}