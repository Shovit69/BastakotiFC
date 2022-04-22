using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShovitBastakoti.Models
{
    public class Role : IdentityRole
    {
        [Required]
        [MinLength(3, ErrorMessage = "Role must be at least 3 characters")]
        public string? RoleName { get; set; }
    }
}
