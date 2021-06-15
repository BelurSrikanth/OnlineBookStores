using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Models
{
    [Table(name:"Administrator")]
    public class AdministratorDTO
    {
        [Key]
        public int AdministratorID { get; set; }

        [Column(TypeName ="NVARCHAR(100)")]
        public string AdministratorName { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Address { get; set; }

        [Column(TypeName = "NVARCHAR(32)")]
        public string Email { get; set; }

       
        public int PhoneNumber { get; set; }
    }
}
