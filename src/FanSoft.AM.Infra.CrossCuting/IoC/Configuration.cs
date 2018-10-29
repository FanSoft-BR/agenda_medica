using FanSoft.AM.Domain.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FanSoft.AM.Infra.CrossCuting.IoC
{
    public class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            registerMediatr(services);
            registerData(services);

        }

        private static void registerMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "FanSoft.AM.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR();
        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.AgendaMedicaDataContext>();
            services.AddTransient<Domain.Contracts.Infra.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            services.AddTransient<Domain.Contracts.Repositories.IPacienteReadRepository, Data.EF.Repositories.PacienteReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IPacienteWriteRepository, Data.EF.Repositories.PacienteWriteRepositoryEF>();
        }
        
    }
}
