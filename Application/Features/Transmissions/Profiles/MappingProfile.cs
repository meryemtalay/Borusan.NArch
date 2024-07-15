using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries;
using Application.Features.Transmissions.Queries.GetAll;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Transmissions.Profiles
{
    public class MappingProfile : Profile
    {
        //constructure
        public MappingProfile()
        {
            // Dönüşüm yapıyo CreateTransmissionCommand'i Transmission'e çeiviryo

            CreateMap<CreateTransmissionCommand, Transmission>().ReverseMap();
            CreateMap<CreatedTransmissionResponse, Transmission>().ReverseMap();
            CreateMap<GetAllTransmissionItemResponse, Transmission>().ReverseMap();
            CreateMap<DeleteTransmissionCommand, Transmission>().ReverseMap();
            CreateMap<DeletedTransmissionResponse, Transmission>().ReverseMap();
            CreateMap<UpdateTransmissionCommand, Transmission>().ReverseMap();
            CreateMap<UpdatedTransmissionResponse, Transmission>().ReverseMap();

        }
    }
}

