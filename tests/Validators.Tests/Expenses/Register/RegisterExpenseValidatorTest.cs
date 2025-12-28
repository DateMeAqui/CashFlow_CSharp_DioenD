using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = new RequestRegisterExpenseJson
            {
                Title = "Title",
                Description = "Description",
                Amount = 100,
                Payment = PaymentType.DebitCard,
                Date = DateTime.Now.AddDays(-1),
            };

            //Act
            var result = validator.Validate(request);

            //Assert
            Assert.True(result.IsValid);
        }
    }
}
