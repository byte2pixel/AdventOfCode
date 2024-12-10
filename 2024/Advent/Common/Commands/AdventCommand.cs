using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Common.Commands;

public abstract class AdventCommand<TSettings>(IFileReader reader, IAnsiConsole console)
    : AsyncCommand<TSettings>
    where TSettings : CommandSettings
{
    protected readonly IAnsiConsole _console = console;
    protected readonly IFileReader _reader = reader;

    protected virtual string PromptForPartChoice()
    {
        return _console.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green]Advent of Code 2024[/]")
                .AddChoices("Part 1", "Part 2")
        );
    }
}
