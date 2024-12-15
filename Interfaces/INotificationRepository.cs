using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface INotificationRepository
    {
        public List<Notification> GetAllNotification();
        public List<Notification> GetNotificationByUserId(int id);
        public bool MakeNotification(Notification notification);
        public bool ReadNotification(int id);
    }
}
