using System.Reflection;

namespace ClipMind.VideoProcessing.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDefaultServices(this IServiceCollection services)
    {
        services.AddMediatR(conf => 
            conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}