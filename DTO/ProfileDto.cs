using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.DTO
{
    public class ProfileDto
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string? Bio { get; set; }
        public string School { get; set; }
        public string Role { get; set; }
        public string? Password { get; set; }
        public string Course { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public int? Distance { get; set; }
        public List<string>? Hobbies { get; set; }
        public List<string>? ProfileImages { get; set; }


    }
}
