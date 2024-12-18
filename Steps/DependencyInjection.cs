using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Steps.Clean;
using Practice.BuildComplicatedFlow.Steps.CopyMainPart0;
using Practice.BuildComplicatedFlow.Steps.CopyMainPart1;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Steps
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMainFlowCopy(this IServiceCollection services)
        {
            services.AddScoped<CopyMainPart0Step>();
            services.AddScoped<CopyMainPart1Step>();
            services.AddScoped<CleanStep>();
            services.AddScoped<Func<CopyMainStep, ICopyStep<ICopyContext>>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CopyMainStep.CopyMainPart0:
                        return serviceProvider.GetService<CopyMainPart0Step>();

                    case CopyMainStep.CopyMainPart1:
                        return serviceProvider.GetService<CopyMainPart1Step>();
                    
                    case CopyMainStep.Clean:
                        return serviceProvider.GetService<CleanStep>();
                    default:
                        return null;
                }
            });
            return services;
        }
    }
}
