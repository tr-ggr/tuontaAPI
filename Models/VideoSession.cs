using System;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class VideoSession
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionCreator { get; set; }
        public int ParticipantCount { get; set; }
        public bool GroupType { get; set; }
        
    }
}
