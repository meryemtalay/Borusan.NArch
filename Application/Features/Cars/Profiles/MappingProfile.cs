using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;



namespace Application.Features.Cars.Profiles
{
    public class MappingProfile : Profile
    {
        //constructure
        public MappingProfile()
        {
            // Dönüşüm yapıyo CreateCarCommand'i Car'e çeiviryo

            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<CreatedCarResponse, Car>().ReverseMap();
            CreateMap<GetAllCarItemResponse, Car>().ReverseMap();
            CreateMap<DeleteCarCommand, Car>().ReverseMap();
            CreateMap<DeletedCarResponse, Car>().ReverseMap();
            CreateMap<UpdateCarCommand, Car>().ReverseMap();
            CreateMap<UpdatedCarResponse, Car>().ReverseMap();

        }
    }
}
