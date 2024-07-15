using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Colors.Queries.GetAll
{
    public class GetAllColorsQuery : IRequest<List<GetAllColorItemResponse>>
    {
        public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, List<GetAllColorItemResponse>>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public GetAllColorsQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public Task<List<GetAllColorItemResponse>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Get All'ı async yap.
                List<Color> colors = _colorRepository.GetAll();

                List<GetAllColorItemResponse> response = _mapper.Map<List<GetAllColorItemResponse>>(colors);

                return Task.FromResult(response);
            }

        }
    }
}
