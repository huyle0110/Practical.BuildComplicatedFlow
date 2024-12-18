using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Steps.CopyMainPart0
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCopyMainPart0(this IServiceCollection services)
        {
            services.AddScoped<CopyPart0Operation0>();
            services.AddScoped<CopyPart0Operation1>();
            services.AddScoped<Func<CopyMainPart0StepEnum, ICopyOperation<ICopyContext>>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CopyMainPart0StepEnum.Task0:
                        return serviceProvider.GetService<CopyPart0Operation0>();
                    case CopyMainPart0StepEnum.Task1:
                        return serviceProvider.GetService<CopyPart0Operation1>();
                    default:
                        return null;
                }
            });
            return services;
        }
    }
}
