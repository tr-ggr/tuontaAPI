using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using tuontaAPI.DTO;
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

        public Chat? UpdateMatchStatus(int id, ChatItem chatItem)
        {
            var existingMatch = _context.MatchedItems.FirstOrDefault(ms => ms.Id == id);
            if (existingMatch != null)
            {
                existingMatch.isActive = false;
                bool isSaved = _context.SaveChanges() > 0;

                if (isSaved)
                {
                    // Get the foreign keys of the matched item
                    var matchStatus1 = _context.MatchStatuses.FirstOrDefault(ms => ms.Id == existingMatch.MatchStatus1Id);
                    var matchStatus2 = _context.MatchStatuses.FirstOrDefault(ms => ms.Id == existingMatch.MatchStatus2Id);

                    if (matchStatus1 != null && matchStatus2 != null)
                    {
                        // Create a new Chat object
                        var chat = new Chat
                        {
                            User1Id = matchStatus1.user1Id,
                            User2Id = matchStatus1.user2Id,
                            CreatedAt = DateTime.Now,
                            ChatItems = new List<ChatItem>()
                        };

                        _context.Chats.Add(chat);
                        _context.SaveChanges(); // Save to get the new Chat Id

                        int chatId = _context.Chats.Max(c => c.Id);

                        // Create a new ChatItem
                        var newChatItem = new ChatItem
                        {
                            ChatId = chatId,
                            SenderId = chatItem.SenderId,
                            Message = chatItem.Message,
                            Timestamp = chatItem.Timestamp
                        };

                        chat.ChatItems.Add(newChatItem);
                        _context.ChatItems.Add(newChatItem);
                        _context.SaveChanges();
                        return chat;
                    }
                }
            }
            return null;
        }

        public List<Profile> GetUsersOfMatchedItem(int id)
        {
            var matchedItem = _context.MatchedItems.FirstOrDefault(ms => ms.Id == id);
            if (matchedItem != null)
            {
                var matchStatus = _context.MatchStatuses.FirstOrDefault(ms => ms.Id == matchedItem.MatchStatus1Id);

                var user1 = _context.Profiles.FirstOrDefault(p => p.Id == matchStatus.user1Id);
                var user2 = _context.Profiles.FirstOrDefault(p => p.Id == matchStatus.user2Id);

                if (user1 != null && user2 != null)
                {
                    return new List<Profile> { user1, user2 };
                }
            }
            return new List<Profile>();
        }



    }
}
