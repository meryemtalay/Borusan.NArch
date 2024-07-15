using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.Delete
{
    public class DeleteColorCommand : IRequest<DeletedColorResponse>
    {
        public Guid Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                // İlgili request ile istediğimiz işlemi yapabiliriz.

                // X -> Brand

                // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name,
                //};

                // İlgili markayı ID ile bul
                Color color = await _colorRepository.GetByIdAsync(request.Id);

                if (color == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Color? deletedColor = await _colorRepository.DeleteAsync(color);

                // Silinen markayı yanıt objesine mapleyin
                DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(deletedColor);
                return response;
            }


        }
    }
}
