using CrudWebApiPlusUnitTests.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebApiPlusUnitTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book{ Id = 1, Title = "Game of Thrones", Author = "George R. R. Martin", Genre ="Action · Adventure · Fantasy · Serial drama", Price=200},
            new Book{ Id = 2, Title = "The Lord of the Rings", Author = "John Ronald Reuel Tolkien", Genre = "Fantasy", Price = 100}
        };

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetSingleBook(int id)
        {
            var book = books.Find(n => n.Id == id);
            if (book == null)
                return BadRequest("Error. Book with this id, doesnt exist");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook([FromBody]Book book)
        {
            books.Add(book);
            return Ok(books);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(Book requet)
        {
            var book = books.Find(n => n.Id == requet.Id);
            if (book == null)
                return BadRequest();
            book.Title = requet.Title;
            book.Author = requet.Author;
            book.Genre = requet.Genre;
            book.Price = requet.Price;
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> Delete(int id)
        {
            var book = books.Find(n => n.Id==id);
            if(book== null)
                return BadRequest();
            books.Remove(book);
            return Ok(books);
        }
    }
}
