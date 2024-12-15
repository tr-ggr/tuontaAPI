using tuontaAPI.Interfaces;
using tuontaAPI.Models;

namespace tuontaAPI.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TuontaDbContext _context;

        public NotificationRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<Notification> GetAllNotification()
        {
           return _context.Notifications.ToList();
        }

        public List<Notification> GetNotificationByUserId(int userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .ToList();
        }

        public bool MakeNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            return _context.SaveChanges() > 0;
        }

        public bool ReadNotification(int id)
        {
            var existingNotification = _context.Notifications.FirstOrDefault(n => n.Id == id);
            if (existingNotification != null)
            {
                existingNotification.IsRead = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
