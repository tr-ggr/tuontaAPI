using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.Models
{
    public class VerifyIdentity
    {

        public int Id { get; set; }

        public bool IsApproved { get; set; } = false;
        
        public int UserID { get; set; }
    }
}