using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{

    public class MappingProfile : Profile
    {
        //constructure
        public MappingProfile()
        {
            // Dönüşüm yapıyo CreateModelCommand'i Model'e çeiviryo

            CreateMap<CreateModelCommand, Model>().ReverseMap();
            CreateMap<CreatedModelResponse, Model>().ReverseMap();
            CreateMap<GetAllModelItemResponse, Model>().ReverseMap();
            CreateMap<DeleteModelCommand, Model>().ReverseMap();
            CreateMap<DeletedModelResponse, Model>().ReverseMap();
            CreateMap<UpdateModelCommand, Model>().ReverseMap();
            CreateMap<UpdatedModelResponse, Model>().ReverseMap();

        }
    }
}
