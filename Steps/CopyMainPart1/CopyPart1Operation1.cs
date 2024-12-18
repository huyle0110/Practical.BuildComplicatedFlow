using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using Practice.BuildComplicatedFlow.Steps.BaseStep;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart1
{
    public class CopyPart1Operation1 : CopyBaseProcess, ICopyOperation<ICopyContext>
    {
        public CopyPart1Operation1()
        {
        }

        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {
            await base.ExecuteCopyAsync(context);
            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyPart1Operation1));
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
