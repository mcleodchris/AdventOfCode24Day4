public class DayFour
{
    private readonly string[] _input;
    private readonly char[,] _grid;
    private const string _wordToFind = "XMAS";


    public DayFour(string filePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.", filePath);
        }

        _input = File.ReadAllLines(filePath);

        if (_input == null || _input.Length == 0)
        {
            throw new InvalidOperationException("The input file is empty.");
        }
        // convert _input to grid
        int rows = _input.Length;
        int cols = _input[0].Length;
        _grid = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                _grid[i, j] = _input[i][j];
            }
        }
    }

    public int PartOne()
    {
        int count = 0;
        int rows = _grid.GetLength(0);
        int cols = _grid.GetLength(1);

        (int dx, int dy)[] directions = {
            (0, 1), (0, -1),   // Horizontal
            (1, 0), (-1, 0),   // Vertical
            (1, 1), (-1, -1),  // Diagonal TL-BR and BR-TL
            (1, -1), (-1, 1)   // Diagonal TR-BL and BL-TR
        };

        foreach ((int dx, int dy) in directions)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (IsWordPresent(_grid, _wordToFind, x, y, dx, dy))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    public int PartTwo()
    {
        int rows = _grid.GetLength(0);
        int cols = _grid.GetLength(1);
        int count = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (IsXMASPattern(_grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsWordPresent(char[,] grid, string word, int startX, int startY, int dx, int dy)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = 0; i < word.Length; i++)
        {
            int newX = startX + i * dx;
            int newY = startY + i * dy;

            // Check boundaries
            if (newX < 0 || newX >= rows || newY < 0 || newY >= cols || grid[newX, newY] != word[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool IsXMASPattern(char[,] grid, int startX, int startY)
    {
        // Check if the pattern fits within the grid boundaries
        if (startX + 2 >= grid.GetLength(0) || startY + 2 >= grid.GetLength(1))
        {
            return false;
        }

        // Check the four possible patterns
        char[][] patterns =
        [
            ['M', 'S', 'M', 'S'],
            ['S', 'M', 'S', 'M'],
            ['M', 'M', 'S', 'S'],
            ['S', 'S', 'M', 'M']
        ];

        foreach (var pattern in patterns)
        {
            if (grid[startX, startY] == pattern[0] && grid[startX, startY + 2] == pattern[1] &&
            grid[startX + 1, startY + 1] == 'A' &&
            grid[startX + 2, startY] == pattern[2] && grid[startX + 2, startY + 2] == pattern[3])
            {
            return true;
            }
        }

        return false;
    }

}