using tuontaAPI.DTO;
using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public interface IMatchRepository
    {
        public List<MatchedItem> GetMatches();
        public List<MatchedItem> GetMatchedItemsByUserId(int userId);
        public List<MatchStatus> GetAllMatchStatus();

        public bool CreateMatchStatus(MatchStatus matchStatus);
        public Chat UpdateMatchStatus(int id, ChatItem chatItem);
        public List<Profile> GetUsersOfMatchedItem(int id);
    }
}
