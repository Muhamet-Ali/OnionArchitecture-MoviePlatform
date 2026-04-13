using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserPurchaseCommands;
using MovieApi.Domain.Entities;
using MovieApi.Domain.Enum;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.PurchaseHandle
{
    public class CreatePurchaseCommandHandle : IRequestHandler<CreatePurchaseCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MovieContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreatePurchaseCommandHandle(UserManager<AppUser> userManager, MovieContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
                throw new Exception("User not found");

            var exist = await _context.purchases
                .AnyAsync(x => x.UserId == request.UserId
                            && x.ContentId == request.ContentId
                            && x.ContentType == request.ContentType);

            if (exist)
                throw new Exception("Already purchased");

            decimal price = request.ContentType == ContentType.Movie
                ? await _context.Movies.Where(x => x.Id == request.ContentId).Select(x => x.Price).FirstOrDefaultAsync()
                : await _context.Serieses.Where(x => x.Id == request.ContentId).Select(x => x.Price).FirstOrDefaultAsync();

            var purchase = new Purchase
            {
                UserId = request.UserId,
                ContentId = request.ContentId,
                ContentType = request.ContentType,
                Price = price,
                PurchaseDate = DateTime.Now,
                PaymentStatus = PaymentStatus.Completed
            };

            _context.purchases.Add(purchase);
            await _context.SaveChangesAsync();



        }
    }
}
