﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetAll
{
    public class GetAllTransmissionItemResponse
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public int NumberOfGears { get; set; } // Vites sayısı
    }
}
