using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.THE_TITLE_IS_REQUIRED);
            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.THE_AMOUNT_MUST_BE_GREATER_THEN_ZERO);
            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_BE_FOR_THE_FUTURE);
            RuleFor(expense => expense.Payment)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.PAYMENT_TYPE_IS_NOT_VALID);
        }
    }
}
