using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team103.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrder = new HashSet<TblOrder>();
        }

        public int UserPk { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Valid characters are a-z 0-9")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Valid characters are a-z 0-9")]
        [UIHint("password")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Upper and lower case letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Upper and lower case letters")]
        public string LastName { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [MaxLength(50)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Enter a valid email((xxx@xxx.xxx)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [MaxLength(12)]
        [RegularExpression(@"^(\d{3}-)?\d{3}-\d{4}$", ErrorMessage = "Enter a valid phone number (xxx-xxx-xxxx)")]
        public string Phone { get; set; }

        public virtual ICollection<TblOrder> TblOrder { get; set; }
    }
}
