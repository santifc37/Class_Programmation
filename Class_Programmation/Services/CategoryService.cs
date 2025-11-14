using AutoMapper;
using Class_Programmation.DAL.Models;
using Class_Programmation.DAL.Models.Dtos;
using Class_Programmation.Repository;
using Class_Programmation.Repository.iRepository;
using Class_Programmation.Services.IServices;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> CategoryExistByidAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            var categoryExist = await _categoryRepository.CategoryExistByNameAsync(categoryCreateDto.name);

            if (categoryExist) {
                throw new InvalidOperationException($"Ya existe una categoria  con el nombre '{categoryCreateDto.name}'");
            }

            var category= _mapper.Map<Category>(categoryCreateDto); 

            var  categoryCreated=await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated) {
                throw new InvalidOperationException("Ocurrió un error al crear");
            }

            var categoryDto=_mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

       

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

       


        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //Solo estoy llamando el método desde la capa de Repository

            return _mapper.Map<ICollection<CategoryDto>>(categories); //Mapeo la lista de categorías a una lista de categorías DTO
        }
        public async Task<bool> updateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }


        public async Task<CategoryDto> GetCategoryAsync(int id) {
            var category = await _categoryRepository.GetCategoryAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
