using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Delete
{

    public class DeleteModelCommand : IRequest<DeletedModelResponse>
    {

        public Guid Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelResponse>
        {
            // Gerekli bağımlılıklar

            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<DeletedModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                
                Model model = await _modelRepository.GetByIdAsync(request.Id);

                if (model == null)
                {
                    throw new Exception("Böyle bir marka yok.");
                }

                // Markayı sil
                Model? deletedModel = await _modelRepository.DeleteAsync(model);

                // Silinen markayı yanıt objesine mapleyin
                DeletedModelResponse response = _mapper.Map<DeletedModelResponse>(deletedModel);
                return response;
            }


        }
    }
}
