using System;
using Domain.Entities;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IModelRepository : IBaseRepository<Model, Guid>, IAsyncRepository<Model, Guid>
    {
    }
}
