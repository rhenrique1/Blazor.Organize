using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Shared.Entities
{
    public class User
    {
        [Required]
        [StringLength(10, ErrorMessage = "Username is too long.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required!")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
