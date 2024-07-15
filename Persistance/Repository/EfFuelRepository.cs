using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class EfFuelRepository : EfBaseRepository<Fuel, Guid, BorusanDbContext>, IFuelRepository
    {
        public EfFuelRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
