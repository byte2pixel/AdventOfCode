using System.Collections.Immutable;

namespace Advent.Tests.Common;

internal static class TestData
{
    internal const string Day5TestData =
        "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

    // csharpier-ignore
    internal const string Day6TestData =
          "....#.....\n"
        + ".........#\n"
        + "..........\n"
        + "..#.......\n"
        + ".......#..\n"
        + "..........\n"
        + ".#..^.....\n"
        + "........#.\n"
        + "#.........\n"
        + "......#...";

    internal const string Day7TestData =
        "190: 10 19\n"
        + "3267: 81 40 27\n"
        + "83: 17 5\n"
        + "156: 15 6\n"
        + "7290: 6 8 6 15\n"
        + "161011: 16 10 13\n"
        + "192: 17 8 14\n"
        + "21037: 9 7 18 13\n"
        + "292: 11 6 16 20\n";

    // csharpier-ignore
    internal const string Day8TestData =
          "............\n"
        + "........0...\n"
        + ".....0......\n"
        + ".......0....\n"
        + "....0.......\n"
        + "......A.....\n"
        + "............\n"
        + "............\n"
        + "........A...\n"
        + ".........A..\n"
        + "............\n"
        + "............\n";

    internal const string Day9ParserInput = "2333133121414131402";

    internal static uint[] GetDay9ParsedData() => [.. Day9ParsedData];

    private static readonly ImmutableArray<uint> Day9ParsedData =
    [
        0,
        0,
        uint.MaxValue,
        uint.MaxValue,
        uint.MaxValue,
        1,
        1,
        1,
        uint.MaxValue,
        uint.MaxValue,
        uint.MaxValue,
        2,
        uint.MaxValue,
        uint.MaxValue,
        uint.MaxValue,
        3,
        3,
        3,
        uint.MaxValue,
        4,
        4,
        uint.MaxValue,
        5,
        5,
        5,
        5,
        uint.MaxValue,
        6,
        6,
        6,
        6,
        uint.MaxValue,
        7,
        7,
        7,
        uint.MaxValue,
        8,
        8,
        8,
        8,
        9,
        9
    ];

    // csharpier-ignore
    internal const string Day10TestData =
          "89010123\n"
        + "78121874\n"
        + "87430965\n"
        + "96549874\n"
        + "45678903\n"
        + "32019012\n"
        + "01329801\n"
        + "10456732";

    // csharpier-ignore
    internal const string Day10TestData2 =
          "...0...\n"
        + "...1...\n"
        + "...2...\n"
        + "6543456\n"
        + "7.....7\n"
        + "8.....8\n"
        + "9.....9\n";

    // csharpier-ignore
    internal const string Day10TestData3 =
          "..90..9\n"
        + "...1.98\n"
        + "...2..7\n"
        + "6543456\n"
        + "765.987\n"
        + "876....\n"
        + "987....";

    internal const string Day11TestData = "0 1 10 99 999\n";
    internal const string Day11TestData2 = "125 17\n";

    // csharpier-ignore
    internal const string Day12TestData =
          "RRRRIICCFF\n"
        + "RRRRIICCCF\n"
        + "VVRRRCCFFF\n"
        + "VVRCCCJFFF\n"
        + "VVVVCJJCFE\n"
        + "VVIVCCJJEE\n"
        + "VVIIICJJEE\n"
        + "MIIIIIJJEE\n"
        + "MIIISIJEEE\n"
        + "MMMISSJEEE";

    /*
    Button A: X+94, Y+34
    Button B: X+22, Y+67
    Prize: X=8400, Y=5400

    Button A: X+26, Y+66
    Button B: X+67, Y+21
    Prize: X=12748, Y=12176

    Button A: X+17, Y+86
    Button B: X+84, Y+37
    Prize: X=7870, Y=6450

    Button A: X+69, Y+23
    Button B: X+27, Y+71
    Prize: X=18641, Y=10279
    */
    internal const string Day13TestData =
        "Button A: X+94, Y+34\n"
        + "Button B: X+22, Y+67\n"
        + "Prize: X=8400, Y=5400\n"
        + "\n"
        + "Button A: X+26, Y+66\n"
        + "Button B: X+67, Y+21\n"
        + "Prize: X=12748, Y=12176\n"
        + "\n"
        + "Button A: X+17, Y+86\n"
        + "Button B: X+84, Y+37\n"
        + "Prize: X=7870, Y=6450\n"
        + "\n"
        + "Button A: X+69, Y+23\n"
        + "Button B: X+27, Y+71\n"
        + "Prize: X=18641, Y=10279";

