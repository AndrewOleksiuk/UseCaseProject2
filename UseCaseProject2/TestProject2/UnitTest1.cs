using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using UseCaseProject2.Controllers;
using UseCaseProject2;
using Stripe;

namespace TestProject2
{


	public class BalanceControllerTests
	{
		[Fact]
		public void Get_ReturnsBalance()
		{
			// Arrange
			var loggerMock = new Mock<ILogger<BalanceController>>();
			var balanceServiceMock = new Mock<IBalanceServiceWrapper>();
			var balanceTransactionServiceMock = new Mock<IBalanceTransactionServiceWrapper>();

			var dummyBalance = new Balance();
			balanceServiceMock.Setup(bs => bs.GetBalance()).Returns(dummyBalance);

			var controller = new BalanceController(loggerMock.Object, balanceServiceMock.Object, balanceTransactionServiceMock.Object);

			// Act
			var result = controller.Get();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(dummyBalance, okResult.Value);
		}
	}
}