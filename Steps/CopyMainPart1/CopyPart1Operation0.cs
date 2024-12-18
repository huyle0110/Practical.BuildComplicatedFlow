using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using Practice.BuildComplicatedFlow.Steps.BaseStep;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart1
{
    public class CopyPart1Operation0 : CopyBaseProcess, ICopyOperation<ICopyContext>
    {
        public CopyPart1Operation0()
        {
        }

        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {
            await base.ExecuteCopyAsync(context);
            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyPart1Operation0));
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

        protected override void RegisterSubActions()
        {
            AddSubAction(UsingEnumToBuildFlow.Enums.ContentTypeEnum.Type1, () => { return DoCopyType1(); });
            base.RegisterSubActions();
        }

        public async Task<bool> DoCopyType1()
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
