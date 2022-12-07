namespace AdventOfCode2022
{
    public static class Day7
    {
        public static int GetTotalDirectorySize(string[] inputLines, int maxSize)
        {
            var directory = CreateDirectory(inputLines);
            return GetSizeOfDirectory(directory, maxSize);
        }

        public static int GetSizeOfDirectoryToDelete(string[] inputLines, int minSize)
        {
            var directory = CreateDirectory(inputLines);
            return GetSizeOfDirectoryToDelete(directory, minSize);
        }

        private static Directory CreateDirectory(string[] inputLines)
        {
            var directory = new Directory("/");

            var currentDirectory = directory;
            foreach (var line in inputLines)
            {
                if (IsCommand(line))
                {
                    var command = Command.Create(line);
                    ProcessCommand(directory, command, ref currentDirectory);
                }
                else
                {
                    // List of files or directories.
                    if (line.StartsWith("dir"))
                    {
                        var name = line.Substring(4);
                        currentDirectory.Directories.Add(new Directory(name, currentDirectory));
                    }
                    else
                    {
                        var lineParts = line.Split(' ');
                        currentDirectory.Files.Add(new File(lineParts[1], int.Parse(lineParts[0])));
                    }
                }
            }

            return directory;
        }

        private static bool IsCommand(string line) => line.StartsWith("$");

        private static void ProcessCommand(Directory directory, Command command, ref Directory currentDirectory)
        {
            switch (command.Operation)
            {
                case "cd":
                    switch (command.Argument)
                    {
                        case "/":
                            currentDirectory = directory;
                            break;
                        case "..":
                            if (currentDirectory.Parent == null)
                            {
                                currentDirectory = directory;
                            }
                            else
                            {
                                currentDirectory = currentDirectory.Parent;
                            }

                            break;
                        default:
                            var childDirectory = currentDirectory.Directories.SingleOrDefault(x => x.Name == command.Argument);
                            if (childDirectory != null)
                            {
                                currentDirectory = childDirectory;
                            }
                            else
                            {
                                throw new ArgumentException($"Cannot move to directory {command.Argument} in {currentDirectory.Name}.");
                            }

                            break;
                    }

                    break;
                case "ls":
                    // No action needed.
                    break;
                default:
                    throw new ArgumentException($"Command {command.Operation} is not recogised.");
            }
        }

        private static int GetSizeOfDirectory(Directory directory, int maxSize)
        {
            var result = 0;
            foreach (var subDirectory in directory.Directories)
            {
                var size = subDirectory.GetFileSize();
                if (size < maxSize)
                {
                    result += size;
                }

                result += GetSizeOfDirectory(subDirectory, maxSize);
            }

            return result;
        }

        private static int GetSizeOfDirectoryToDelete(Directory directory, int minSize, int currentSize = 0)
        {
            foreach (var subDirectory in directory.Directories)
            {
                var size = subDirectory.GetFileSize();
                if (size >= minSize && (currentSize == 0 || size < currentSize))
                {
                    currentSize = size;
                }

                currentSize = GetSizeOfDirectoryToDelete(subDirectory, minSize, currentSize);
            }

            return currentSize;
        }

        private class Command
        {
            private Command(string operation, string argument)
            {
                Operation = operation;
                Argument = argument;
            }

            public string Operation { get; }

            public string Argument { get; }

            public static Command Create(string line)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                {
                    return new Command(parts[1], parts[2]);
                }

                return new Command(parts[1], string.Empty);
            }
        }

        private class Directory
        {
            public Directory(string name) => Name = name;

            public Directory(string name, Directory? parent)
                : this(name) => Parent = parent;

            public string Name { get; }

            public IList<Directory> Directories { get; } = new List<Directory>();  

            public IList<File> Files { get; } = new List<File>();

            public Directory? Parent { get; }

            public int GetFileSize() => Files.Sum(x => x.Size) + Directories.Select(x => x.GetFileSize()).Sum();
        }

        private class File
        {
            public File(string name, int size)
            {
                Name = name;
                Size = size;
            }

            public string Name { get; }

            public int Size { get; }
        }
    }
}
