using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public ActionResult<List<NotificationDto>> GetAllNotifications()
        {
            var notifications = _notificationService.GetAllNotification();
            return Ok(notifications);
        }

        [HttpGet("{userId}")]
        public ActionResult<List<NotificationDto>> GetNotificationsByUserId(int userId)
        {
            var notifications = _notificationService.GetNotificationByUserId(userId);
            if (notifications == null || notifications.Count == 0)
            {
                return NotFound();
            }
            return Ok(notifications);
        }

        [HttpPost]
        public ActionResult<bool> CreateNotification([FromBody] NotificationDto notificationDto)
        {
            var result = _notificationService.MakeNotification(notificationDto);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("There was an error lmao");
        }

        [HttpPut("{id}")]
        public ActionResult<bool> MarkNotificationAsRead(int id)
        {
            var result = _notificationService.ReadNotification(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}


