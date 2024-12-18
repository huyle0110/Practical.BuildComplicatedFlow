using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Steps.Clean
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClean(this IServiceCollection services)
        {
            services.AddScoped<CleanOperation0>();
            services.AddScoped<CleanOperation1>();
            services.AddScoped<Func<CleanStepEnum, ICopyOperation<ICopyContext>>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CleanStepEnum.Task0:
                        return serviceProvider.GetService<CleanOperation0>();
                    case CleanStepEnum.Task1:
                        return serviceProvider.GetService<CleanOperation1>();
                    default:
                        return null;
                }
            });
            return services;
        }
    }
}
