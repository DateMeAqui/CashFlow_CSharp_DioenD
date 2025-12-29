using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<CashFlowDbContext>();
        }
    }
}
