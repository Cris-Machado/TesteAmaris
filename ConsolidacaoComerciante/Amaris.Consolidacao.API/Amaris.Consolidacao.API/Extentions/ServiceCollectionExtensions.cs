using Amaris.Consolidacao.IoC;

namespace Amaris.Consolidacao.API.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNativeIoC(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            RegisterAllServices(serviceCollection, configuration);
        }
        private static void RegisterAllServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            InjectorBootStrapper.RegisterServices(serviceCollection, configuration);
        }
    }
}
