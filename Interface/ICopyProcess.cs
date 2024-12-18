using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Interface
{
    public interface ICopyProcess
    {
        Task<IExecutionOperationResult> ExecuteStepAsync(ICopyContext copyContext, CopyMainStep step);
    }
}
