using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetAll
{
    public class GetAllCarsQuery : IRequest<List<GetAllCarItemResponse>>
    {
        public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<GetAllCarItemResponse>>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllCarItemResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Car> cars = _carRepository.GetAll();

                List<GetAllCarItemResponse> response = _mapper.Map<List<GetAllCarItemResponse>>(cars);

                return Task.FromResult(response);
            }

        }
    }
}



