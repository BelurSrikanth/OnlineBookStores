using Data.Services.DBContext;
using Models.Models;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Services.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly OnlineBookStoreContext _context;

        public BookRepository(OnlineBookStoreContext context)
        {
            _context = context;
        }

        public  async Task<string> DelBookAsync(BookDTO book)
        {
            try
            {
                var data = _context.Books.FirstOrDefault(x => x.BookID == book.BookID);
                if (data != null)
                {
                    _context.Books.Remove(data);
                    _context.SaveChanges();
                    
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BookDTO>> GetBookAsync(BookDTO book)
        {
            try
            {
                var data=  _context.Books.ToList();
                return  data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BookDTO> GetBookByIDAsync(BookDTO book)
        {
            try
            {
                return _context.Books.SingleOrDefault(st => st.BookID == book.BookID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> SaveBookAsync(BookDTO book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateBookAsync(BookDTO book)
        {
            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
