using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries;
using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Mapping
{
    public class PackageMapping : Profile
    {
        public PackageMapping()
        {
            CreateMap<CreatePackageCommandRequest, Package>().ForMember(dest => dest.Songs,opt => opt.Ignore()).ReverseMap();
            CreateMap<UpdatePackageCommandRequest, Package>().ForMember(dest => dest.Songs,opt => opt.Ignore()).ReverseMap();
            CreateMap<Package, ResultPackageListQueryResponse>().ReverseMap();
            CreateMap<Package, GetPackageQueryResponse>().ReverseMap();
        }
    }
}
