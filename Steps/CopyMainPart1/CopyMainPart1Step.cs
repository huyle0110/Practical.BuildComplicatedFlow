using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart1
{
    public class CopyMainPart1Step : ICopyStep<ICopyContext>
    {
        private readonly Func<CopyMainPart1StepEnum, ICopyOperation<ICopyContext>> _serviceResolver;
        public CopyMainPart1Step(Func<CopyMainPart1StepEnum, ICopyOperation<ICopyContext>> serviceResolver)
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
            foreach(CopyMainPart1StepEnum step in Enum.GetValues(typeof(CopyMainPart1StepEnum)))
            {
                using (var operation = _serviceResolver(step))
                { 
                    var executionResult = operation.ExecuteAsync(context);
                }
            }

            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyMainPart1Step));
        }
    }
}
