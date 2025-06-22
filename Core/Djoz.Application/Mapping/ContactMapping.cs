using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, CreateContactCommandRequest>().ReverseMap();
            CreateMap<Contact, UpdateContactCommandRequest>().ReverseMap();
            CreateMap<Contact, ResultContactListQueryResponse>().ReverseMap();
            CreateMap<Contact, GetContactQueryResponse>().ReverseMap();
        }
    }
}
