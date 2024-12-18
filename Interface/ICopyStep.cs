namespace Practice.BuildComplicatedFlow.Interface
{
    public interface ICopyStep<TContext> : IDisposable
    {
        Task<IExecutionOperationResult> ExecuteAsync(TContext context);
    }
}
