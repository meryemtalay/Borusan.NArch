﻿using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICarRepository : IBaseRepository<Car, Guid>, IAsyncRepository<Car, Guid>
    {

    }
}