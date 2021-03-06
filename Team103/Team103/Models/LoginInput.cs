using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Team103.Models
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Please enter a username")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [UIHint("password")]
        [MaxLength(20)]
        public string UserPassword { get; set; }

        public string ReturnURL { get; set; }
    }
}
