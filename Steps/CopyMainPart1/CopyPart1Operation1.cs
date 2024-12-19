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

        protected override void RegisterSubActions()
        {
            AddSubAction(UsingEnumToBuildFlow.Enums.ContentTypeEnum.Type2, () => { return DoCopyType2(); });
            base.RegisterSubActions();
        }

        public async Task<bool> DoCopyType2()
        {
            await Task.CompletedTask;
            return true;
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
