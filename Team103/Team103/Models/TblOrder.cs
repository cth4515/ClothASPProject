using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team103.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderLine = new HashSet<TblOrderLine>();
        }

        public int OrderPk { get; set; }
        public int UserFk { get; set; }
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Valid characters are a-z 0-9 and space")]
        public string ShipStreet { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Valid characters are a-z 0-9 and space")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        [MaxLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "U.S.state abbreviations")]
        public string ShipState { get; set; }

        [Required(ErrorMessage = "Please enter the zip code")]
        [MaxLength(5)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "5 digit zip code")]
        public string ShipZip { get; set; }

        public virtual TblUser UserFkNavigation { get; set; }
        public virtual ICollection<TblOrderLine> TblOrderLine { get; set; }
    }
}
