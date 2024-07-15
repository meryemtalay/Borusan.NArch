using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create
{

    
    public class CreateModelCommand : IRequest<CreatedModelResponse>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.


        public string Name { get; set; } // Model adı
        public string BodyType { get; set; } // Gövde tipi
        public double Weight { get; set; } // Araç ağırlığı

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {

                Model model = _mapper.Map<Model>(request);

                Model addedModel = await _modelRepository.AddAsync(model);

                CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(addedModel);
                return response;
            }
        }
    }
}
