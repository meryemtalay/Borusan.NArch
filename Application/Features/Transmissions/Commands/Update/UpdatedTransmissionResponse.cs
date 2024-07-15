using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Update
{
    public class UpdatedTransmissionResponse
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public int NumberOfGears { get; set; } // Vites sayısı
    }
}