    internal const string Day14TestData =
        "p=0,4 v=3,-3\n"
        + "p=6,3 v=-1,-3\n"
        + "p=10,3 v=-1,2\n"
        + "p=2,0 v=2,-1\n"
        + "p=0,0 v=1,3\n"
        + "p=3,0 v=-2,-2\n"
        + "p=7,6 v=-1,-3\n"
        + "p=3,0 v=-1,-2\n"
        + "p=9,3 v=2,3\n"
        + "p=7,3 v=-1,2\n"
        + "p=2,4 v=2,-3\n"
        + "p=9,5 v=-3,-3\n";

    public const string Day15TestData =
        "##########\n"
        + "#..O..O.O#\n"
        + "#......O.#\n"
        + "#.OO..O.O#\n"
        + "#..O@..O.#\n"
        + "#O#..O...#\n"
        + "#O..O..O.#\n"
        + "#.OO.O.OO#\n"
        + "#....O...#\n"
        + "##########\n"
        + "\n"
        + "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>\n"
        + "^vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v\n"
        + "<v><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^\n"
        + "vv<<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^\n"
        + "^^^^^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><\n"
        + "<>^><^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<\n"
        + "v^v<v^>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>\n"
        + ">^<>vv^<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^\n"
        + "^<>^>v<>^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv\n"
        + "<>^<><<v>v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^\n"
        + "<vv<>v^<<^\n";

    // csharpier-ignore
    public const string Day15Part2SmallTestData =
          "#######\n"
        + "#...#.#\n"
        + "#.....#\n"
        + "#..OO@#\n"
        + "#..O..#\n"
        + "#.....#\n"
        + "#######\n"
        + "\n"
        + "<vv<<^^<<^^\n";

    // csharpier-ignore
    public const string Day16TestData =
          "###############\n"
        + "#.......#....E#\n"
        + "#.#.###.#.###.#\n"
        + "#.....#.#...#.#\n"
        + "#.###.#####.#.#\n"
        + "#.#.#.......#.#\n"
        + "#.#.#####.###.#\n"
        + "#...........#.#\n"
        + "###.#.#####.#.#\n"
        + "#...#.....#.#.#\n"
        + "#.#.#.###.#.#.#\n"
        + "#.....#...#.#.#\n"
        + "#.###.#.#.#.#.#\n"
        + "#S..#.....#...#\n"
        + "###############\n";

    // csharpier-ignore
    public const string Day16TestData2 =
          "#################\n"
        + "#...#...#...#..E#\n"
        + "#.#.#.#.#.#.#.#.#\n"
        + "#.#.#.#...#...#.#\n"
        + "#.#.#.#.###.#.#.#\n"
        + "#...#.#.#.....#.#\n"
        + "#.#.#.#.#.#####.#\n"
        + "#.#...#.#.#.....#\n"
        + "#.#.#####.#.###.#\n"
        + "#.#.#.......#...#\n"
        + "#.#.###.#####.###\n"
        + "#.#.#...#.....#.#\n"
        + "#.#.#.#####.###.#\n"
        + "#.#.#.........#.#\n"
        + "#.#.#.#########.#\n"
        + "#S#.............#\n"
        + "#################\n";

    public const string Day17TestData =
        "Register A: 729\n"
        + "Register B: 0\n"
        + "Register C: 0\n"
        + "\n"
        + "Program: 0,1,5,4,3,0\n";

    public const string Day18TestData =
        "5,4\n"
        + "4,2\n"
        + "4,5\n"
        + "3,0\n"
        + "2,1\n"
        + "6,3\n"
        + "2,4\n"
        + "1,5\n"
        + "0,6\n"
        + "3,3\n"
        + "2,6\n"
        + "5,1\n"
        + "1,2\n"
        + "5,5\n"
        + "2,5\n"
        + "6,5\n"
        + "1,4\n"
        + "0,4\n"
        + "6,4\n"
        + "1,1\n"
        + "6,1\n"
        + "1,0\n"
        + "0,5\n"
        + "1,6\n"
        + "2,0\n";

    public const string Day19TestData =
        "r, wr, b, g, bwu, rb, gb, br\n"
        + "\n"
        + "brwrr\n"
        + "bggr\n"
        + "gbbr\n"
        + "rrbgbr\n"
        + "ubwu\n"
        + "bwurrg\n"
        + "brgr\n"
        + "bbrgwb\n\n";

    // csharpier-ignore
    public const string Day20TestData =
          "###############\n"
        + "#...#...#.....#\n"
        + "#.#.#.#.#.###.#\n"
        + "#S#...#.#.#...#\n"
        + "#######.#.#.###\n"
        + "#######.#.#...#\n"
        + "#######.#.###.#\n"
        + "###..E#...#...#\n"
        + "###.#######.###\n"
        + "#...###...#...#\n"
        + "#.#####.#.###.#\n"
        + "#.#...#.#.#...#\n"
        + "#.#.#.#.#.#.###\n"
        + "#...#...#...###\n"
        + "###############\n";
}
