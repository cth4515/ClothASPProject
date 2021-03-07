using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Team103.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblOrderLine = new HashSet<TblOrderLine>();
        }

        public int ProductPk { get; set; }
        public int CategoryFk { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a product description")]
        [MaxLength(2000)]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Please enter a unit price")]
        [Range(10, 1000, ErrorMessage = "Please enter an amount between 10 and 1000")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please enter the number in stock")]
        [Range(1, 1000, ErrorMessage = "Please enter an amount between 1 and 1000")]
        public int OnHand { get; set; }

        [Required(ErrorMessage = "Please enter a file name for product image")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9]+.(jpg)$", ErrorMessage = "Please enter a valid jpg file name")]
        public string ImageFile { get; set; }

        [Required(ErrorMessage = "Please enter the size of product")]
        [MaxLength(3)]
        public string Size { get; set; }

        [Required(ErrorMessage = "Please enter the color of product")]
        [MaxLength(10)]
        public string Color { get; set; }

        public virtual TblCategory CategoryFkNavigation { get; set; }
        public virtual ICollection<TblOrderLine> TblOrderLine { get; set; }
    }
}
