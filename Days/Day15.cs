class Day15 {
    public static void Part1(StreamReader sr) {
        int[,] map = ReadInput(sr);

        PrintMap(map);

        int score = FindBestPath(0, 0, map, 0, int.MaxValue, true);

        Console.WriteLine($"The best path is valued at {score}");
    }

    public static void Part2(StreamReader sr) {
        
    }

    public static int[,] ReadInput(StreamReader sr) {
        string line = sr.ReadLine();
        int[,] map = new int[line.Length, line.Length];

        for(int i = 0; line != null && i < line.Length; i++) {
            for(int j = 0; j < line.Length; j++) {
                map[i,j] = int.Parse(line.Substring(j, 1));
            }
            line = sr.ReadLine();
        }

        return map;
    }

    public static int FindBestPath(int x, int y, int[,] map, int score, int bestScore, bool alternate) {
        if(x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1)) {
            score += map[x,y];

            if((x+1) * (y+1) == map.Length) {
                return score;
            } else if(score >= bestScore) {
                return int.MaxValue;
            } else {
                bestScore = (alternate) 
                    ? Math.Min(FindBestPath(x, y+1, map, score, bestScore, !alternate), bestScore)
                    : Math.Min(FindBestPath(x+1, y, map, score, bestScore, !alternate), bestScore);
                bestScore = (!alternate)
                    ? Math.Min(FindBestPath(x, y+1, map, score, bestScore, !alternate), bestScore)
                    : Math.Min(FindBestPath(x+1, y, map, score, bestScore, !alternate), bestScore);
                
                //Left case just in case
                bestScore = Math.Min(FindBestPath(x-1, y, map, score, bestScore, !alternate), bestScore);
                //Up case just to check
                bestScore = Math.Min(FindBestPath(x, y-1, map, score, bestScore, !alternate), bestScore);

                return bestScore;
            }
        } else {
            return int.MaxValue;
        }
    }

    public static void PrintMap(int[,] map) {
        for(int i = 0; i < map.GetLength(0); i++) {
            for(int j = 0; j < map.GetLength(1); j++) {
                Console.Write(map[i,j]);
            }
            Console.WriteLine();
        }
    }
}