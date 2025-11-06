using AutoMapper;
using Class_Programmation.DAL.Models;
using Class_Programmation.DAL.Models.Dtos;
using Class_Programmation.Repository.iRepository;
using Class_Programmation.Services.IServices;

namespace Class_Programmation.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;   
            _mapper = mapper;
        }

        public Task<bool> CategoryExistByidAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var categoesDto=_mapper.Map<ICollection<CategoryDto>>(categories);
            return categories;
        }

        public Task<Category> GetCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<CategoryDto>> ICategoryService.GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<CategoryDto> ICategoryService.GetCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
