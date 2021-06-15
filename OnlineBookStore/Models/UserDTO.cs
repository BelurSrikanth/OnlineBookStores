using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class UserDTO
    {
        [Key]
        public int UserID { get; set; }

        public string Username { get; set; }

    }
}
