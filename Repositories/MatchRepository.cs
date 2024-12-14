using System.Linq;
using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly TuontaDbContext _context;

        public MatchRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<MatchedItem> GetMatches()
        {
            return _context.MatchedItems.ToList();
        }
        public List<MatchStatus> GetAllMatchStatus()
        {
            return _context.MatchStatuses.ToList();
        }

        public List<MatchedItem> GetMatchedItemsByUserId(int userId)
        {
            var matchStatuses = _context.MatchStatuses
                .Where(ms => ms.user1Id == userId || ms.user2Id == userId)
                .Select(ms => ms.Id)
                .ToList();

            var matchedItems = _context.MatchedItems
                .Where(mi => matchStatuses.Contains((int)mi.MatchStatus1Id) || matchStatuses.Contains((int)mi.MatchStatus2Id))
                .ToList();

            return matchedItems;
        }

        public bool CreateMatchStatus(MatchStatus matchStatus)
        {
            _context.MatchStatuses.Add(matchStatus);
            bool isSaved = _context.SaveChanges() > 0;

            if (isSaved)
            {
                // Check for bidirectional relationship
                var existingMatch = _context.MatchStatuses
                    .FirstOrDefault(ms => ms.user1Id == matchStatus.user2Id && ms.user2Id == matchStatus.user1Id);

                if (existingMatch != null)
                {

                    // Create a new MatchedItem
                    MatchedItem matchedItem = new MatchedItem
                    {
                        MatchStatus1Id = matchStatus.Id,
                        MatchStatus2Id = existingMatch.Id,
                        date_matched = DateTime.Now
                    };

                    _context.MatchedItems.Add(matchedItem);
                    _context.SaveChanges();
                }
            }

            return isSaved;
        }
    }
}
