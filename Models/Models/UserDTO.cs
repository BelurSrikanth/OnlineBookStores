using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table(name: "Users")]
    public class UserDTO
    {
        [Key]
        public int UserID { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string Username { get; set; }

    }
}
