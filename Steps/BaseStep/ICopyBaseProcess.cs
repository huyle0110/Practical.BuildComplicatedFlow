using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Steps.BaseStep
{
    public interface ICopyBaseProcess<TContext> where TContext : class
    {
        Task<IExecutionOperationResult> ExecuteCopyAsync(TContext context);
    }
}
