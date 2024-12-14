using tuontaAPI.DTO;

namespace tuontaAPI.Interfaces
{
    public interface IChatService
    {
        List<ChatDto> GetChats();
        public List<ChatDto> GetChatsByUser1Id(int userId);
        ChatDto? GetChatById(int id);
    }
}



