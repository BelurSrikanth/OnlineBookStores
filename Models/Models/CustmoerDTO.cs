using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table(name: "Customers")]
    public class CustmoerDTO
    {
        [Key]
        public int CustmoerID { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string Address { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
