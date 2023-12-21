using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Tag;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _repository;

        public TagService(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<TagItemDto> GetAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("not Found");
            return new TagItemDto(tag.Id,tag.Name);
            

        }

        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAll(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<TagItemDto> dtos = new List<TagItemDto>();
            foreach (var tag in tags)
            {
                dtos.Add(new TagItemDto(tag.Id, tag.Name));
                
            }
            return dtos;
        }

        public async Task Create(TagCreateDto dto)
        {
            await _repository.AddAsync(new Tag
            {
                Name = dto.Name,
            });
            await _repository.SaveChangesAsync();
        }

        public async Task Update(int id, Tag tag)
        {
            Tag existed = await _repository.GetByIdAsync(id);

            existed.Name = tag.Name;
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Tag existed = await _repository.GetByIdAsync(id);
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
