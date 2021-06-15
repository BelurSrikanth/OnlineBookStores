using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class ShoppingCartDTO
    {
        [ForeignKey("BookOrderID")]
        public virtual BookOrderDTO BookOrderID { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("CustmoerID")]
        public virtual CustmoerDTO CustmoerID { get; set; }
        
    }
}
