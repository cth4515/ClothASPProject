using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Team103.Models
{
    public class UserProfile
    {
        public int UserPk { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Valid characters are a-z 0-9")]
        [UIHint("password")]
        [MaxLength(20)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Enter a valid email((xxx@xxx.xxx)")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression(@"^(\d{3}-)?\d{3}-\d{4}$", ErrorMessage = "Enter a valid phone number (xxx-xxx-xxxx)")]
        [MaxLength(12)]
        public string Phone { get; set; }
    }
}
