using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Color;
using ProniaOnion.Application.Dtos.Tag;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ColorService:IColorService
    {
        private readonly IRepository<Color> _repository;

        public ColorService(IRepository<Color> repository)
        {
            _repository = repository;
        }

        public async Task<ColorItemDto> GetAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new Exception("not Found");
            return new ColorItemDto(color.Id, color.Name);


        }

        public async Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Color> colors = await _repository.GetAll(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<ColorItemDto> dtos = new List<ColorItemDto>();
            foreach (var color in colors)
            {
                dtos.Add(new ColorItemDto(color.Id, color.Name));

            }
            return dtos;
        }

        public async Task Create(ColorCreateDto dto)
        {
            await _repository.AddAsync(new Color
            {
                Name = dto.Name,
            });
            await _repository.SaveChangesAsync();
        }

        public async Task Update(int id, Color tag)
        {
            Color existed = await _repository.GetByIdAsync(id);

            existed.Name = tag.Name;
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Color existed = await _repository.GetByIdAsync(id);
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
