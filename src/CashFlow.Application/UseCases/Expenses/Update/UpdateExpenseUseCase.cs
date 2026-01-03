using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseUpdateOnlyRepository _repository;
        public UpdateExpenseUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IExpenseUpdateOnlyRepository repository
            ) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<bool> Execute(Guid id, RequestRegisterExpenseJson request)
        {
            Validate(request);

            var expense = await _repository.GetById(id);

            if (expense is null) 
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            

            Expense expenseChange = _mapper.Map(request, expense);

            _repository.Update(expenseChange);

            await _unitOfWork.Commit();

            return true;
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
