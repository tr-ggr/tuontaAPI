using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class ParticipantDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? VideoUrl { get; set; }
        public string? Role { get; set; }
        public int? UserId { get; set; }
    }

}
