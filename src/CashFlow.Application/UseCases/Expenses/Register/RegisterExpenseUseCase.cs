using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public  class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                id = Guid.NewGuid(),
                amount = request.Amount,
                date = request.Date,
                description = request.Description,
                title = request.Title,
                payment = (Domain.Enums.PaymentType)request.Payment
            };

            return new ResponseRegisterExpenseJson();
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();

            var response = validator.Validate(request);

            if (!response.IsValid)
            {
                var errorMessages = response.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);

            }



        }
    }
}
