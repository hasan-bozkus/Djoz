using AutoMapper;
using Djoz.Application.Dtos.AppUserDtos;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, GetUserQueryResponse>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommandRequest>().ReverseMap();
        }
    }
}
