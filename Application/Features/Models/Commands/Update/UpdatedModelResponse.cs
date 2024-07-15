using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Update
{
    public class UpdatedModelResponse
    {
        public string Name { get; set; } // Model adı
        public string BodyType { get; set; } // Gövde tipi
        public double Weight { get; set; } // Araç ağırlığı

    }
}
