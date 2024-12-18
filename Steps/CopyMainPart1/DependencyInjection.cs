using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCopyMainPart1(this IServiceCollection services)
        {
            services.AddScoped<CopyPart1Operation0>();
            services.AddScoped<CopyPart1Operation1>();
            services.AddScoped<Func<CopyMainPart1StepEnum, ICopyOperation<ICopyContext>>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CopyMainPart1StepEnum.Task0:
                        return serviceProvider.GetService<CopyPart1Operation0>();
                    case CopyMainPart1StepEnum.Task1:
                        return serviceProvider.GetService<CopyPart1Operation1>();
                    default:
                        return null;
                }
            });
            return services;
        }
    }
}
