using Advent.Common;
using Advent.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Advent.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdventServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileReader, FileReader>();
        services.AddSingleton(AnsiConsole.Console);
        return services;
    }
}
