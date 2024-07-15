using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries;
using Application.Features.Colors.Queries.GetAll;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateColorCommand, Color>().ReverseMap();
            CreateMap<CreatedColorResponse, Color>().ReverseMap();
            CreateMap<GetAllColorItemResponse, Color>().ReverseMap();
            CreateMap<DeleteColorCommand, Color>().ReverseMap();
            CreateMap<DeletedColorResponse, Color>().ReverseMap();
            CreateMap<UpdateColorCommand, Color>().ReverseMap();
            CreateMap<UpdatedColorResponse, Color>().ReverseMap();
        }
    }
}
