using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.Update
{

    public class UpdateFuelCommand : IRequest<UpdatedFuelResponse>
    {
        public Guid Id { get; set; }
        public string FuelType { get; set; }


        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedFuelResponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                

                // İlgili markayı ID ile bul
                Fuel fuel = await _fuelRepository.GetByIdAsync(request.Id, cancellationToken);

                // Markanın özelliklerini güncelle
                fuel.FuelType = request.FuelType;
                // Diğer özellikler de güncellenebilir

                // Markayı güncelle ve kaydet
                await _fuelRepository.UpdateAsync(fuel, cancellationToken);

                // Güncellenen markayı yanıt objesine mapleyin
                UpdatedFuelResponse response = _mapper.Map<UpdatedFuelResponse>(fuel);
                return response;
            }

        }
    }
}
