using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Expense
    {
        
        public Guid id { get; set; } = Guid.NewGuid();
        public string title { get; set; } = string.Empty;
        public string? description { get; set; }
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public PaymentType payment { get; set; }
    }
}
