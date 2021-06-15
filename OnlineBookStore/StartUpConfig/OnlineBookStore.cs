using Data.Services.Book;
using Microsoft.Extensions.DependencyInjection;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineBookStore.StartUpConfig
{
    public class OnlineBookStore
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
