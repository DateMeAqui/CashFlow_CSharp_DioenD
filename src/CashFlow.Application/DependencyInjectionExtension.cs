using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.GetAllExpense;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddUseCase(service);
            AddAutoMapper(service);
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }
        private static void AddUseCase(IServiceCollection service)
        {
            service.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            service.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
            service.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        }
    }
}
