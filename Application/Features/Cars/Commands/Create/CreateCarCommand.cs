using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories;
using AutoMapper;

namespace Application.Features.Cars.Commands.Create
{
    public class CreateCarCommand : IRequest<CreatedCarResponse>
    {
        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }



        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Car

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Car Car = new Car()
                //{
                //    Name = request.Name,
                //};

                Car Car = _mapper.Map<Car>(request);

                Car addedCar = await _carRepository.AddAsync(Car);

                CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(addedCar);
                return response;
            }
        }

    }
}
