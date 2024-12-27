using System.Reflection;

namespace Advent.Common;

public class FileReader : IFileReader
{
    private readonly Assembly _assembly;

    public FileReader()
    {
        _assembly = Assembly.GetExecutingAssembly();
    }

    public async Task<string> ReadInputAsync(string day)
    {
        // Adjust file name to match embedded resource format
        var resourceName = _assembly
            .GetManifestResourceNames()
            .FirstOrDefault(name => name == $"Advent.{day}input.txt");

        if (resourceName == null)
            throw new FileNotFoundException($"Resource {day} not found in embedded resources.");

        using var stream =
            _assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException(
                $"Resource stream for {day} not found in embedded resources."
            );
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}
