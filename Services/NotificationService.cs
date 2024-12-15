using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using tuontaAPI.Repositories;

namespace tuontaAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public List<NotificationDto> GetAllNotification()
        {
            var notifications = _notificationRepository.GetAllNotification();
            return notifications.Select(notification => new NotificationDto
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Title = notification.Title,
                Message = notification.Message,
                IsRead = notification.IsRead,
                Type = notification.Type,
                ReferenceId = notification.ReferenceId,
                DateCreated = notification.DateCreated
            }).ToList();
        }

        public List<NotificationDto> GetNotificationByUserId(int id)
        {
            var notifications = _notificationRepository.GetNotificationByUserId(id);
            return notifications.Select(notification => new NotificationDto
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Title = notification.Title,
                Message = notification.Message,
                IsRead = notification.IsRead,
                Type = notification.Type,
                ReferenceId = notification.ReferenceId,
                DateCreated = notification.DateCreated
            }).ToList();
        }

        public bool MakeNotification(NotificationDto notificationDto)
        {

            var notification = new Notification
            {
                UserId = (int)notificationDto.UserId,
                Title = notificationDto.Title,
                Message = notificationDto.Message,
                IsRead = notificationDto.IsRead,
                Type = notificationDto.Type,
                ReferenceId = notificationDto.ReferenceId,
                DateCreated = notificationDto.DateCreated
            };
            return _notificationRepository.MakeNotification(notification);
        }

        public bool ReadNotification(int id)
        {
            return _notificationRepository.ReadNotification(id);
        }
    }
}
