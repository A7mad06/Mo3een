using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User
{
    public class RegisterDTO
    {
        [Required]
        public string CaseCategory { get; init; } = null!;
        [MaxLength(500)]
        public string? About { get; init; }
        [Required]
        public bool TermsAndConditions { get; init; }
        [Required]
        public string Plan { get; init; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, DataType(DataType.Password)]
        public string Password { get; init; } = null!;
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
        [Required,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; init; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
    }
}
