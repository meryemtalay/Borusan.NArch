using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeletedCarResponse>
    {
            
        public Guid Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
        {
            // Gerekli bağımlılıklar

            private readonly ICarRepository _CarRepository;
            private readonly IMapper _mapper;
            public DeleteCarCommandHandler(ICarRepository CarRepository, IMapper mapper)
            {
                _CarRepository = CarRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Car

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Car Car = new Car()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Car Car = await _CarRepository.GetByIdAsync(request.Id);

                if (Car == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Car? deletedCar = await _CarRepository.DeleteAsync(Car);

                // Silinen markayı yanıt objesine mapleyin
                DeletedCarResponse response = _mapper.Map<DeletedCarResponse>(deletedCar);
                return response;
            }


        }
    }
}
