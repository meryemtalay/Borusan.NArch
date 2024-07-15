using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Fuels.Queries.GetAll
{
    public class GetAllFuelsQuery : IRequest<List<GetAllFuelItemResponse>>
    {

        public class GetAllFuelsQueryHandler : IRequestHandler<GetAllFuelsQuery, List<GetAllFuelItemResponse>>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public GetAllFuelsQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllFuelItemResponse>> Handle(GetAllFuelsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Fuel> fuels = _fuelRepository.GetAll();

                List<GetAllFuelItemResponse> response = _mapper.Map<List<GetAllFuelItemResponse>>(fuels);

                return Task.FromResult(response);
            }
        }
    }
}
