namespace Advent.Common;

public interface IFileReader
{
    Task<string> ReadInputAsync(string path);
}
