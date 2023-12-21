using ProniaOnion.Application.Dtos.Product;
using ProniaOnion.Application.Dtos.Tag;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<ICollection<ProductItemDto>> GetAllAsync(int page, int take);
        Task<ProductItemDto> GetAsync(int id);
        Task Create(ProductCreateDto dto);
        Task Update(int id, Product product);
        Task Delete(int id);
    }
}
