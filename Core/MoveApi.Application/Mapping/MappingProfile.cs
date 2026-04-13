using AutoMapper;
using AutoMapper;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.ReviewCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeasonCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult;
using MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeasonResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults;
using MovieAp.Domain.Entities;
using MovieAp.Domain.Entities;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CAST Entity
        CreateMap<CreateCastCommand, Cast>();
        CreateMap<UpdateCastCommand, Cast>();

        CreateMap<Cast, GetCastQueryResult>()
        .ForMember(dest => dest.FilmographyCount,
         opt => opt.MapFrom(src => src.MovieCasts.Count + src.SeriesCasts.Count));

        CreateMap<Cast, GetCastByIdQueryResult>();

        //************************Episode***************************************

        CreateMap<CreateEpisodeCommand, Episode>();
        CreateMap<UpdateEpisodeCommand, Episode>();
        //list
        CreateMap<Episode, GetEpisodeQueryResult>()
        .ForMember(dest => dest.SeasonName,
            opt => opt.MapFrom(src => src.Season.Title));

        CreateMap<Episode, GetEpisodesBySeasonQueryResult>()
       .ForMember(dest => dest.SeasonName,
           opt => opt.MapFrom(src => src.Season.Title));
        // Detail sayfasi
        CreateMap<Episode, GetEpisodeByIdQueryResult>()
            .ForMember(dest => dest.SeasonName,
                opt => opt.MapFrom(src => src.Season.Title))

            .ForMember(dest => dest.ParentType,
                opt => opt.MapFrom(src =>
                    src.Season.MovieId != null ? "Movie" : "Series"))

            .ForMember(dest => dest.ParentName,
                opt => opt.MapFrom(src =>
                    src.Season.Movie != null
                        ? src.Season.Movie.Title
                        : src.Season.Series.Title));

        //***************************************Movie Cast********************************
        CreateMap<CreateMovieCastCommand, MovieCast>();
        CreateMap<UpdateMovieCastCommand, MovieCast>();
        CreateMap<MovieCast, GetMovieCastQueryResult>();
        CreateMap<MovieCast, GetMovieCastByIdQueryResult>();


        // ************************************Series Cast
        CreateMap<CreateSeriesCastCommand, SeriesCast>();
        CreateMap<UpdateSeriesCastCommand, SeriesCast>();
        CreateMap<SeriesCast, GetSeriesCastQueryResult>();
        CreateMap<SeriesCast, GetSeriesCastByIdQueryResult>();



       

        //season
        CreateMap<CreateSeasonCommand, Season>();
        CreateMap<UpdateSeasonCommand, Season>();
        CreateMap<Season, GetSeasonQueryResult>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
            .ForMember(dest => dest.SeriesName, opt => opt.MapFrom(src => src.Series.Title));

        CreateMap<Season, GetSeasonByIdQueryResult>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie != null ? src.Movie.Title : null))
            .ForMember(dest => dest.SeriesName, opt => opt.MapFrom(src => src.Series != null ? src.Series.Title : null));
       


    }
}