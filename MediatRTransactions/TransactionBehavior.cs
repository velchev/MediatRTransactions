
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MediatRTransactions
{
	public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		/// <inheritdoc/>
		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var transactionOptions = new TransactionOptions
			{
				IsolationLevel = IsolationLevel.ReadCommitted,
				Timeout = TransactionManager.MaximumTimeout,
			};

			using (var transaction = new TransactionScope(
				TransactionScopeOption.Required,
				transactionOptions,
				TransactionScopeAsyncFlowOption.Enabled))
			{
				// handle request handler
				var response = await next();

				// complete database transaction
				transaction.Complete();

				return response;
			}
		}
	}
}
