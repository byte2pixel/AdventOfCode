﻿using Advent.Commands;
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
});

return await app.RunAsync(args);
