using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tuontaAPI.DTO
{
    public class VerifyIdentityDto
    {

        public int? Id { get; set; }

        public bool? isApproved { get; set; }
        public int UserID { get; set; }
    }
}