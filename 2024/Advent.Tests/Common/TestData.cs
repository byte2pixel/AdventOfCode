using System.Collections.Immutable;

namespace Advent.Tests.Common;

internal static class TestData
{
    internal const string Day5TestData =
        "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

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

    internal const string Day10TestData =
        "89010123\n"
        + "78121874\n"
        + "87430965\n"
        + "96549874\n"
        + "45678903\n"
        + "32019012\n"
        + "01329801\n"
        + "10456732";
    internal const string Day10TestData2 =
        "...0...\n"
        + "...1...\n"
        + "...2...\n"
        + "6543456\n"
        + "7.....7\n"
        + "8.....8\n"
        + "9.....9\n";

    /*
    ..90..9
    ...1.98
    ...2..7
    6543456
    765.987
    876....
    987....
    */
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

    /*
    Day 12 Test data
    RRRRIICCFF
    RRRRIICCCF
    VVRRRCCFFF
    VVRCCCJFFF
    VVVVCJJCFE
    VVIVCCJJEE
    VVIIICJJEE
    MIIIIIJJEE
    MIIISIJEEE
    MMMISSJEEE
    */
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
}
