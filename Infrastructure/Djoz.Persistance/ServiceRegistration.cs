using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using Djoz.Persistance.RepositoryPattern.EntityFramework.AppUserServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.BannerServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.ContactServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.CountDownServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.DjInfoServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.EventServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.PackageServices;
using Djoz.Persistance.RepositoryPattern.EntityFramework.SongServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<DjozContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DjozContext>();

            services.AddScoped<IAppUserReadDal, EFAppUserReadRepository>();
            services.AddScoped<IAppUserWriteDal, EFAppUserWriteRepository>();

            services.AddScoped<IBannerReadDal, EFBannerReadRepository>();
            services.AddScoped<IBannerWriteDal, EFBannerWriteRepository>();

            services.AddScoped<IContactReadDal, EFContactReadRepository>();
            services.AddScoped<IContactWriteDal, EFContactWriteRepository>();

            services.AddScoped<ICountDownReadDal, EFCountDownReadRepository>();
            services.AddScoped<ICoutDownWriteDal, EFCountDownWriteRepository>();

            services.AddScoped<IDjInfoReadDal, EFDjInfoReadRepository>();
            services.AddScoped<IDjInfoWriteDal, EFDjInfoWriteRepository>();

            services.AddScoped<IEventReadDal, EFEventReadRepository>();
            services.AddScoped<IEventWriteDal, EFEventWriteRepository>();

            services.AddScoped<IPackageReadDal, EFPackageReadRepository>();
            services.AddScoped<IPackageWriteDal, EFPackageWriteRepository>();

            services.AddScoped<ISongReadDal, EFSongReadRepository>();
            services.AddScoped<ISongWriteDal, EFSongWriteRepository>();
        }
    }
}
