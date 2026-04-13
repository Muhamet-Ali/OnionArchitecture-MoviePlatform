using AutoMapper;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.CastResult;
using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Mapping
{
    public class UserCastMappingProfile : Profile
    {
        public UserCastMappingProfile()
        {

            CreateMap<Cast, UserGetCastQueryResult>();


        }

    }
}
