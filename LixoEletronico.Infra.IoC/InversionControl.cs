﻿using LixoEletronico.Application;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LixoEletronico.Infra.IoC
{
    public static class InversionControl
    {
        public static void AddInfraestructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(
                context => context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped<IPersonService, PersonService>();
            serviceCollection.AddScoped<IGeneralRepository, GeneralRepository>();
            serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}