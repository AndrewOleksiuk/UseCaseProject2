using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace UseCaseProject2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BalanceController : ControllerBase
	{
		private readonly ILogger<BalanceController> _logger;
		private readonly IBalanceServiceWrapper _balanceServiceWrapper;
		private readonly IBalanceTransactionServiceWrapper _balanceTransactionServiceWrapper;
		private const string API_KEY = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

		public BalanceController(ILogger<BalanceController> logger, IBalanceServiceWrapper balanceServiceWrapper, IBalanceTransactionServiceWrapper balanceTransactionServiceWrapper)
		{
			_logger = logger;
			_balanceServiceWrapper = balanceServiceWrapper;
			_balanceTransactionServiceWrapper = balanceTransactionServiceWrapper;
		}

		[HttpGet]
		public IActionResult Get()
		{
			StripeConfiguration.ApiKey = API_KEY;
			var balanceService = new BalanceService();

			try
			{
				Balance balance = balanceService.Get();
				return Ok(balance);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error: {ex}");
				return NoContent();
			}
		}

		[HttpGet("paginated")]
		public IActionResult GetPaginated([FromQuery] int number, string? startingAfter)
		{
			StripeConfiguration.ApiKey = API_KEY;
			var balanceTransactionService = new BalanceTransactionService();

			try
			{
				var balanceTransactionOptions = new BalanceTransactionListOptions
				{
					Limit = number,
					StartingAfter = startingAfter ?? null
				};

				var balanceTransactions = balanceTransactionService.List(balanceTransactionOptions);
				return Ok(balanceTransactions);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error: {ex}");
				return NoContent();
			}
		}
	}
}