using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Steps.BaseStep;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart0
{
    public class CopyPart0Process: CopyBaseProcess
    {
        protected override void RegisterSubActions()
        {
            AddSubAction(ContentTypeEnum.Type1, () => { return CopyType1(ContentTypeEnum.Type1); });
            base.RegisterSubActions();
        }

        private async Task<bool> CopyType1(ContentTypeEnum contentTypeEnum)
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
