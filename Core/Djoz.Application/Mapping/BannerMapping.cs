using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<Banner, CreateBannerCommandRequest>().ReverseMap();
            CreateMap<Banner, UpdatSongCommandRequest>().ReverseMap();
            CreateMap<Banner, ResultBannerListQueryResponse>().ReverseMap();
            CreateMap<Banner, GetBannerQueryResponse>().ReverseMap();
        }
    }
}
