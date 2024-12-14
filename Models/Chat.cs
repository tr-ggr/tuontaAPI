using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class Chat
    {

        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<ChatItem>? ChatItems { get; set; } = new List<ChatItem>();

    }
}
