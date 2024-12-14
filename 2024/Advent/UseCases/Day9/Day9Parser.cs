namespace Advent.UseCases.Day9;

public class Day9Parser
{
    enum State
    {
        FileLength,
        FreeSpace,
    }

    private State _state = State.FileLength;
    private uint _fileId = 0;
    private readonly List<uint> _result = [];

    public Span<uint> Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new InvalidOperationException("Invalid input");
        }

        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            ProcessLine(line);
        }
        return _result.ToArray();
    }

    private void ProcessLine(string line)
    {
        foreach (var c in line)
        {
            ProcessCharacter(c);
        }
    }

    private void ProcessCharacter(char c)
    {
        var digit = int.Parse(c.ToString());
        switch (_state)
        {
            case State.FileLength:
            {
                HandleFile(digit);
                return;
            }
            case State.FreeSpace:
            {
                HandleFreeSpace(digit);
                return;
            }
        }
    }

    private void HandleFreeSpace(int digit)
    {
        if (digit != 0)
        {
            AddPositionsForFileId(digit, uint.MaxValue);
        }
        _state = State.FileLength;
    }

    private void HandleFile(int digit)
    {
        if (digit == 0)
        {
            throw new InvalidOperationException("Invalid input");
        }
        else
        {
            AddPositionsForFileId(digit, _fileId);
        }
        _fileId++;
        _state = State.FreeSpace;
    }

    private void AddPositionsForFileId(int digit, uint fileId)
    {
        for (int i = 0; i < digit; i++)
        {
            _result.Add(fileId);
        }
    }
}
