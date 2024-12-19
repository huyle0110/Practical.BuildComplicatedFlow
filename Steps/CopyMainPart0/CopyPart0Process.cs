using Practice.BuildComplicatedFlow.Common;
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
            _context.CustomDataLogging = new CustomDataLogging
            {
                ActionName = nameof(CopyType1),
                StepNumber = (int)CopyMainStep.CopyMainPart0,
                StepName = nameof(CopyMainStep.CopyMainPart0),
                SubStepNumber = (int)CopyMainPart0StepEnum.Task1,
                SubStepName = nameof(CopyMainPart0StepEnum.Task1)
            };
            LogFactory.LogStart(_context.Logger, _context.CustomDataLogging);
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
