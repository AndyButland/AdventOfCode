using System.Linq;

namespace AdventOfCode.Year2022;

public static class Day17
{
    private const int ChamberWidth = 7;

    public static int GetRockHeight(string input)
    {
        var jet = input
            .Select(x => x == '>' ? 1 : -1)
            .ToList();

        // Create chamber with floor.
        var chamber = new List<char[]>
        {
            GetFloor()
        };

        var rockCount = 0;
        var rockIndex = 0;
        var jetIndex = 0;

        while (rockCount <= 2022)
        {
            var rock = GetRock(rockIndex);
            ExtendChamberWithFallingRock(chamber, rock);

            var rockTopIndexInChamber = chamber.Count - 1;

            while (true)
            {
                RockIsPushed(chamber, rock, jet, ref jetIndex);

                if (!RockFalls(chamber, rock, ref rockTopIndexInChamber))
                {
                    break;
                }
            }

            FixRock(chamber, rock);

            rockIndex++;
            if (rockIndex == 5)
            {
                rockIndex = 0;
            }

            rockCount++;
        }

        return chamber.Count;
    }

    private static char[,] GetRock(int rockIndex)
    {
        switch (rockIndex)
        {
            case 0:
                return new char[7, 1] { { '.' }, { '.' }, { '@' }, { '@' }, { '@' }, { '@' }, { '.' } };
            case 1:
                return new char[7, 3] {
                    { '.', '.', '.' },
                    { '.', '.', '.' },
                    { '.', '@', '.' },
                    { '@', '@', '@' },
                    { '.', '@', '.' },
                    { '.', '.', '.' },
                    { '.', '.', '.' }
                };
            case 2:
                return new char[7, 3] {
                    { '.', '.', '.' },
                    { '.', '.', '.' },
                    { '@', '.', '.' },
                    { '@', '.', '.' },
                    { '@', '@', '@' },
                    { '.', '.', '.' },
                    { '.', '.', '.' }
                };
            case 3:
                return new char[7, 4] {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '@', '@', '@', '@' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                };
            case 4:
                return new char[7, 2] {
                    { '.', '.', },
                    { '.', '.', },
                    { '@', '@', },
                    { '@', '@', },
                    { '.', '.', },
                    { '.', '.', },
                    { '.', '.', },
                };
            default:
                throw new ArgumentOutOfRangeException(nameof(rockIndex));
        }
    }

    private static void ExtendChamberWithFallingRock(List<char[]> chamber, char[,] rock)
    {
        // When rock appears, its bottom edge is three units above the highest rock in the
        // room (or the floor, if there isn't one).
        for (int i = 0; i < 3; i++)
        {
            chamber.Add(GetEmptyRow());
        }

        for (int y = 0; y < rock.GetLength(1); y++)
        {
            var chars = new List<char>();
            for (int x = 0; x < ChamberWidth; x++)
            {
                chars.Add(rock[x, y]);
            }

            chamber.Add(chars.ToArray());
        }
    }

    private static char[] GetFloor() => GetRow('-');

    private static char[] GetEmptyRow() => GetRow('.');

    private static char[] GetRow(char c) => Enumerable.Range(0, ChamberWidth).Select(x => c).ToArray();

    private static void FixRock(List<char[]> chamber, char[,] rock)
    {
        for (int y = 0; y < rock.GetLength(1); y++)
        {
            for (int x = 0; x < ChamberWidth; x++)
            {
                if (chamber[chamber.Count - 1 - y][x] == '@')
                {
                    chamber[chamber.Count - 1 - y][x] = '#';
                }
            }
        }
    }

    private static void RockIsPushed(List<char[]> chamber, char[,] rock, List<int> jet, ref int jetIndex)
    {
        var direction = jet[jetIndex];

        if (!IsAgainstWall(chamber, rock, direction) && !IsAgainstRock(chamber, rock, direction))
        {
            for (int y = 0; y < rock.GetLength(1); y++)
            {
                var fallingRockStart = Array.IndexOf(chamber[chamber.Count - 1 - y], '@');
                var fallingRockFinish = Array.LastIndexOf(chamber[chamber.Count - 1 - y], '@');

                for (int x = fallingRockStart; x <= fallingRockFinish; x++)
                {
                    chamber[chamber.Count - 1 - y][x + direction] = '@';
                }

                if (direction == 1)
                {
                    chamber[chamber.Count - 1 - y][fallingRockStart] = '.';
                }
                else
                {
                    chamber[chamber.Count - 1 - y][fallingRockFinish] = '.';
                }

            }
        }

        jetIndex++;
        if (jetIndex == jet.Count)
        {
            jetIndex = 0;
        }
    }

    private static bool IsAgainstWall(List<char[]> chamber, char[,] rock, int direction)
    {
        for (int y = 0; y < rock.GetLength(1); y++)
        {
            if (chamber[chamber.Count - 1 - y][direction == -1 ? 0 : ChamberWidth - 1] == '@')
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsAgainstRock(List<char[]> chamber, char[,] rock, int direction)
    {
        for (int y = 0; y < rock.GetLength(1); y++)
        {
            if (direction == 1)
            {
                for (int x = 0; x < ChamberWidth - 1; x++)
                {
                    if (chamber[chamber.Count - 1 - y][x] == '@' && chamber[chamber.Count - 1 - y][x + 1] == '#')
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int x = ChamberWidth - 1; x > 0; x--)
                {
                    if (chamber[chamber.Count - 1 - y][x] == '@' && chamber[chamber.Count - 1 - y][x - 1] == '#')
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private static bool RockFalls(List<char[]> chamber, char[,] rock, ref int rockTopIndexInChamber)
    {
        if (!RockCanFall(chamber, rock, rockTopIndexInChamber))
        {
            return false;
        }

        for (int y = rock.GetLength(1); y > 0 ; y--)
        {
            for (int x = 0; x < ChamberWidth; x++)
            {
                if (chamber[rockTopIndexInChamber + 1 - y][x] == '@')
                {
                    chamber[rockTopIndexInChamber + 1 - y][x] = '.';
                    chamber[rockTopIndexInChamber + 1 - (y + 1)][x] = '@';
                }
            }
        }

        if (chamber[rockTopIndexInChamber].All(x => x == '.'))
        {
            chamber.RemoveAt(rockTopIndexInChamber);
            rockTopIndexInChamber--;
        }

        return true;
    }

    private static bool RockCanFall(List<char[]> chamber, char[,] rock, int rockTopIndexInChamber)
    {
        var rockBaseIndex = rockTopIndexInChamber + 1 - rock.GetLength(1);
        var rockBaseRow = chamber[rockBaseIndex];
        var rowBelow = chamber[rockBaseIndex - 1];
        for (int x = 0; x < ChamberWidth - 1; x++)
        {
            if (rockBaseRow[x] == '@' && (rowBelow[x] == '#' || rowBelow[x] == '-'))
            {
                return false;
            }
        }

        return true;
    }
}


