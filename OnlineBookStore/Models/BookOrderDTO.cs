using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class BookOrderDTO
    {
        [Key]
        public int BookOrderID { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("CustmoerID")]
        public virtual CustmoerDTO CustmoerID { get; set; }
        [ForeignKey("BookID")]
        public virtual BookDTO BookID { get; set; }
    }
}
