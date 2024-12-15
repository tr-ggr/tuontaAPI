﻿namespace tuontaAPI.DTO
{
    public class NotificationDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public string Type { get; set; }
        public string ReferenceId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}