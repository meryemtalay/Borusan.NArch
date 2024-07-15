using Application.Features.Cars.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommand : IRequest<UpdatedCarResponse>
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }


        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Car

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Car Car = new Car()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Car car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
                if (car == null)
                {
                    throw new Exception("Böyle bir araç bulunamadı.");
                }

                // Araç özelliklerini güncelle
                car.Plate = request.Plate;
                car.ModelYear = request.ModelYear;
                car.Kilometer = request.Kilometer;
                // Diğer özellikler de güncellenebilir

                // Araç bilgilerini güncelle ve kaydet
                await _carRepository.UpdateAsync(car, cancellationToken);

                // Güncellenen aracı yanıt objesine maple
                UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(car);
                return response;
            }


        }
    }
}
