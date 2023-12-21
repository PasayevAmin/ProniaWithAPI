using ProniaOnion.Application.Dtos.Categories;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<CategoryItemDto> GetAsync(int id);
        Task Create(CategoryCreateDto dto);
        Task Update(int id, Category category);
        Task Delete(int id);
    }
}
