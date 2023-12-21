using AutoMapper;
using ProniaOnion.Application.Dtos.Categories;
using ProniaOnion.Application.Dtos.Color;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorItemDto>().ReverseMap();
            CreateMap<ColorCreateDto, Color>();
        }
    }
}
