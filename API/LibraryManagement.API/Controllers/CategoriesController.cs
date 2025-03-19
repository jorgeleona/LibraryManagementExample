using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Model;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
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
        public async Task<IActionResult> AddCategory([FromBody] Author newAuthor)
        {
            return Ok($"Inserting a category");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Book author)
        {
            return Ok($"Updating an category {id}!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            return Ok($"Delete, category {id}!");
        }
    }
}