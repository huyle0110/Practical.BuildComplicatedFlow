namespace Practice.BuildComplicatedFlow.Interface
{
    public interface ICopyOperation<TContext> : IDisposable
    {
        Task<IExecutionOperationResult> ExecuteAsync(TContext context);
    }
}
