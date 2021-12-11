class Day9 {
    public static void Part1(StreamReader sr) {
        List<List<int>> map = new List<List<int>>();
        List<int> lowPoints = new List<int>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            List<int> row = new List<int>();
            map.Add(row);

            foreach(char depth in line) {
                row.Add(int.Parse(depth.ToString()));
            }
        }

        for(int i = 0; i < map.Count(); i++) {
            for(int j = 0; j < map[i].Count(); j++) {
                bool low = true;

                for(int k = -1; k < 2; k++) {
                    if(k == 0) for(int l = -1; l < 2; l +=2) {
                        if(j + l < map[i].Count() && j + l >= 0 && map[i][j] >= map[i][j+l])
                            low = false;
                    } else {
                        if(i + k < map.Count() && i + k >= 0 && map[i][j] >= map[i+k][j])
                            low = false;
                    }
                }

                if(low) {
                    lowPoints.Add(map[i][j]);
                }
            }
        }

        lowPoints.ForEach(x=>Console.WriteLine(x));

        int score = 0;
        foreach(int value in lowPoints) {
            score += value + 1;
        }

        Console.WriteLine(score);
    }
    public static void Part2(StreamReader sr) {
        List<List<int>> map = new List<List<int>>();
        List<int> lowPoints = new List<int>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            List<int> row = new List<int>();
            map.Add(row);

            foreach(char depth in line) {
                row.Add(int.Parse(depth.ToString()));
            }
        }

        List<int> basins = new List<int>();

        for(int i = 0; i < map.Count(); i++) {
            for(int j = 0; j < map[i].Count(); j++) {
                int basin = LocateBasin(map, i, j);

                if(basin > 0)
                    basins.Add(basin);
            }
        }

        int score = 1;
        
        basins.Sort();
        basins.Reverse();

        for(int i = 0; i < 3; i++) {
            score *= basins[i];
        }

        Console.WriteLine(score);
    }

    public static int LocateBasin(List<List<int>> map, int x, int y) {
        int neighborsFound = 0;

        for(int k = -1; k < 2; k++) {
            if(k == 0) for(int l = -1; l < 2; l +=2) {
                if(y + l < map[x].Count() && y + l >= 0 && map[x][y+l] != -1 && map[x][y+l] != 9) {
                    neighborsFound++;
                    map[x][y+l] = -1;

                    neighborsFound += LocateBasin(map, x, y+l);
                }
            } else {
                if(x + k < map.Count() && x + k >= 0 && map[x+k][y] != -1 && map[x+k][y] != 9) {
                    neighborsFound++;
                    map[x+k][y] = -1;

                    neighborsFound += LocateBasin(map, x+k, y);
                }
            }
        }

        return neighborsFound;
    }
}