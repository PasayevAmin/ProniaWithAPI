﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Tag:BaseNameableEntity
    {
        //Relational Properties
        public ICollection<ProductTag>? ProductTags { get; set; }
    }
}
