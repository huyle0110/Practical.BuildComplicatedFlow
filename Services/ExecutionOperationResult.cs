using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Services
{
    public class ExecutionOperationResult : IExecutionOperationResult
    {
        public ExecutionOperationResult(string operationName, bool isSucceed = true, Exception? error = null)
        {
            if (string.IsNullOrEmpty(operationName)) {
                throw new ArgumentException("Parameter's value should not be null or empty string.", nameof(operationName));
            }

            OperationName = operationName;
            IsSucceed = isSucceed;

            if (!isSucceed && error == null || isSucceed && error != null) {
                throw new ArgumentException($"Parameter's value was{(error == null ? " " : " not ")}null, but{(isSucceed ? " " : " not ")}null value was expected ({nameof(isSucceed)} = {isSucceed}).");
            }

            Error = error;
        }

        public string OperationName { get; }
        public bool IsSucceed { get; }
        public Exception? Error { get; }

        public static ExecutionOperationResult DoneSuccessfully(string operationName)
        {
            return new ExecutionOperationResult(operationName);
        }

        public static ExecutionOperationResult Failed(string operationName, Exception? error)
        {
            return new ExecutionOperationResult(operationName, false, error);
        }
    }
}
