using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using Practice.BuildComplicatedFlow.Steps.BaseStep;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart0
{
    public class CopyPart0Operation1 : CopyBaseProcess, ICopyOperation<ICopyContext>
    {
        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {
            await base.ExecuteCopyAsync(context);
            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyPart0Operation1));
        }

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {

            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
