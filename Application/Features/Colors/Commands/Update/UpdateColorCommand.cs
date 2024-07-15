using Application.Features.Brands.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Update
{
    public class UpdateColorCommand : IRequest<UpdatedColorResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdatedColorResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.


                // İlgili markayı ID ile bul
                Color color = await _colorRepository.GetByIdAsync(request.Id, cancellationToken);

                // Markanın özelliklerini güncelle
                color.Name = request.Name;
                // Diğer özellikler de güncellenebilir

                // Markayı güncelle ve kaydet
                await _colorRepository.UpdateAsync(color, cancellationToken);

                // Güncellenen markayı yanıt objesine mapleyin
                UpdatedColorResponse response = _mapper.Map<UpdatedColorResponse>(color);
                return response;
            }


        }
    }
}
