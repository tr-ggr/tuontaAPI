using tuontaAPI.DTO;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface INotificationService
    {
        public List<NotificationDto> GetAllNotification();
        public List<NotificationDto> GetNotificationByUserId(int id);
        public bool MakeNotification(NotificationDto notificationDto);
        public bool ReadNotification(int id);

    }
}
