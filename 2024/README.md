# AdventOfCode 2024 CLI

Welcome to the AdventOfCode 2024 CLI! This tool helps you manage and run my Advent of Code solutions for the year 2024.

## Building Exe

Clone the repository and open a terminal to the AdventOfCode folder

```sh
cd ./2024/Advent
dotnet publish -c Release
```

## Usage

Here are some common commands you can use with the AdventOfCode 2024 CLI:

### Run using dotnet CLI

Using the dotnet cli.

The base command for each day is `day#`

Example from `./2024/Advent` folder

```sh
dotnet run -- day1
dotnet run -- day2 --part 2
dotnet run -- day6 -p 1
dotnet run -- day15 --help
dotnet run -- day25
```

Each day has multiple parts use the help command to see additional arguments.
If an argument is not specified but required you will be prompted to make a selection.

### Run using exe

If you run the publish command you will get a single file exe that is fully
self-contained. Publish for your target os and run it as if you would any other CLI

```sh
dotnet publish -c Release --runtime win-x64
dotnet publish -c Release --runtime linux-x64
dotnet publish -c Release --runtime osx-64
# \bin\Release\net9.0\linux-x64\publish
# \bin\Release\net9.0\win-x64\publish
# \bin\Release\net9.0\osx-x64\publish
./bin/Release/net9.0/Advent.exe --help
./bin/Release/net9.0/Advent.exe day1
./bin/Release/net9.0/Advent.exe day6 --part 2
```

## Tests

I wrote the code using tests first using the sample data they gave in the examples.
Funny how sometimes you'll get the code working against the test data but then find it fails on the real data.
Seemed to be 50/50 for me.

```sh
# from root
dotnet test ./2024

# from ./2024
dotnet test
```

## License

This project is licensed under the MIT License.

Happy coding!
