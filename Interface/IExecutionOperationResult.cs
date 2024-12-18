namespace Practice.BuildComplicatedFlow.Interface
{
    public interface IExecutionOperationResult
    {
        string OperationName { get; }
        bool IsSucceed { get; }
        Exception Error { get; }
    }
}
