using Advent.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

namespace Advent.Tests.IntegrationTests;

public class CommandAppTests : IClassFixture<TestFixture>
{
    private readonly TestConsole _console = new();
    private readonly FileReader _fileReader = new();
    private readonly ServiceCollection _services = new();
    private readonly DependencyInjectionRegistrar? _registrar;

    public CommandAppTests()
    {
        _console.Profile.Capabilities.Interactive = true;
        _services.AddSingleton<IFileReader>(_fileReader);
        _registrar = new DependencyInjectionRegistrar(_services);
    }

    [Fact]
    public async Task Day1Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day1", "--part", "Part 1" };
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
        result.Output.Should().Contain("Day 1 Part 1");
        result.Output.Should().Contain("The answer is 3508942");
    }

    [Fact]
    public async Task Day1Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day1", "--part", "Part 2" };
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
        result.Output.Should().Contain("Day 1 Part 2");
        result.Output.Should().Contain("The answer is 26593248");
    }

    [Fact]
    public async Task Day2Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day2", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day2Command>("day2");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 2 Part 1");
        result.Output.Should().Contain("The answer is 269");
    }

    [Fact]
    public async Task Day2Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day2", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day2Command>("day2");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 2 Part 2");
        result.Output.Should().Contain("The answer is 337");
    }

    #region Day3
    [Fact]
    public async Task Day3Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day3", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day3Command>("day3");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 3 Part 1");
        result.Output.Should().Contain("The answer is 166630675");
    }

    [Fact]
    public async Task Day3Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day3", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day3Command>("day3");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 3 Part 2");
        result.Output.Should().Contain("The answer is 93465710");
    }
    #endregion

    #region Day4
    [Fact]
    public async Task Day4Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day4", "--part", "Part 1", "--word", "XMAS" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day4Command>("day4");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 4 Part 1");
        result.Output.Should().Contain("The answer is 2618");
    }

    [Fact]
    public async Task Day4Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day4", "--part", "Part 2", "--word", "MAS" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.ConfigureConsole(_console);
            config.AddCommand<Day4Command>("day4");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 4 Part 2");
        result.Output.Should().Contain("The answer is 2011");
    }
    #endregion

    #region Day5
    [Fact]
    public async Task Day5Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day5", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day5Command>("day5");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 5 Part 1");
        result.Output.Should().Contain("The answer is 5639");
    }

    [Fact]
    public async Task Day5Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day5", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day5Command>("day5");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 5 Part 2");
        result.Output.Should().Contain("The answer is 5273");
    }
    #endregion

    #region Day6
    [Fact]
    public async Task Day6Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day6", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day6Command>("day6");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 6 Part 1");
        result.Output.Should().Contain("The answer is 5067");
    }

    [Fact]
    public async Task Day6Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day6", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day6Command>("day6");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 6 Part 2");
        result.Output.Should().Contain("The answer is 1793");
    }
    #endregion

    #region Day7
    [Fact]
    public async Task Day7Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day7", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day7Command>("day7");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 7 Part 1");
        result.Output.Should().Contain("The answer is 1620690235709");
    }

    [Fact]
    public async Task Day7Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day7", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day7Command>("day7");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 7 Part 2");
        result.Output.Should().Contain("The answer is 145397611075341");
    }
    #endregion

    #region Day8
    [Fact]
    public async Task Day8Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day8", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day8Command>("day8");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 8 Part 1");
        result.Output.Should().Contain("The answer is 379");
    }

    [Fact]
    public async Task Day8Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day8", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day8Command>("day8");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 8 Part 2");
        result.Output.Should().Contain("The answer is 1339");
    }
    #endregion

    #region Day9
    [Fact]
    public async Task Day9Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day9", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day9Command>("day9");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 9 Part 1");
        result.Output.Should().Contain("The answer is 6301895872542");
    }

    [Fact]
    public async Task Day9Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day9", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day9Command>("day9");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 9 Part 2");
        result.Output.Should().Contain("The answer is 6323761685944");
    }
    #endregion

    #region Day10
    [Fact]
    public async Task Day10Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day10", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day10Command>("day10");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 10 Part 1");
        result.Output.Should().Contain("The answer is 468");
    }

    [Fact]
    public async Task Day10Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day10", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day10Command>("day10");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 10 Part 2");
        result.Output.Should().Contain("The answer is 966");
    }
    #endregion

    #region Day11
    [Fact]
    public async Task Day11Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day11", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day11Command>("day11");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 11 Part 1");
        result.Output.Should().Contain("The answer is 203953");
    }

    [Fact]
    public async Task Day11Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day11", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day11Command>("day11");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 11 Part 2");
        result.Output.Should().Contain("The answer is 242090118578155");
    }
    #endregion

    #region Day12
    [Fact]
    public async Task Day12Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day12", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day12Command>("day12");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 12 Part 1");
        result.Output.Should().Contain("The answer is 1375476");
    }

    [Fact]
    public async Task Day12Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day12", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day12Command>("day12");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 12 Part 2");
        result.Output.Should().Contain("The answer is 821372");
    }
    #endregion

    #region Day13
    [Fact]
    public async Task Day13Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day13", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day13Command>("day13");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 13 Part 1");
        result.Output.Should().Contain("The answer is 26599");
    }

    [Fact]
    public async Task Day13Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day13", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day13Command>("day13");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 13 Part 2");
        result.Output.Should().Contain("The answer is 106228669504887");
    }
    #endregion

    #region Day14
    [Fact]
    public async Task Day14Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day14", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day14Command>("day14");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 14 Part 1");
        result.Output.Should().Contain("The answer is 214109808");
    }

    [Fact]
    public async Task Day14Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day14", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day14Command>("day14");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 14 Part 2");
        result.Output.Should().Contain("The answer is 7687");
        result.Output.Should().Contain("###############################");
    }
    #endregion

    #region Day15
    [Fact]
    public async Task Day15Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day15", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day15Command>("day15");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 15 Part 1");
        result.Output.Should().Contain("The answer is 1406628");
    }

    [Fact]
    public async Task Day15Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day15", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day15Command>("day15");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 15 Part 2");
        result.Output.Should().Contain("The answer is 1432781");
    }
    #endregion

    #region Day16
    [Fact]
    public async Task Day16Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day16", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day16Command>("day16");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 16 Part 1");
        result.Output.Should().Contain("The answer is 135536");
    }

    [Fact]
    public async Task Day16Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day16", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day16Command>("day16");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 16 Part 2");
        result.Output.Should().Contain("The answer is 583");
    }
    #endregion

    #region Day17
    [Fact]
    public async Task Day17Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day17", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day17Command>("day17");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 17 Part 1");
        result.Output.Should().Contain("The answer is 6,1,6,4,2,4,7,3,5");
    }

    [Fact]
    public async Task Day17Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day17", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day17Command>("day17");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 17 Part 2");
        result.Output.Should().Contain("The answer is 202975183645226");
    }
    #endregion

    #region Day18
    [Fact]
    public async Task Day18Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day18", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day18Command>("day18");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 18 Part 1");
        result.Output.Should().Contain("The answer is 404");
    }

    [Fact]
    public async Task Day18Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day18", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day18Command>("day18");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 18 Part 2");
        result.Output.Should().Contain("The answer is 27,60");
    }
    #endregion

    #region Day19
    [Fact]
    public async Task Day19Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day19", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day19Command>("day19");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 19 Part 1");
        result.Output.Should().Contain("The answer is 300");
    }

    [Fact]
    public async Task Day19Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day19", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day19Command>("day19");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 19 Part 2");
        result.Output.Should().Contain("The answer is 624802218898092");
    }
    #endregion

    #region Day20
    [Fact]
    public async Task Day20Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day20", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day20Command>("day20");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 20 Part 1");
        result.Output.Should().Contain("The answer is 1395");
    }

    [Fact]
    public async Task Day20Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day20", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day20Command>("day20");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 20 Part 2");
        result.Output.Should().Contain("The answer is 993178");
    }
    #endregion

    #region Day21
    [Fact]
    public async Task Day21Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day21", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day21Command>("day21");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 21 Part 1");
        result.Output.Should().Contain("The answer is 176870");
    }

    [Fact]
    public async Task Day21Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day21", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day21Command>("day21");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 21 Part 2");
        result.Output.Should().Contain("The answer is 223902935165512");
    }
    #endregion

    #region Day22
    [Fact]
    public async Task Day22Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day22", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day22Command>("day22");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 22 Part 1");
        result.Output.Should().Contain("The answer is 13753970725");
    }

    [Fact]
    public async Task Day22Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day22", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day22Command>("day22");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 22 Part 2");
        result.Output.Should().Contain("The answer is 1570");
    }
    #endregion

    #region Day23
    [Fact]
    public async Task Day23Part1_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day23", "--part", "Part 1" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day23Command>("day23");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 23 Part 1");
        result.Output.Should().Contain("The answer is 1227");
    }

    [Fact]
    public async Task Day23Part2_IntegrationTest_Success()
    {
        // Arrange
        var args = new string[] { "day23", "--part", "Part 2" };
        var app = new CommandAppTester(_registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureConsole(_console);
            config.AddCommand<Day23Command>("day23");
        });

        // Act
        var result = await app.RunAsync(args);

        // Assert
        result.ExitCode.Should().Be(0);
        result.Output.Should().Contain("Day 23 Part 2");
        result.Output.Should().Contain("The answer is cl,df,ft,ir,iy,ny,qp,rb,sh,sl,sw,wm,wy");
    }
    #endregion
}

public class TestFixture
{
    public TestFixture()
    {
        // One-time setup goes here
        Directory.SetCurrentDirectory("../../../");
    }
}
