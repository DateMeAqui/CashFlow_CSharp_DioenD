using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using commonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void ErrorTitleEmpty(string title)
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = title;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.THE_TITLE_IS_REQUIRED);

        }

        [Fact]
        public void ErrorDateFuture()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(3);

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.EXPENSES_CANNOT_BE_FOR_THE_FUTURE);

        }

        [Fact]
        public void ErrorPaymentTypeInvalid()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Payment = (PaymentType)30;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.PAYMENT_TYPE_IS_NOT_VALID);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void ErrorAmountValid(decimal amount)
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.THE_AMOUNT_MUST_BE_GREATER_THEN_ZERO);
        }    

    }
}
