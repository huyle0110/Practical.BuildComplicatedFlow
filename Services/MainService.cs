using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Steps.CopyMainPart0;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Services
{
    public class MainService : IMainService
    {
        private readonly ILogger<MainService> _logger;
        private readonly ICopyProcess _copyProcess;
        public MainService(ILogger<MainService> logger, ICopyProcess copyProcess)
        {
            _logger = logger;
            _copyProcess = copyProcess;
        }

        public async Task ExecuteAsync()
        {
            var copyContext = new CopyContext()
            {
                Logger = _logger
            };

            copyContext.TempServiceProvider = BuildServiceProvider();

            //Execute step by step
            foreach(CopyMainStep step in Enum.GetValues(typeof(CopyMainStep)))
            {
                copyContext.Step = step;
                await _copyProcess.ExecuteStepAsync(copyContext, step);
            }
        }

        private IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<CopyPart0Process>();
            return services.BuildServiceProvider();
        }
    }
}
