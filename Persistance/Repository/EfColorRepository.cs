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
    public class EfColorRepository : EfBaseRepository<Color, Guid, BorusanDbContext>, IColorRepository
    {
        public EfColorRepository(BorusanDbContext context) : base(context)
        {
        }
    }

}
