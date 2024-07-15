using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Models.Queries.GetAll
{

    public class GetAllModelsQuery : IRequest<List<GetAllModelItemResponse>>
    {

        public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, List<GetAllModelItemResponse>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetAllModelsQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllModelItemResponse>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Model> models = _modelRepository.GetAll();

                List<GetAllModelItemResponse> response = _mapper.Map<List<GetAllModelItemResponse>>(models);

                return Task.FromResult(response);
            }
        }
    }
}
