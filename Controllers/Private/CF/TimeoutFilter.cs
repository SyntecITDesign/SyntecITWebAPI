using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Controllers.Private.CF
{
	public class TimeoutFilter : ActionFilterAttribute, IAsyncResourceFilter
	{
		#region Public Constructors + Destructors

		public TimeoutFilter( int miliSeconds )
		{
			m_timeoutSetting = miliSeconds;
		}

		#endregion Public Constructors + Destructors

		#region Public Methods

		public async Task OnResourceExecutionAsync( ResourceExecutingContext context, ResourceExecutionDelegate next )
		{
			using CancellationTokenSource timeoutSource = CancellationTokenSource.CreateLinkedTokenSource( context.HttpContext.RequestAborted );
			timeoutSource.CancelAfter( m_timeoutSetting );
			context.HttpContext.RequestAborted = timeoutSource.Token;
			// We create a TaskCompletionSource
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>( TaskCreationOptions.RunContinuationsAsynchronously );

			// Registering a lambda into the cancellationToken
			timeoutSource.Token.Register( () =>
			{
				// We received a cancellation message, cancel the TaskCompletionSource.Task
				taskCompletionSource.TrySetCanceled();
			} );

			// Wait for the first task to finish among the two
			var completedTask = await Task.WhenAny( next(), taskCompletionSource.Task ).ConfigureAwait( false );

			await completedTask.ConfigureAwait( false );
		}

		#endregion Public Methods

		#region Private Fields

		private readonly int m_timeoutSetting;

		#endregion Private Fields
	}
}
