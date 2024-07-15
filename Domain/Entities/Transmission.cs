using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transmission : BaseEntity<Guid>
    {
        public string Type { get; set; }

        public int NumberOfGears { get; set; } // Vites sayısı

        public virtual ICollection<Car> Cars { get; set; } // Bir şanzıman türü birden çok arabada olabilir.

    }
}
