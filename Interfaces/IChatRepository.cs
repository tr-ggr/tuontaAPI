using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public interface IChatRepository
    {
        List<Chat> GetChats();
        List<Chat> GetChatsByUser1Id(int id);
        Chat? GetChatById(int id);
    }
}



