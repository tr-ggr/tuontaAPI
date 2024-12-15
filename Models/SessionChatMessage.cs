using System;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class SessionChatMessage
    {

        public int Id { get; set; }
        public string SenderName { get; set; }
        public string? SenderAvatar { get; set; }
        public string Content { get; set; }

    }
}
