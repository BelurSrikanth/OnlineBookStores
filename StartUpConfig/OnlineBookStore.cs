using Data.Services.Book;
using Microsoft.Extensions.DependencyInjection;
using Repository.Book;
using System;

namespace StartUpConfig
{
    public class OnlineBookStore
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
        }
    }
}
