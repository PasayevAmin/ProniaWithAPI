using AutoMapper;
using ProniaOnion.Application.Dtos.Categories;
using ProniaOnion.Application.Dtos.Product;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
