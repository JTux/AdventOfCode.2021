// Read input data
List<string> input = new StreamReader("Input.txt").ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();

// Establish drawn numbers
Board.NumbersDrawn = input[0].Split(',').Select(num => int.Parse(num)).ToList();

// Remove drawn numbers from the input data for better parsing
input.Remove(input[0]);

// Establish boards
List<Board> boards = new();
for (int i = 0; i < input.Count; i += 5)
{
    List<string> board = input.GetRange(i, 5);

    int[,] boardArray = new int[5, 5];
    for (int y = 0; y < board.Count; y++)
    {
        int[] lineValues = board[y].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(num => int.Parse(num)).ToArray();

        for (int x = 0; x < lineValues.Length; x++)
            boardArray[x, y] = lineValues[x];
    }

    Board newBoard = new(boardArray);
    newBoard.Play();

    boards.Add(newBoard);
}


//-- Task 1
Board? earliestWinningBoard = boards.OrderBy(b => b.BingoIn).FirstOrDefault();
if (earliestWinningBoard != null)
{
    int lastNumber = Board.NumbersDrawn[earliestWinningBoard.BingoIn];
    Console.WriteLine("Last number: " + lastNumber);
    Console.WriteLine("Sum of unchecked numbers: " + earliestWinningBoard.GetUncheckedSum());
    Console.WriteLine("Total: " + earliestWinningBoard.GetUncheckedSum() * lastNumber);
}

//-- Task 2
Board? lastWinningBoard = boards.OrderByDescending(b => b.BingoIn).FirstOrDefault();
if (lastWinningBoard != null)
{
    int lastNumber = Board.NumbersDrawn[lastWinningBoard.BingoIn];
    Console.WriteLine("Last number: " + lastNumber);
    Console.WriteLine("Sum of unchecked numbers: " + lastWinningBoard.GetUncheckedSum());
    Console.WriteLine("Total: " + lastWinningBoard.GetUncheckedSum() * lastNumber);
}



class Board
{
    public static List<int> NumbersDrawn = new();

    public Board(int[,] boardData)
    {
        Data = boardData;
        Checks = new bool[5, 5];
    }

    public int[,] Data { get; }
    public bool[,] Checks { get; }

    public bool Bingo { get; set; }
    public int BingoIn { get; set; }

    public void Play()
    {
        foreach (var number in NumbersDrawn)
        {
            bool numberIsOnBoard = CheckBoardForValue(number);
            if (numberIsOnBoard && Bingo)
            {
                BingoIn = NumbersDrawn.IndexOf(number);
                break;
            }
        }
    }

    private bool CheckBoardForValue(int numberDrawn)
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (Data[x, y] == numberDrawn)
                {
                    MarkBoard(x, y);
                    return true;
                }
            }
        }

        return false;
    }

    private void MarkBoard(int x, int y)
    {
        Checks[x, y] = true;

        // Check Column
        for (int row = 0; row < 5; row++)
        {
            if (!Checks[x, row])
                break;

            if (row == 4)
                Bingo = true;
        }

        // Check Row
        for (int column = 0; column < 5; column++)
        {
            if (!Checks[column, y])
                break;

            if (column == 4)
                Bingo = true;
        }
    }

    public int GetUncheckedSum()
    {
        int sum = 0;
        for (int x = 0; x < 5; x++)
            for (int y = 0; y < 5; y++)
                if (!Checks[x, y])
                    sum += Data[x, y];

        return sum;
    }
}