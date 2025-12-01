# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Test Commands

```bash
# Build all projects
dotnet build

# Run all tests
dotnet test

# Run tests for a specific year/day
dotnet test --filter "Year2025.Day1Tests"

# Run the interactive console runner
dotnet run --project AdventOfCode.Runner
```

## Architecture

This is a .NET 10.0 Advent of Code solution repository with three projects:

- **AdventOfCode/** - Core library containing puzzle solutions organized by year (2022/, 2023/, 2025/)
- **AdventOfCode.Tests/** - NUnit tests using FluentAssertions, mirroring the year structure
- **AdventOfCode.Runner/** - Interactive console app that loads embedded input data and runs solutions

## Solution Pattern

Each day's solution is a static class in a year namespace:

```csharp
namespace AdventOfCode.Year2025;
public static class Day1
{
    public static int SolvePart1(string[] inputLines) { ... }
    public static int SolvePart2(string[] inputLines) { ... }
}
```

## Test Pattern

Tests use NUnit with FluentAssertions. Example test data is stored as static strings in test classes:

```csharp
namespace AdventOfCode.Year2025.Tests;
public class Day1Tests
{
    private static string s_input = @"...";

    [Test]
    public void SolvePart1_ReturnsExpectedResult()
    {
        string[] inputLines = s_input.Split(Environment.NewLine);
        Day1.SolvePart1(inputLines).Should().Be(expectedValue);
    }
}
```

## Input Data

Actual puzzle input files are stored as embedded resources in `AdventOfCode.Runner/InputData/Year####/DayN.txt` and loaded at runtime by the runner application.
