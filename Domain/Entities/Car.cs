using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : BaseEntity<Guid>
    {
        //UUID
        // GUidde rastgele yapılacak, rastgeleliğinden kaynaklı güvenli bir ortam oluşturuyo
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }

        public Guid BrandId { get; set; }// veritabanında ilişki kuracak alan
        public virtual Brand Brand { get; set; } = default!; // Navigation property oop kullanmak için 

        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; } = default!;

        public Guid TransmissionId { get; set; }
        public virtual Transmission Transmission { get; set; } = default!;

        public Guid FuelId { get; set; }
        public virtual Fuel Fuel { get; set; } = default!;

    }
}
