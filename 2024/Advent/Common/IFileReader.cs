namespace Advent.Common;

public interface IFileReader
{
    Task<string> ReadInputAsync(string day); // eg. day1, day15, day25
}
