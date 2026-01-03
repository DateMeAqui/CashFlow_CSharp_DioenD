using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseUpdateOnlyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Expense?> GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expense"></param>
        void Update(Expense expense);
    }
}
