using Class_Programmation.DAL.Models;
using Class_Programmation.DAL.Models.Dtos;
using Class_Programmation.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class_Programmation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);

        }

        [HttpGet("{id:int}",Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
           var category= await _categoryService.GetCategoriesAsync(id);

          return Ok(category);
        }

        [HttpPost( Name = "CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody]CategoryCreateDto categoryCreateDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
                
            }
            try
            {
                var createCategory = await _categoryService.CreateCategoryAsync(categoryCreateDto);
                return CreatedAtRoute(
                        "GetCategoryAsync",
                        new {Id= createCategory.id},
                        createCategory
                    );
            }
            catch (InvalidOperationException ex)when (ex.Message.Contains("Ya existe")) 
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
