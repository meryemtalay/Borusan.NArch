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
    public class EfModelRepository : EfBaseRepository<Model, Guid, BorusanDbContext>, IModelRepository
    {
        public EfModelRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
