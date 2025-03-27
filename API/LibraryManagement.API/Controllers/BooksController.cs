using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Services;
using LibraryManagement.Model.DTOs;
using LibraryManagement.Model;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Book> books = await _bookService.GetAll();

            if (books != null && books.Any()) return Ok(books);

            return NotFound();        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Book? book = await _bookService.GetById( new Guid(id));
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto newBook)
        {
            Book? book = await _bookService.Create(newBook);
            return book != null ? Ok(book) : new ObjectResult("Entity could not be created"){StatusCode = 500};        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            Book? book = await _bookService.Update(dto);
            return book != null ? Ok(book) : new ObjectResult("Entity could not be updated"){StatusCode = 500};
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            return Ok($"Delete, book {id}!");
        }
    }
}