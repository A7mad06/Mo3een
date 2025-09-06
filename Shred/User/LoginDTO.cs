using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User
{
    public class LoginDTO
    {
        [Required]
        public string EmailOrPhone { get; set;} = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set;} = null!;
    }
}
