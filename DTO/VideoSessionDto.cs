using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class VideoSessionDto
    {
        public int? Id { get; set; }
        public string SessionName { get; set; }
        public string SessionCreator { get; set; }
        public int ParticipantCount { get; set; }
        public bool GroupType { get; set; }

    }

}
