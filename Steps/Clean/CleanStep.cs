using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;

namespace Practice.BuildComplicatedFlow.Steps.Clean
{
    public class CleanStep : ICopyStep<ICopyContext>
    {
        private readonly Func<CleanStepEnum, ICopyOperation<ICopyContext>> _serviceResolver;
        public CleanStep(Func<CleanStepEnum, ICopyOperation<ICopyContext>> serviceResolver)
        {
            _serviceResolver = serviceResolver ?? throw new ArgumentNullException();
        }

        public bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing) {
                // Free any other managed objects here.
            }

            _disposed = true;
        }

        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {
            foreach(CleanStepEnum step in Enum.GetValues(typeof(CleanStepEnum)))
            {
                using (var operation = _serviceResolver(step))
                { 
                    var executionResult = operation.ExecuteAsync(context);
                }
            }

            return ExecutionOperationResult.DoneSuccessfully(nameof(CleanStep));
        }
    }
}
