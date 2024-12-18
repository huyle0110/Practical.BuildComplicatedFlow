using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart0
{
    public class CopyMainPart0Step : ICopyStep<ICopyContext>
    {
        private readonly Func<CopyMainPart0StepEnum, ICopyOperation<ICopyContext>> _serviceResolver;
        public CopyMainPart0Step(Func<CopyMainPart0StepEnum, ICopyOperation<ICopyContext>> serviceResolver)
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
            foreach(CopyMainPart0StepEnum step in Enum.GetValues(typeof(CopyMainPart0StepEnum)))
            {
                using (var operation = _serviceResolver(step))
                { 
                    var executionResult = operation.ExecuteAsync(context);
                }
            }

            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyMainPart0Step));
        }
    }
}
