using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Models;


using Repository.Book;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookRepository _iBookRepository;

        public BookController( IBookRepository iBookRepository)
        {
            
           
            _iBookRepository = iBookRepository;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<List<BookDTO>>  GetBooks()
        {
            try
            {
                //  return _context.Books;
                BookDTO bookDTO = new BookDTO();
                var books =await _iBookRepository.GetBookAsync(bookDTO);
                return books;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<BookDTO> GetBookByIDAsync(int id)
        {
            try
            {
                BookDTO bookDTO = new BookDTO();
                bookDTO.BookID = id;
                var books = await _iBookRepository.GetBookByIDAsync(bookDTO);
                return books;
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult> SaveBooks([FromBody] BookDTO book)
        {
            try
            {
               
                var result = await _iBookRepository.SaveBookAsync(book);
                if (result == null )
                    return Ok();
                else
                    return BadRequest (result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBooks(int id, [FromBody] BookDTO book)
        {
            try
            {
               
                var result = await _iBookRepository.UpdateBookAsync(book);
                if (result == null)
                    return Ok();
                else
                    return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                BookDTO bookDTO = new BookDTO();
                bookDTO.BookID = id;
                var result = await _iBookRepository.DelBookAsync(bookDTO);
                if (result == null)
                    return Ok();
                else
                    return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
