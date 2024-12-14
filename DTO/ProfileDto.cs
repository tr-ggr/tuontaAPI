using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.DTO
{
    public class ProfileDto
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Bio { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string Course { get; set; }

        public int Distance { get; set; }

        public List<string> Hobbies { get; set; }

        public List<string> ProfileImages { get; set; }


    }
}
