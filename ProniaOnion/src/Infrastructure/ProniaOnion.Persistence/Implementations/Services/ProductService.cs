using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Categories;
using ProniaOnion.Application.Dtos.Product;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Create(ProductCreateDto dto)
        {
            await _repository.AddAsync(_mapper.Map<Product>(dto));

             await _repository.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Product> products = await _repository.GetAll(skip: (page - 1) * take, take: take).ToListAsync();

            return _mapper.Map<ICollection<ProductItemDto>>(products);
        }

        public Task<ProductItemDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, Product product)
        {
            Product existed = await _repository.GetByIdAsync(id);

            existed.Name = product.Name;
            existed.Description = product.Description;
            existed.Price = product.Price;
            existed.SKU= product.SKU;
            existed.Category = product.Category;
            existed.ProductColors = product.ProductColors;
            existed.ProductTags = product.ProductTags;
            await _repository.SaveChangesAsync();
        }
    }
}
