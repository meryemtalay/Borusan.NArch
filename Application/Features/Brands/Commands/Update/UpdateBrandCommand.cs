using Application.Features.Colors.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Brand

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Brand brand = await _brandRepository.GetByIdAsync(request.Id, cancellationToken);

                // Markanın özelliklerini güncelle
                brand.Name = request.Name;
                // Diğer özellikler de güncellenebilir

                // Markayı güncelle ve kaydet
                await _brandRepository.UpdateAsync(brand, cancellationToken);

                // Güncellenen markayı yanıt objesine mapleyin
                UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
                return response;
            }


        }


    }
}
