using AutoMapper;
using Djoz.Application.Dtos.SongDtos;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class SongMapping : Profile
    {
        public SongMapping()
        {
            CreateMap<Song, CreateSongCommandRequest>().ReverseMap();
            //CreateMap<Song, UpdateSongCommandRequest>().ReverseMap();
            CreateMap<Song, ResultSongListQueryResponse>().ForMember(dest => dest.PackageIds, opt => opt.MapFrom(src => src.Packages
            .Select(p => p.PackageId).ToList())).ReverseMap();
            CreateMap<Song, GetSongQueryResponse>().ReverseMap();
            CreateMap<Song, ResultSongDto>().ReverseMap();
            CreateMap<Song, PlaySongCommandResponse>().ForMember(dest => dest.PackageIds, opt => opt.MapFrom(src => src.Packages
            .Select(p => p.PackageId).ToList())).ReverseMap();
            CreateMap<PlaySongCommandResponse, ResultSongDto>().ReverseMap();
        }
    }
}
