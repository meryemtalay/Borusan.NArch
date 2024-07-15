using Application.Features.Colors.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand:  IRequest<DeletedBrandResponse>
    {
        public Guid Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Brand

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Brand brand = await _brandRepository.GetByIdAsync(request.Id);

                if (brand == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Brand? deletedBrand = await _brandRepository.DeleteAsync(brand);

                // Silinen markayı yanıt objesine mapleyin
                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(deletedBrand);
                return response;
            }


        }
    }
}
