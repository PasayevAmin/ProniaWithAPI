using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Dtos.Product
{
    public record ProductCreateDto(string Name,string Description,string SKU,Category Category,
     ICollection<ProductColor>? ProductColors,
     ICollection<ProductTag>? ProductTags);
    
}
