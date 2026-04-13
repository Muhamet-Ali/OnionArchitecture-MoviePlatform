using AutoMapper;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.HomePageResult;
using MovieAp.Domain.Entities;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Mapping
{
    public class UserHomePageProfile:Profile
    {
        public UserHomePageProfile()
        {

            CreateMap<Movie,HomePageQuerytResult>()
                .ForMember(x => x.Type, y => y.MapFrom(z => "Movie"))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name));

            CreateMap<Series,HomePageQuerytResult>()
                .ForMember(x => x.Type, y => y.MapFrom(z => "Series"))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name));



        }
    }
}
