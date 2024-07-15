using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Transmissions.Queries.GetAll
{
  
    public class GetAllTransmissionsQuery : IRequest<List<GetAllTransmissionItemResponse>>
    {

        public class GetAllTransmissionsQueryHandler : IRequestHandler<GetAllTransmissionsQuery, List<GetAllTransmissionItemResponse>>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public GetAllTransmissionsQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllTransmissionItemResponse>> Handle(GetAllTransmissionsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Transmission> transmissions = _transmissionRepository.GetAll();

                List<GetAllTransmissionItemResponse> response = _mapper.Map<List<GetAllTransmissionItemResponse>>(transmissions);

                return Task.FromResult(response);
            }
        }
    }
}
