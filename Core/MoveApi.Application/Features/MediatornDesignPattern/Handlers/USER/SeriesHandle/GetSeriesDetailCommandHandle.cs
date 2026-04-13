using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.MovieQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.SeriesQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.MovieResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.SeriesResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Domain.Enum;
namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.SeriesHandle
{
    public  class GetSeriesDetailCommandHandle : IRequestHandler<GetSeriesDetailQuery, GetSeriesDetailQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetSeriesDetailCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSeriesDetailQueryResult> Handle(GetSeriesDetailQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;

            var result = await _context.Serieses
                .Where(x => x.Id == request.Id && x.Status)
                .Select(x => new GetSeriesDetailQueryResult
                {
                 Id = x.Id,
                 Title = x.Title,
                 CoverImageUrl = x.CoverImageUrl,
                 Rating = x.Rating,
                 Description = x.Description,
                 CategoryName = x.Category.Name,

                 IsPurchased = userId != null && userId != "guest" && _context.purchases
                    .Any(p => p.UserId == userId && p.ContentId == x.Id && p.ContentType == ContentType.Series),


                    Casts = x.SeriesCasts.Select(mc => new GetSeriesDetailQueryResult.CastItem
                 {
                     CastId = mc.CastId,
                     Name = mc.Cast.Name,
                     Surname = mc.Cast.Surname,
                     ImageUrl = mc.Cast.ImageUrl,
                     CharacterName = mc.CharacterName
                 }).ToList(),

                 Seasons = x.Seasons.Select(s => new GetSeriesDetailQueryResult.SeasonItem
                 {
                     Id = s.Id,
                     Title = s.Title,
                     SeasonNumber = s.SeasonNumber,
                     Description = s.Description,
                     EpisodeCount = s.Episodes.Count()
                 }).ToList(),

                 Reviews = _context.Reviews
                    .Where(r => r.SeriesId == x.Id && !r.IsSpoiler)
                    .Join(_context.Users,
                        r => r.UserId,
                        u => u.Id,
                        (r, u) => new GetSeriesDetailQueryResult.ReviewItem
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
