using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpenseUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ExpensesRepository(CashFlowDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task Add(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
        }

        public async Task<bool> Delete(Guid id)
        {
            var expenseDel = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.id == id);
            if (expenseDel is null)
            {
                return false;
            }
            _dbContext.Expenses.Remove(expenseDel);
            return true;
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _dbContext.Expenses.AsNoTracking().ToListAsync();
        }

        async Task<Expense?> IExpensesReadOnlyRepository.GetById(Guid id)
        {
            return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.id == id);
        }

        async Task<Expense?> IExpenseUpdateOnlyRepository.GetById(Guid id)
        {
            return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.id == id);
        }

        public void Update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }

        public async Task<List<Expense>> FilterByMonth(DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour:23, minute: 59, second: 59);
            return await _dbContext
                .Expenses
                .AsNoTracking()
                .Where(expense => expense.date >= startDate && expense.date <= endDate)
                .OrderBy(expense => expense.date)
                .ToListAsync();
        }
    }
}
