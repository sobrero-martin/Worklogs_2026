using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.Shared.ENUM;

namespace Worklogs_2026.BD.Data.Entities
{
    [Index(nameof(Email), Name = "User_Email_UQ", IsUnique = true)]
    public class UserTest : BaseEntity
    {

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "The email address must not exceed {1} characters.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password hash is required.")]
        [MaxLength(256, ErrorMessage = "The password hash is too long.")]
        public required string PasswordHash { get; set; }

        [Required(ErrorMessage = "The role is required.")]
        public required EnumRoles Role { get; set; } 

        [Required(ErrorMessage = "The full name is required.")]
        [MaxLength(50, ErrorMessage = "The full name must not exceed {1} characters.")]
        public required string FullName { get; set; }
    }
}
