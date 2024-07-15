
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories;
using AutoMapper;


namespace Application.Features.Fuels.Commands.Create
{

    // Unit => Fonksiyonda void ne ise request'de o.
    public class CreateFuelCommand : IRequest<CreatedFuelResponse>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Name { get; set; }


        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<CreatedFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {


                Fuel fuel = _mapper.Map<Fuel>(request);

                Fuel addedFuel = await _fuelRepository.AddAsync(fuel);

                CreatedFuelResponse response = _mapper.Map<CreatedFuelResponse>(addedFuel);
                return response;
            }
        }
    }
}
