using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<Event, CreateEventCommandRequest>().ReverseMap();
            CreateMap<Event, UpdateEventCommandRequest>().ReverseMap();
            CreateMap<Event, ResultEventListQueryResponse>().ReverseMap();
            CreateMap<Event, GetEventQueryResponse>().ReverseMap();
        }
    }
}
