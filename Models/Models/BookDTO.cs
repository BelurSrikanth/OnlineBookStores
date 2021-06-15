using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table(name: "Books")]
    public class BookDTO
    {
        [Key]
        public int BookID { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string BookName { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string Author { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        public string Description { get; set; }

        [Column(TypeName = "DECIMAL(18,5)")]
        public decimal Price { get; set; }

    }
}
