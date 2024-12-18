using Practice.BuildComplicatedFlow.Interface;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Services
{
    public class CopyProcess : ICopyProcess
    {
        private readonly ILogger<CopyProcess> _logger;
        private readonly Func<CopyMainStep, ICopyStep<ICopyContext>> _serviceResolver;
        public CopyProcess(Func<CopyMainStep, ICopyStep<ICopyContext>> serviceResolver, ILogger<CopyProcess> logger)
        {
            _serviceResolver = serviceResolver;
            _logger = logger;
        }
        
        public Task<IExecutionOperationResult> ExecuteStepAsync(ICopyContext copyContext, CopyMainStep step)
        {
            using (var stepService = _serviceResolver(step))
            {
                return stepService.ExecuteAsync(copyContext);
            }
        }
    }
}
