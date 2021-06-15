using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Book
{
   public interface IBookRepository
    {
        Task<List<BookDTO>> GetBookAsync(BookDTO book);
        Task<BookDTO> GetBookByIDAsync(BookDTO book);
        Task<string> SaveBookAsync(BookDTO book);
        Task<string> DelBookAsync(BookDTO book);
        Task<string> UpdateBookAsync(BookDTO book);
       
    }
}
