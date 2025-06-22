using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class DjInfoMapping : Profile
    {
        public DjInfoMapping()
        {
            CreateMap<DjInfo, CreateDjInfoCommandRequest>().ReverseMap();
            CreateMap<DjInfo, UpdateDjInfoCommandRequest>().ReverseMap();
            CreateMap<DjInfo, ResultDjInfoListQueryResponse>().ReverseMap();
            CreateMap<DjInfo, GetDjInfoQueryResponse>().ReverseMap();
        }
    }
}
