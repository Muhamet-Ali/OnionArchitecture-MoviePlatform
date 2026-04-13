using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.purchaseQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.purchaseResults;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Enum;
namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.PurchaseHandle
{
    public class GetpurchaseByIdCommandHandle : IRequestHandler<GetpurchaseByIdQuery, List<GetpurchaseByIdQueryResult>>
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public GetpurchaseByIdCommandHandle(UserManager<AppUser> userManager, MovieContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetpurchaseByIdQueryResult>> Handle(GetpurchaseByIdQuery request, CancellationToken cancellationToken)
        {

            // Önce veriyi çek
            var purchases = await _context.purchases
               .Where(x => x.UserId == request.Id)
               .ToListAsync(cancellationToken);

            // Sonra map et
            var result = purchases.Select(x => new GetpurchaseByIdQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                ContentId = x.ContentId,
                ContentType = x.ContentType,
                ContentName = x.ContentType == ContentType.Movie
                    ? _context.Movies.Where(m => m.Id == x.ContentId).Select(m => m.Title).FirstOrDefault()
                    : _context.Serieses.Where(s => s.Id == x.ContentId).Select(s => s.Title).FirstOrDefault(),
                ContentImage= x.ContentType == ContentType.Movie
                    ? _context.Movies.Where(m => m.Id == x.ContentId).Select(m => m.CoverImageUrl).FirstOrDefault()
                    : _context.Serieses.Where(s => s.Id == x.ContentId).Select(s => s.CoverImageUrl).FirstOrDefault(),
                Price = x.Price,
                PurchaseDate = x.PurchaseDate,
                PaymentStatus = x.PaymentStatus
            }).ToList();

            return result;


        }
    }
}
