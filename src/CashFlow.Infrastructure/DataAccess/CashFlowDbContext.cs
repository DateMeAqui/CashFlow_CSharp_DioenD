using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    public class CashFlowDbContext : DbContext
    {
        // Variavel que dara acesso a tabela expenses
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=root_password_123";

            var serverVersion = new MySqlServerVersion(new Version(8,0));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
