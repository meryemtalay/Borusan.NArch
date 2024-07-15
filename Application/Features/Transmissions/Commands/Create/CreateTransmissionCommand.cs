using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Create
{

    public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Type { get; set; }

        public int NumberOfGears { get; set; } // Vites sayısı

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Transmission

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Transmission Transmission = new Transmission()
                //{
                //    Name = request.Name,
                //};

                Transmission transmission = _mapper.Map<Transmission>(request);

                Transmission addedTransmission = await _transmissionRepository.AddAsync(transmission);

                CreatedTransmissionResponse response = _mapper.Map<CreatedTransmissionResponse>(addedTransmission);
                return response;
            }
        }
    }
}