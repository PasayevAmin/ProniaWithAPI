using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime? ModifieldAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public BaseEntity()
        {
            CreatedBy = "amin.pasayev";
            CreateAt = DateTime.Now;
        }
    }
}
