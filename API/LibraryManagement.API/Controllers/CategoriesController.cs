using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Services;
using LibraryManagement.Model.DTOs;
using LibraryManagement.Model;
using System.Web.Http.Results;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = await _categoryService.GetAll();

            if (categories != null && categories.Any()) return Ok(categories);

            return NotFound();        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Category? category = await _categoryService.GetById( new Guid(id));
            return category != null ? Ok(category) : NotFound();        
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto dto)
        {
            Category? category = await _categoryService.Create(dto);
            return category != null ? Ok(category) : new ObjectResult("Entity could not be created"){StatusCode = 500};        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto dto)
        {
            Category? category = await _categoryService.Update(dto);
            return category != null ? Ok(category) : new ObjectResult("Entity could not be created"){StatusCode = 500};        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            return Ok($"Delete, category {id}!");
        }
    }
}