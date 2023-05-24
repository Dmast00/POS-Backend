using Microsoft.AspNetCore.Mvc;
using POS.Application.Dtos.Request;
using POS.Application.Interfaces;
using POS.Infrastructure.Commons.Bases.Request;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
        {
            var response = await _categoryApplication.ListCategory(filters);
            return Ok(response);    
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategory()
        {
            var response = await _categoryApplication.ListSelectCategories();

            return Ok(response);    
        }

        [HttpGet("category:int")]
        public async Task<IActionResult> CategoryById(int categoryId)
        {
            var response = await _categoryApplication.CategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequest categorie)
        {
            var response = await _categoryApplication.RegisterCategory(categorie);
            return Ok(response);
        }

        [HttpPut("Edit/CategoryId:int")]
        public async Task<IActionResult> EditCategory(int CategoryId, [FromBody] CategoryRequest categorie)
        {
            var response = await _categoryApplication.EditCategory(CategoryId , categorie);
            return Ok(response);
        }

        [HttpDelete("Delete/CategoryId:int")]
        public async Task<IActionResult> DeleteCategory(int CategoryId, [FromBody] CategoryRequest categorie)
        {
            var response = await _categoryApplication.RemoveCategory(CategoryId);
            return Ok(response);
        }
    }
}
