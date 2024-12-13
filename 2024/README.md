# AdventOfCode 2024 CLI

Welcome to the AdventOfCode 2024 CLI! This tool helps you manage and run my Advent of Code solutions for the year 2024.

## Installation

Clone the repository and open a terminal to the AdventOfCode folder

```sh
cd ./2024/Advent
dotnet build
```

## Usage

Here are some common commands you can use with the AdventOfCode 2024 CLI:

### Run Solutions (Option 1)

Using the dotnet cli.

The base command for each day is `day#`

Example from `./2024/Advent` folder

```sh
dotnet run -- day1
dotnet run -- day2
dotnet run -- day3
dotnet run -- day6
```

Each day may have multipl parts use the help command to see additional arguments.
If an argument is not specified but required you will be prompted to make a selection.

```sh
dotnet run -- day1 --help
```

Example:

```sh
dotnet run -- day1 --part "Part 1"
dotnet run -- day1 --part "Part 2"
```

### Run Solutions (Option 1)

Example from `./2024/Advent` folder
The key is the input folder with all the input files needs to be located in the current directory.

```sh
dotnet build -c Release
./bin/Release/net9.0/Advent.exe --help
./bin/Release/net9.0/Advent.exe day1
./bin/Release/net9.0/Advent.exe day6 --part "Part 2"
```

## Tests

I wrote the code using tests first using the sample data they gave in the examples.
Funny how sometimes you'll get the code working against the test data but then find it fails on the real data.
Seemed to be 50/50 for me.

From repository root:

```sh
dotnet test ./2024/2024.sln
```

## License

This project is licensed under the MIT License.

Happy coding!
