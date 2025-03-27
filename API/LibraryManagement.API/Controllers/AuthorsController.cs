using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Services;
using LibraryManagement.Model.DTOs;
using LibraryManagement.Model;
using System.Web.Http.Results;


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
        public async Task<IActionResult> GetById(string id)
        {
            Author? author = await _authorService.GetById( new Guid(id));
            return author != null ? Ok(author) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AddAuthorDto newAuthor)
        {
            Author? author = await _authorService.Create(newAuthor);
            return author != null ? Ok(author) : new ObjectResult("Entity could not be created"){StatusCode = 500};
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto toUpdate)
        {
            
            Author? author = await _authorService.Update(toUpdate);
            return author != null ? Ok(author) : new ObjectResult("Entity could not be updated"){StatusCode = 500};

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorById(int id)
        {
            return Ok($"Delete, Author {id}!");
        }
    }
}