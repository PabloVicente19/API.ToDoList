using API.ToDoList.API.DTOs.CategoryDTOs;
using API.ToDoList.API.Repositories.Interfaces;
using API.ToDoList.API.Services.Interfaces;
using API.ToDoList.Shared;

namespace API.ToDoList.API.Services
{
    public class CategoryService : ICommonService<CategoryDto, CategoryInsertDto, CategoryUpdateDto >
    {
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            var categoriesDto = categories.Select(cat => new CategoryDto
            {
                Id = cat.Id,
                Name = cat.Name
            });
            return categoriesDto;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDto;
        }
        public async Task<CategoryDto> InsertAsync(CategoryInsertDto categoryInsertDto)
        {
            var category = new Category
            {
                Name = categoryInsertDto.Name
            };
            await _repository.AddAsync(category);

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDto;
        }
        public async Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto categoryInsertDto)
        {
            var category = new Category
            {
                Id = id,
                Name = categoryInsertDto.Name
            };
            await _repository.UpdateAsync(category);
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDto;
        }
        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            await _repository.DeleteAsync(id);
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryDto;
        }
    }
}
