using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; } // Each Brand can have multiple Cars
        public virtual ICollection<Model> Models { get; set; } // Her marka birden fazla modele sahip olabilir



    }
}
