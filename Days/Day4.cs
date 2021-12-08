using System.Collections;

class Day4 {
    static string FILE_NAME = "Input/input4.txt";
    static string TEST_FILE_NAME = "Input/input4sample.txt";
    public static void Part1(bool test = false) {
        StreamReader sr = (test) ? new StreamReader(TEST_FILE_NAME) : new StreamReader(FILE_NAME);

        string[] numbers = sr.ReadLine().Split(",");

        sr.ReadLine();

        List<Board> boards = ReadBoardsFromInput(sr);

        int winningScore = 0;
        foreach(string num in numbers) {
            foreach(Board board in boards) {
                if(board.CallNumber(Int16.Parse(num))) {
                    winningScore = Int16.Parse(num) * board.GetScore();
                    Console.WriteLine("Winning number is: {0}\nWinning board score is: {1}", Int16.Parse(num), board.GetScore());
                    Console.WriteLine("Winning score is: {0}", winningScore);
                    return;
                }
            }
        }

        Console.WriteLine("Oh boy, something went wrong");
    }

    public static void Part2(bool test = false) {
        StreamReader sr = (test) ? new StreamReader(TEST_FILE_NAME) : new StreamReader(FILE_NAME);

        string[] numbers = sr.ReadLine().Split(",");

        sr.ReadLine();

        List<Board> boards = ReadBoardsFromInput(sr);

        foreach(string num in numbers) {
            List<Board> finishedBoards = new List<Board>();
            foreach(Board board in boards) {
                if(board.CallNumber(Int16.Parse(num))) {
                    if(boards.Count == 1) {
                        int losingScore = Int16.Parse(num) * board.GetScore();
                        Console.WriteLine("Last number is: {0}\nLosing board score is: {1}", Int16.Parse(num), board.GetScore());
                        Console.WriteLine("Losing score is: {0}", losingScore);
                        return;
                    }
                    finishedBoards.Add(board);
                }
            }
            finishedBoards.ForEach(x=>boards.Remove(x));
            finishedBoards.Clear();
        }

        Console.WriteLine("Oh boy, something went wrong");
    }

    public static List<Board> ReadBoardsFromInput(StreamReader sr) {
        string line = sr.ReadLine();
        List<int> board = new List<int>();
        List<Board> boards = new List<Board>();
        while(line != null) {
            if(line == "") {
                boards.Add(new Board(board));
                board.Clear();
            }
            
            string[] row = line.Split(" ");
            foreach(string num in row) {
                if(num != "") {
                    board.Add(Int16.Parse(num));
                }
            }

            line = sr.ReadLine();
        }

        return boards;
    }

}

class Board {
    private List<List<int>> solutions = new List<List<int>>();
    private int score = 0;
    public Board(List<int> board) {
        List<int>[] columns = new List<int>[5];
        List<int>[] rows = new List<int>[5];
        List<int> fDiagonal = new List<int>();
        List<int> bDiagonal = new List<int>();
        for(int i = 0; i < 25; i++) {
            //Add each row to solutions
            if(rows[i / 5] == null)
                rows[i / 5] = new List<int>();
            rows[i / 5].Add(board[i]);

            //Add each column to solutions
            if(columns[i % 5] == null)
                columns[i % 5] = new List<int>();
            columns[i % 5].Add(board[i]);

            //Add forward diagonal numbers
            if(i % 5 == i / 5) {
                fDiagonal.Add(board[i]);
            }

            //Add backward diagonal numbers
            if((i % 5 + i / 5) == 4) {
                bDiagonal.Add(board[i]);
            }

            //Add each value to the score
            score += board[i];
        }
        columns.ToList().ForEach(solutions.Add);
        rows.ToList().ForEach(solutions.Add);
        //solutions.Add(fDiagonal);
        //solutions.Add(bDiagonal);
    }

    public List<List<int>> GetSolutions() {
        return this.solutions;
    }

    public int GetScore() {
        return this.score;
    }

    //Removes the given number from the solution set for the board and subtracts the score by that number.
    //Returns true if the board is in a winning state now, false otherwise.
    public Boolean CallNumber(int num) {
        bool numRemoved = false;
        foreach(List<int> solution in solutions) {
            if(solution.Remove(num) && !numRemoved) {
                score -= num;
                numRemoved = true;
            }
            if(solution.Count == 0)
                return true;
        }

        return false;
    }

    public void PrintSolutions() {
        solutions.ForEach(x=> { 
            x.ForEach(y=>Console.Write($"{y},"));
            Console.WriteLine();
        });
    }
}