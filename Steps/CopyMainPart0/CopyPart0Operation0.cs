using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using Practice.BuildComplicatedFlow.Steps.BaseStep;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart0
{
    public class CopyPart0Operation0 : ICopyOperation<ICopyContext>
    {
        public CopyPart0Operation0()
        {
        }

        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {
            var copyPart1Process = context.TempServiceProvider.GetService<CopyPart0Process>();
            await copyPart1Process.ExecuteCopyAsync(context);
            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyPart0Operation0));
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
    }
}
