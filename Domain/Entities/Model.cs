using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : BaseEntity<Guid>
    {
        public string Name { get; set; } // Model adı
        public string BodyType { get; set; } // Gövde tipi
        public double Weight { get; set; } // Araç ağırlığı

        public Guid BrandId { get; set; } // İlişki için yabancı anahtar
        public virtual Brand Brand { get; set; } = default!; // Bir modelin bir markası vardır

        public virtual ICollection<Car> Cars { get; set; } //Bir modelde birden çok araba olabilir
    }
}
