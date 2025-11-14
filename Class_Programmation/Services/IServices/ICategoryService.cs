using Class_Programmation.DAL.Models;
using Class_Programmation.DAL.Models.Dtos;

namespace Class_Programmation.Services.IServices
{
    public interface ICategoryService
    {

        Task<ICollection<CategoryDto>> GetCategoriesAsync();//me retorna una lista de categoria
        Task<CategoryDto> GetCategoryAsync(int id);//me retorna una categoria por su id

        Task<bool> CategoryExistByidAsync(int id);

        Task<bool> CategoryExistByNameAsync(string name);

        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);

        Task<bool> updateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
