using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.MovieQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.MovieResults;
using MovieApi.Domain.Enum;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.MovieHandle
{
    public class GetMovieDetailCommandHandle : IRequestHandler<GetMovieDetailQuery, GetMovieDetailQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public GetMovieDetailCommandHandle(IMapper mapper, MovieContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<GetMovieDetailQueryResult> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {

            var userId = request.UserId;

            var result = await _context.Movies
           .Where(x => x.Id == request.Id && x.Status)
           .Select(x => new GetMovieDetailQueryResult
           {
               Id = x.Id,
               Title = x.Title,
               CoverImageUrl = x.CoverImageUrl,
               Rating = x.Rating,
               Description = x.Description,
               Duration = x.Duration,
               RelaseDate = x.RelaseDate,
               CategoryName = x.Category.Name,

               IsPurchased = userId != null && userId != "guest" && _context.purchases
                    .Any(p => p.UserId == userId && p.ContentId == x.Id && p.ContentType == ContentType.Movie),
               Casts = x.MovieCasts.Select(mc => new GetMovieDetailQueryResult.CastItem
               {
                   CastId = mc.CastId,
                   Name = mc.Cast.Name,
                   Surname = mc.Cast.Surname,
                   ImageUrl = mc.Cast.ImageUrl,
                   CharacterName = mc.CharacterName
               }).ToList(),

               Seasons = x.Seasons.Select(s => new GetMovieDetailQueryResult.SeasonItem
               {
                   Id = s.Id,
                   Title = s.Title,
                   SeasonNumber = s.SeasonNumber,
                   Description = s.Description,
                   EpisodeCount = s.Episodes.Count()
               }).ToList(),

               Reviews = _context.Reviews
                  .Where(r => r.MovieId == x.Id&& !r.IsSpoiler)
                  .Join(_context.Users,
                      r => r.UserId,
                      u => u.Id,
                      (r, u) => new GetMovieDetailQueryResult.ReviewItem
                      {
                          Id = r.Id,
                          UserName = u.Name + " " + u.Surname,
                          UserImageUrl = u.ProfileImageUrl,
                          Comment = r.ReviewComment,
                          Rating = r.UserRating,
                          LikeCount = r.LikeCount,
                          IsSpoiler = r.IsSpoiler,
                          CreatedDate = r.ReviewDate
                      }).ToList(),
           })
           .FirstOrDefaultAsync(cancellationToken);

            return result;

        }
    }
}
