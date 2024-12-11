using Advent.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

namespace Advent.Tests.IntegrationTests
{
    public class CommandAppTests
    {
        private const string _basePath = "../../../";
        private readonly TestConsole _console = new();
        private readonly FileReader _fileReader = new();
        private readonly ServiceCollection _services = new();
        private readonly DependencyInjectionRegistrar? _registrar;

        public CommandAppTests()
        {
            Directory.SetCurrentDirectory(_basePath);
            _console.Profile.Capabilities.Interactive = true;
            _services.AddSingleton<IFileReader>(_fileReader);
            _registrar = new DependencyInjectionRegistrar(_services);
        }

        [Fact(Skip = "Console is not interactive, bug in CommandAppTester")]
        public async Task Test1()
        {
            // Arrange
            var args = new string[] { "day1" };
            var app = new CommandAppTester(_registrar);

            app.Configure(config =>
            {
                config.ConfigureConsole(_console);
                config.AddCommand<Day1Command>("day1");
            });

            // Act
            var result = await app.RunAsync(args);

            // Assert
            result.ExitCode.Should().Be(0);
        }
    }
}
