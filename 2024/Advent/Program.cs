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
});

return await app.RunAsync(args);
