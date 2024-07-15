using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Update
{
    public class UpdatedCarResponse
    {
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }

        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public Guid ColorId { get; set; }
    }
}
