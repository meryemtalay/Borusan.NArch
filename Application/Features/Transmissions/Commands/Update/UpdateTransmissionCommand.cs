using Application.Features.Transmissions.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Update
{

    public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>
    {

        public Guid Id { get; set; }

        public string Type { get; set; }
        public int NumberOfGears { get; set; } // Vites sayısı


        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {


                // İlgili markayı ID ile bul
                Transmission transmission = await _transmissionRepository.GetByIdAsync(request.Id, cancellationToken);

                // Markanın özelliklerini güncelle
                transmission.Type = request.Type;
                transmission.NumberOfGears = request.NumberOfGears;
             
                // Diğer özellikler de güncellenebilir

                // Markayı güncelle ve kaydet
                await _transmissionRepository.UpdateAsync(transmission, cancellationToken);

                // Güncellenen markayı yanıt objesine mapleyin
                UpdatedTransmissionResponse response = _mapper.Map<UpdatedTransmissionResponse>(transmission);
                return response;
            }


        }


    }
}
