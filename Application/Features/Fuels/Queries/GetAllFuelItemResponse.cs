using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Queries.GetAll
{
    public class GetAllFuelItemResponse
    {
        public Guid Id { get; set; }
        public string FuelType { get; set; }
    }
}
