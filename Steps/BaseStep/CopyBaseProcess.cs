using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Steps.BaseStep
{
    public abstract class CopyBaseProcess : CustomDisposable, ICopyBaseProcess<ICopyContext>
    {
        protected Dictionary<ContentTypeEnum, Func<Task<bool>>> subActions = new Dictionary<ContentTypeEnum, Func<Task<bool>>>();
        private ICopyContext _context;
        protected CopyBaseProcess()
        {
        }

        protected void AddSubAction(ContentTypeEnum contentTypeEnum, Func<Task<bool>> func)
        {
            subActions[contentTypeEnum] = func;
        }

        protected void ClearActions()
        {
            subActions.Clear();
        }

        public async Task<IExecutionOperationResult> ExecuteCopyAsync(ICopyContext context)
        {
            _context = context;
            await PreExecuteAsync();
            await ExecutingAsync();
            await PostExecuteAsync();
            return ExecutionOperationResult.DoneSuccessfully(nameof(CopyBaseProcess));
        }

        public virtual async Task PreExecuteAsync()
        {
            _context.Logger.LogInformation("Pre");
            RegisterSubActions();
            await Task.CompletedTask;
        }

        protected virtual void RegisterSubActions()
        {
            AddSubAction(ContentTypeEnum.TypeCommon1, () => { return CopyTypeCommon1(ContentTypeEnum.TypeCommon1); });
            AddSubAction(ContentTypeEnum.TypeCommon2, () => { return CopyTypeCommon2(ContentTypeEnum.TypeCommon2); });
        }

        private async Task<bool> CopyTypeCommon1(ContentTypeEnum contentTypeEnum)
        {
            await Task.CompletedTask;
            return true;
        }

        private async Task<bool> CopyTypeCommon2(ContentTypeEnum contentTypeEnum)
        {
            await Task.CompletedTask;
            return true;
        }

        public virtual async Task ExecutingAsync()
        {
            _context.Logger.LogInformation("ExecutingAsync");
            foreach (var action in subActions.Values)
            { 
                await action.Invoke();
            }
        }

        public virtual async Task PostExecuteAsync()
        {
            _context.Logger.LogInformation("PostExecuteAsync");
            //Todo SaveChanges
        }
    }
}
