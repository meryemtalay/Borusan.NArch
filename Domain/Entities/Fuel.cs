using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fuel : BaseEntity<Guid>
    {
        public string FuelType { get; set; }

        public virtual ICollection<Car> Cars { get; set; } // Bir yakıt türünde birçok araba var.

    }
}
