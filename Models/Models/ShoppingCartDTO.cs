using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table(name: "ShopingCart")]
    public class ShoppingCartDTO
    {
        [Key]
        public int ShoppingCartID { get; set; }
        [ForeignKey("BookOrderID")]
        public int  BookOrderID { get; set; }
        [Column(TypeName = "DECIMAL(18,5)")]
        public decimal Price { get; set; }
        [ForeignKey("CustmoerID")]
        public int  CustmoerID { get; set; }
        
    }
}
