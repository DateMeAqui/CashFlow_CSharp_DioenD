using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        Task Add(Expense expense);

        /// <summary>
        /// This function return TRUE if the deletion was successful otherwise returns FALSE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}
