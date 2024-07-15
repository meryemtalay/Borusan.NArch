using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Update
{

    public class UpdateModelCommand : IRequest<UpdatedModelResponse>
    {

        public Guid Id { get; set; }
        public string Name { get; set; } // Model adı
        public string BodyType { get; set; } // Gövde tipi
        public double Weight { get; set; } // Araç ağırlığı


        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
               
                // İlgili markayı ID ile bul
                Model model = await _modelRepository.GetByIdAsync(request.Id, cancellationToken);

                // Markanın özelliklerini güncelle
                model.Name = request.Name;
                model.BodyType = request.BodyType;
                model.Weight = request.Weight;
                // Diğer özellikler de güncellenebilir

                // Markayı güncelle ve kaydet
                await _modelRepository.UpdateAsync(model, cancellationToken);

                // Güncellenen markayı yanıt objesine mapleyin
                UpdatedModelResponse response = _mapper.Map<UpdatedModelResponse>(model);
                return response;
            }


        }


    }
}

