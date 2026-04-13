using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.HomePageResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.HomePageQueries
{
    public class HomePageQuery:IRequest<List<HomePageQuerytResult>>
    {
    }
}
