using System;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class Participant
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? VideoUrl { get; set; }
        public string? Role { get; set; }
        public int userId { get; set; }

    }
}
