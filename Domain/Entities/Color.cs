﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Color : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; } // Bir renkten birçok araba olabilir

    }
}
