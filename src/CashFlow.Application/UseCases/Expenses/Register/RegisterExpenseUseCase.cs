using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public  class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesRepository _repository;
        public RegisterExpenseUseCase(IExpensesRepository repository)
        {
            _repository = repository;
        }
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

            _repository.Add(entity);

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
