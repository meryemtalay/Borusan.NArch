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

namespace Application.Features.Colors.Commands.Create
{
    public class CreateColorCommand : IRequest<CreatedColorResponse>
    {

        // Komutun işlevini yerine getirmesi için alması gereken argümanlar.

        public string Name { get; set; }



        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
            {
                // Gerekli bağımlılıklar

                private readonly IColorRepository _colorRepository;
                private readonly IMapper _mapper;
                public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
                {
                    _colorRepository = colorRepository;
                    _mapper = mapper;
                }

                public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
                {
                    // İlgili request ile istediğimiz işlemi yapabiliriz.

                    // X -> Color

                    // Automapper => Eğer isimler aynı ise maplemeyi otomatize eder.
                    //Color Color = new Color()
                    //{
                    //    Name = request.Name,
                    //};

                    Color color = _mapper.Map<Color>(request);

                    Color addedColor = await _colorRepository.AddAsync(color);

                    CreatedColorResponse response = _mapper.Map<CreatedColorResponse>(addedColor);
                    return response;
                }
            }
        }
    
}
