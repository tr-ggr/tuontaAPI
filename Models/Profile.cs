using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class Profile
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public int Distance { get; set; }
        public List<string> Hobbies { get; set; }
        public List<string> ProfileImages { get; set; }

    }
}