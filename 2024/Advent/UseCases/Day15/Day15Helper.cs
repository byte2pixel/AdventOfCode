namespace Advent.UseCases.Day15;

public static class Day15Helper
{
    public static string TableMarkup(string value)
    {
        // find the @ character and then surround it with
        // [bold green]@[/] and preserve the rest of the string
        return value
            .Replace("[]", "[bold green][[]][/]")
            .Replace("O", "[bold green]O[/]")
            .Replace("#", "[bold red]#[/]")
            .Replace("@", "[bold yellow]@[/]");
    }
}
