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
    public class EfTransmissionRepository : EfBaseRepository<Transmission, Guid, BorusanDbContext>, ITransmissionRepository
    {
        public EfTransmissionRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
