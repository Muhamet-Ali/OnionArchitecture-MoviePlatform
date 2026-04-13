using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.CastResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.CastQueries
{
    public class UserGetCastByIdQuery:IRequest<UserGetCastByIdQueryResult>
    {
        public int Id { get; set; }

        public UserGetCastByIdQuery(int id)
        {
            Id = id;
        }
    }
}
