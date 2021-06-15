using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext.DBContext
{
    public class OnlineBookStoreContext : DbContext
    {


        public OnlineBookStoreContext(DbContextOptions<OnlineBookStoreContext> options)
        : base(options)
        {

        }
        //protected override void Onconfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}
        public DbSet<UserDTO> User { get; set; }
        public DbSet<AdministratorDTO> Administrator { get; set; }
        public DbSet<CustmoerDTO> Custmoer { get; set; }
        public DbSet<BookDTO> Books { get; set; }
        public DbSet<BookOrderDTO> BookOrder { get; set; }
        public DbSet<ShoppingCartDTO> ShoppingCart { get; set; }


    }
}
