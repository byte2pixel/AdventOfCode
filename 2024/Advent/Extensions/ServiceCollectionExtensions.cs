using Advent.Common;
using Advent.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Advent.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdventServices(this IServiceCollection services, string arg)
    {
        services.AddSingleton<IFileReader, FileReader>();
        return services;
    }
}
