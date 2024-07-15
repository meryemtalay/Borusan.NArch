using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Repositories
{
    public interface IColorRepository : IBaseRepository<Color, Guid>, IAsyncRepository<Color, Guid>
    {
    }
}
