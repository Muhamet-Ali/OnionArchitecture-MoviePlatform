using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.purchaseResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.purchaseQueries
{
    public class GetpurchaseByIdQuery:IRequest<List<GetpurchaseByIdQueryResult>>
    {
        public string Id { get; set; }

        public GetpurchaseByIdQuery(string id)
        {
            Id = id;
        }
    }
}
