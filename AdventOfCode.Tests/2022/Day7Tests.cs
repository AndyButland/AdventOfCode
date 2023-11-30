namespace AdventOfCode.Year2022.Tests;

public class Day7Tests
{
    private static string s_input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    [Test]
    public void GetTotalDirectorySize_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day7.GetTotalDirectorySize(inputLines, 100000);
        result.Should().Be(95437);
    }

    [Test]
    public void GetSizeOfDirectoryToDelete_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day7.GetSizeOfDirectoryToDelete(inputLines, 8381165);
        result.Should().Be(24933642);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}