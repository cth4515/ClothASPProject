using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Team103.Models
{
    public class CartItem
    {
        public TblProduct Product { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        [Range(1, 100, ErrorMessage = "Please enter an amount between 1 and 100")]
        public int Quantity { get; set; }
    }
}
