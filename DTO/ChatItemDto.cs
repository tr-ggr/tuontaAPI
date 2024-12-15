using System;

namespace tuontaAPI.DTO
{
    public class ChatItemDto
    {
        public int? ChatId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}


