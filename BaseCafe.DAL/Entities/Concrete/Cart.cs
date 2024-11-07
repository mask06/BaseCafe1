using BaseCafe.DAL.Entities.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL.Entities.Concrete
{
    public class Cart:BaseEntity
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
