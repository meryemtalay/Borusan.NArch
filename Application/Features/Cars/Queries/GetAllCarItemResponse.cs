using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetAll
{
    public class GetAllCarItemResponse
    {
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }

    }
}

