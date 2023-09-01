using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace UseCaseProject2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BalanceController : ControllerBase
	{
		private readonly ILogger<BalanceController> _logger;

		public BalanceController(ILogger<BalanceController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetBalance")]
		public IActionResult Get()
		{
			StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";
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
	}
}