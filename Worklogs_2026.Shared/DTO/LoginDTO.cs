using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Shared.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "The email address must not exceed {1} characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(256, ErrorMessage = "The password is too long.")]
        public string Password { get; set; } = string.Empty; 
        
    }
}
