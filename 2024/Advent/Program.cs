using Advent.Commands;
using Advent.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAdventServices();

using var registrar = new DependencyInjectionRegistrar(services);
var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<Day1Command>("day1").WithDescription("Advent of Code 2024 Day 1");
    config.AddCommand<Day2Command>("day2").WithDescription("Advent of Code 2024 Day 2");
    config.AddCommand<Day3Command>("day3").WithDescription("Advent of Code 2024 Day 3");
    config.AddCommand<Day4Command>("day4").WithDescription("Advent of Code 2024 Day 4");
    config.AddCommand<Day5Command>("day5").WithDescription("Advent of Code 2024 Day 5");
    config.AddCommand<Day6Command>("day6").WithDescription("Advent of Code 2024 Day 6");
    config.AddCommand<Day7Command>("day7").WithDescription("Advent of Code 2024 Day 7");
    config.AddCommand<Day8Command>("day8").WithDescription("Advent of Code 2024 Day 8");
    config.AddCommand<Day9Command>("day9").WithDescription("Advent of Code 2024 Day 9");
    config.AddCommand<Day10Command>("day10").WithDescription("Advent of Code 2024 Day 10");
    config.AddCommand<Day11Command>("day11").WithDescription("Advent of Code 2024 Day 11");
    config.AddCommand<Day12Command>("day12").WithDescription("Advent of Code 2024 Day 12");
    config.AddCommand<Day13Command>("day13").WithDescription("Advent of Code 2024 Day 13");
    config.AddCommand<Day14Command>("day14").WithDescription("Advent of Code 2024 Day 14");
    config.AddCommand<Day15Command>("day15").WithDescription("Advent of Code 2024 Day 15");
    config.AddCommand<Day16Command>("day16").WithDescription("Advent of Code 2024 Day 16");
    config.AddCommand<Day17Command>("day17").WithDescription("Advent of Code 2024 Day 17");
    config.AddCommand<Day18Command>("day18").WithDescription("Advent of Code 2024 Day 18");
    config.AddCommand<Day19Command>("day19").WithDescription("Advent of Code 2024 Day 19");
    config.AddCommand<Day20Command>("day20").WithDescription("Advent of Code 2024 Day 20");
    config.AddCommand<Day21Command>("day21").WithDescription("Advent of Code 2024 Day 21");
});

return await app.RunAsync(args);
