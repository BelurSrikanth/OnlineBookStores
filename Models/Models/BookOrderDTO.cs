using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table(name: "BookOrders")]
    public class BookOrderDTO
    {
        [Key]
        public int BookOrderID { get; set; }
        [Column(TypeName = "DECIMAL(18,5)")]
        public decimal Price { get; set; }
        [Column(TypeName = "DECIMAL(18,5)")]
        public decimal Quantity { get; set; }
        [ForeignKey("CustmoerID")]
        public int  CustmoerID { get; set; }
        [ForeignKey("BookID")]
        public int  BookID { get; set; }
    }
}
