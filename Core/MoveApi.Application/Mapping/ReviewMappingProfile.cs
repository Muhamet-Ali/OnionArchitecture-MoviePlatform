using AutoMapper;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.ReviewCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults;
using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults.GetReviewProgramById;


namespace MoveApi.Application.Mapping
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<CreateReviewCommand, Review>();
            CreateMap<UpdateReviewCommand, Review>();
            CreateMap<Review, GetReviewQureyResult>()
                .ForMember(dest => dest.programName,
                    opt => opt.MapFrom(src =>
                        src.MovieId != null ? src.Movie.Title :
                        src.SeriesId != null ? src.Series.Title :
                        src.EpisodeId != null ? src.Episode.Title :
                        null
                ));
            //movie reviews
            CreateMap<Review, GetReviewMovieQureyResult>();
            //series reviws
            CreateMap<Review, GetReviewSeriesQureyResult>();
            //Episode Reviews
            CreateMap<Review, GetReviewEpisodeQureyResult>();

            //
            CreateMap<Review, GetReviewByIdQureyResult>()
                .ForMember(dest => dest.programName,
                opt => opt.MapFrom(src =>
                    src.MovieId != null ? src.Movie.Title :
                    src.SeriesId != null ? src.Series.Title :
                    src.EpisodeId != null ? src.Episode.Title :
                    null
                ));

            CreateMap<Review, GetReviewMovieQueryResultById>();
            CreateMap<Review, GetReviewSeriesQueryResultById>();
            CreateMap<Review, GetReviewEpisodeQueryResultById>();









        }

       
    }
}
