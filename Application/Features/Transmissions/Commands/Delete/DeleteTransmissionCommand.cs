using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Delete
{
    public class DeleteTransmissionCommand : IRequest<DeletedTransmissionResponse>
    {
        public Guid Id { get; set; }

        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTransmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {


                // İlgili markayı ID ile bul
                Transmission transmission = await _transmissionRepository.GetByIdAsync(request.Id);

                if (transmission == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Transmission? deletedTransmission = await _transmissionRepository.DeleteAsync(transmission);

                // Silinen markayı yanıt objesine mapleyin
                DeletedTransmissionResponse response = _mapper.Map<DeletedTransmissionResponse>(deletedTransmission);
                return response;
            }


        }
    }
}

