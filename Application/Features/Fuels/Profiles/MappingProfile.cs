using Application.Features.Fuels.Queries.GetAll;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles
{

    public class MappingProfile : Profile
    {
        //constructure
        public MappingProfile()
        {
            // Dönüşüm yapıyo CreateFuelCommand'i Brand'e çeiviryo

            CreateMap<CreateFuelCommand, Fuel>().ReverseMap();
            CreateMap<CreatedFuelResponse, Fuel>().ReverseMap();
            CreateMap<GetAllFuelItemResponse, Fuel>().ReverseMap();
            CreateMap<DeleteFuelCommand, Fuel>().ReverseMap();
            CreateMap<DeletedFuelResponse, Fuel>().ReverseMap();
            CreateMap<UpdateFuelCommand, Fuel>().ReverseMap();
            CreateMap<UpdatedFuelResponse, Fuel>().ReverseMap();

        }
    }
}
