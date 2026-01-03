using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public interface IUpdateExpenseUseCase
    {
        Task<bool> Execute(Guid id, RequestRegisterExpenseJson request);
    }
}
