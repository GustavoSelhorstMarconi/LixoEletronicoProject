using LixoEletronico.Application;
using LixoEletronico.Application.Contracts;
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

            serviceCollection.AddScoped<ICompanyService, CompanyService>();
            serviceCollection.AddScoped<ICompanyRepository, CompanyRepository>();

            serviceCollection.AddScoped<IReviewService, ReviewService>();
            serviceCollection.AddScoped<IReviewRepository, ReviewRepository>();
        }
    }
}