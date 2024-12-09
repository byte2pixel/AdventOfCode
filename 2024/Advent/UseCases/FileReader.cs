using Advent.Common;

namespace Advent.UseCases;

public class FileReader : IFileReader
{
    public async Task<string> ReadInputAsync(string path)
    {
        return await File.ReadAllTextAsync(path);
    }
}
