namespace Advent.UseCases.Day9;

internal static class Day9Parser
{
    enum State
    {
        FileLength,
        FreeSpace,
    }

    internal static Span<uint> Parse(string input)
    {
        State _state = State.FileLength;
        uint _fileId = 0;
        List<uint> _result = [];
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new InvalidOperationException("Invalid input");
        }

        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            ProcessLine(line, ref _state, ref _fileId, ref _result);
        }
        return _result.ToArray();
    }

    private static void ProcessLine(
        string line,
        ref State _state,
        ref uint _fileId,
        ref List<uint> _result
    )
    {
        foreach (var c in line)
        {
            ProcessCharacter(c, ref _state, ref _fileId, ref _result);
        }
    }

    private static void ProcessCharacter(
        char c,
        ref State _state,
        ref uint _fileId,
        ref List<uint> _result
    )
    {
        var digit = int.Parse(c.ToString());
        switch (_state)
        {
            case State.FileLength:
            {
                HandleFile(digit, ref _state, ref _fileId, ref _result);
                return;
            }
            case State.FreeSpace:
            {
                HandleFreeSpace(digit, ref _state, ref _result);
                return;
            }
        }
    }

    private static void HandleFreeSpace(int digit, ref State _state, ref List<uint> _result)
    {
        if (digit != 0)
        {
            AddPositionsForFileId(digit, uint.MaxValue, ref _result);
        }
        _state = State.FileLength;
    }

    private static void HandleFile(
        int digit,
        ref State _state,
        ref uint _fileId,
        ref List<uint> _result
    )
    {
        if (digit == 0)
        {
            throw new InvalidOperationException("Invalid input");
        }
        else
        {
            AddPositionsForFileId(digit, _fileId, ref _result);
        }
        _fileId++;
        _state = State.FreeSpace;
    }

    private static void AddPositionsForFileId(int digit, uint fileId, ref List<uint> _result)
    {
        for (int i = 0; i < digit; i++)
        {
            _result.Add(fileId);
        }
    }
}
