using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Services;
using LibraryManagement.Model.DTOs;
using LibraryManagement.Model;


namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    [Authorize]
    public class AuthorsController : ControllerBase
    {

        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            IEnumerable<Author> authors = await _authorService.GetAll();

            if (authors != null && authors.Any()) return Ok(authors);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok($"Author {id}!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AddAuthorDto newAuthor)
        {
            Author author = await _authorService.Create(newAuthor);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            return Ok($"Updating an Author {id}!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorById(int id)
        {
            return Ok($"Delete, Author {id}!");
        }
    }
}