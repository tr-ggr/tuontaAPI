using Microsoft.EntityFrameworkCore;
using tuontaAPI.Models;
using Microsoft.Identity.Client;

namespace tuontaAPI
{
    public class TuontaDbContext : DbContext
    {
        public TuontaDbContext(DbContextOptions<TuontaDbContext> options) : base(options)
        {
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatItem> ChatItems { get; set; }

        public DbSet<MatchStatus> MatchStatuses { get; set; }
        public DbSet<MatchedItem> MatchedItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<VideoSession> VideoSessions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<SessionChatMessage> SessionChatMessages { get; set; }
    }
}
