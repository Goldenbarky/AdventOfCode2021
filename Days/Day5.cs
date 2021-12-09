class Day5 {
    public static void Part1(StreamReader sr) {
        Map map = new Map();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string[] data = line.Split(" -> ");
            string[] start = data[0].Split(",");
            string[] end = data[1].Split(",");

            map.MapVent(int.Parse(start[0]), int.Parse(start[1]), int.Parse(end[0]), int.Parse(end[1]), false);
        }

        //map.PrintMap();
    
        Console.WriteLine("The maps score is: {0}", map.GetScore());
    }

    public static void Part2(StreamReader sr) {
        Map map = new Map();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string[] data = line.Split(" -> ");
            string[] start = data[0].Split(",");
            string[] end = data[1].Split(",");

            map.MapVent(int.Parse(start[0]), int.Parse(start[1]), int.Parse(end[0]), int.Parse(end[1]), true);
        }

        //map.PrintMap();
    
        Console.WriteLine("The maps score is: {0}", map.GetScore());
    }
}

class Map {
    private int[,] map;
    private int score;

    public Map() {
        this.map = new int[1000, 1000];
        this.score = 0;
    }

    public void MapVent(int x0, int y0, int x1, int y1, bool diagonalsAllowed) {
        bool diagonal = x0 != x1 && y0 != y1;

        if(!diagonal) {
            bool x = (y0 - y1) == 0;
            int start = (x) ? Math.Min(x0, x1) : Math.Min(y0, y1);
            int end = (x) ? Math.Max(x0, x1) : Math.Max(y0, y1);

            for(int i = start; i <= end; i++) {
                if(x) {
                    if(map[i, y0]++ == 1) {
                        score++;
                    }
                } else {
                    if(map[x0, i]++ == 1) {
                        score++;
                    }
                }
            }
        } else if(diagonalsAllowed && diagonal) {
            bool forwardsDiagonal = (x0 - x1) * (y0 - y1) > 0;

            int xStart = Math.Min(x0, x1);
            int yStart = forwardsDiagonal ? Math.Min(y0, y1) : Math.Max(y0, y1);

            for(int i = 0; i <= Math.Abs(x0 - x1); i++) {
                if(forwardsDiagonal) {
                    if(map[xStart + i, yStart + i]++ == 1)
                        score++;
                } else {
                    if(map[xStart + i, yStart - i]++ == 1)
                        score++;
                }
            }
        }
    }

    public void PrintMap() {
        for(int i = 0; i < map.GetLength(0); i++) {
            for(int j = 0; j < map.GetLength(1); j++) {
                Console.Write("{0}", map[j,i]);
            }
            Console.Write("\n");
        }
    }

    public int GetScore() {
        return this.score;
    }
}