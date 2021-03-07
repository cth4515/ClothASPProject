using System;
using System.Collections.Generic;

namespace Team103.Models
{
    public partial class TblOrderLine
    {
        public int OrderLinePk { get; set; }
        public int OrderFk { get; set; }
        public int ProductFk { get; set; }
        public int OrderQuantity { get; set; }

        public virtual TblOrder OrderFkNavigation { get; set; }
        public virtual TblProduct ProductFkNavigation { get; set; }
    }
}
