using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries
{
    public class GetReviewEpisodeQuery:IRequest<List<GetReviewEpisodeQureyResult>>
    {
    }
}
