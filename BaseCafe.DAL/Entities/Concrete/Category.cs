using BaseCafe.DAL.Entities.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string  Name{ get; set; }
        public string  Description{ get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
