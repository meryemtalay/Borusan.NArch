using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries;
using Application.Features.Brands.Queries.GetAll;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Brands.Profiles
{
    public class MappingProfile: Profile
    {
        //constructure
        public MappingProfile()
        {
            // Dönüşüm yapıyo CreateBrandCommand'i Brand'e çeiviryo
            
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<CreatedBrandResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandItemResponse, Brand>().ReverseMap();
            CreateMap<DeleteBrandCommand, Brand>().ReverseMap();
            CreateMap<DeletedBrandResponse, Brand>().ReverseMap();
            CreateMap<UpdateBrandCommand, Brand>().ReverseMap();
            CreateMap<UpdatedBrandResponse, Brand>().ReverseMap();

        }
    }
}

