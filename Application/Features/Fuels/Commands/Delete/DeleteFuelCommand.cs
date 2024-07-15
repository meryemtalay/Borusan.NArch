using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.Delete
{

    public class DeleteFuelCommand : IRequest<DeletedFuelResponse>
    {
        public Guid Id { get; set; }

        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<DeletedFuelResponse> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Brand

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Fuel fuel = await _fuelRepository.GetByIdAsync(request.Id);

                if (fuel == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Fuel? deletedFuel = await _fuelRepository.DeleteAsync(fuel);

                // Silinen markayı yanıt objesine mapleyin
                DeletedFuelResponse response = _mapper.Map<DeletedFuelResponse>(deletedFuel);
                return response;
            }


        }
    }
}
