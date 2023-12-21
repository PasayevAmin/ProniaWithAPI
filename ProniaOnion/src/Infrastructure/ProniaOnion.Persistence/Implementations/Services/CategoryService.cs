using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Categories;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryItemDto> GetAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("not Found");
            return new CategoryItemDto(category.Id, category.Name);


        }

        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAll(skip: (page - 1) * take, take: take).ToListAsync();

            return _mapper.Map<ICollection<CategoryItemDto>>(categories);
            
        }

        public async Task Create(CategoryCreateDto dto)
        {
            await _repository.AddAsync(_mapper.Map<Category>(dto));
           
            await _repository.SaveChangesAsync();
        }

        public async Task Update(int id, Category category)
        {
            Category existed = await _repository.GetByIdAsync(id);

            existed.Name = category.Name;
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Category existed = await _repository.GetByIdAsync(id);
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
