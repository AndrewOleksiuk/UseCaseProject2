using Stripe;

namespace UseCaseProject2
{
	public interface IBalanceServiceWrapper
	{
		Balance GetBalance();
	}

	public class BalanceServiceWrapper : IBalanceServiceWrapper
	{
		public Balance GetBalance()
		{
			return new BalanceService().Get();
		}
	}

	public interface IBalanceTransactionServiceWrapper
	{
		StripeList<BalanceTransaction> ListTransactions(BalanceTransactionListOptions options);
	}

	public class BalanceTransactionServiceWrapper : IBalanceTransactionServiceWrapper
	{
		public StripeList<BalanceTransaction> ListTransactions(BalanceTransactionListOptions options)
		{
			return new BalanceTransactionService().List(options);
		}
	}
}
