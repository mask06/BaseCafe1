using BaseCafe.DAL.Entities.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL.Entities.Concrete
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string? AppUserID { get; set; }
        public string? AppUser {
            get;
            set;
        }

        public ICollection<OrderDetail> OrderDetails { get;set; }
    }
}
