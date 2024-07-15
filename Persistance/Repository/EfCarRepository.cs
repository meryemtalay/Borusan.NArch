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
    public class EfCarRepository : EfBaseRepository<Car, Guid, BorusanDbContext>, ICarRepository
    {
        public EfCarRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
