using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults.GetReviewProgramById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries.GetReviewProgramById
{
    public class GetReviewEpisodeQueryById:IRequest<List<GetReviewEpisodeQueryResultById>>
    {
        public int Id { get; set; }

        public GetReviewEpisodeQueryById(int id)
        {
            Id = id;
        }
    }
}
