using System;
using System.Collections.Generic;

namespace Team103.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int CategoryPk { get; set; }
        public string ProductCategoryName { get; set; }
        public string ImageFile { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
