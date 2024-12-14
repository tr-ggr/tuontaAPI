using System;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class ChatItem
    {

        public int Id { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public Chat? Chat { get; set; }
    }
}
