using MovieApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.USER.purchaseResults
{
    public class GetpurchaseByIdQueryResult
    {
        public int Id { get; set; }

        public string UserId { get; set; } // Identity


        public int ContentId { get; set; }
        public ContentType ContentType { get; set; } // Movie / Series
        public string ContentName { get; set; }
        public string ContentImage { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public PaymentStatus PaymentStatus { get; set; } // Paid / Failed
    }
}
