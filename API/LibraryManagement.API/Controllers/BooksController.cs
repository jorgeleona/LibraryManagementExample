using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Model;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok($"Get all books!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok($"Get {id}!");
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Author newAuthor)
        {
            return Ok($"Inserting an book");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book author)
        {
            return Ok($"Updating an book {id}!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            return Ok($"Delete, book {id}!");
        }
    }
}