using System;
using System.Collections.Generic;

namespace tuontaAPI.DTO
{
    public class ChatDto
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ChatItemDto> ChatItems { get; set; } = new List<ChatItemDto>();
    }
}


