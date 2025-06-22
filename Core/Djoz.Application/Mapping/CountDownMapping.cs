using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class CountDownMapping : Profile
    {
        public CountDownMapping()
        {
            CreateMap<CountDown, CreateCountDownCommandRequest>().ReverseMap();
            CreateMap<CountDown, UpdateCountDownCommandRequest>().ReverseMap();
            CreateMap<CountDown, ResultCountDownListQueryResponse>().ReverseMap();
            CreateMap<CountDown, GetCountDownQueryResponse>().ReverseMap();
        }
    }
}
