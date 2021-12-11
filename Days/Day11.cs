class Day11 {
    public static void Part1(StreamReader sr) {
        List<List<int>> map = new List<List<int>>();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            List<int> row = new List<int>();
            foreach(char octopus in line) {
                row.Add(int.Parse(octopus.ToString()));
            }
            map.Add(row);
        }

        int totalFlashes = 0;
        for(int round = 1; round <= 100; round++) {
            int flashes = 0;
            for(int i = 0; i < map.Count(); i++) {
                for(int j = 0; j < map[i].Count(); j++) {
                    map[i][j]++;
                }
            }

            for(int i = 0; i < map.Count(); i++) {
                for(int j = 0; j < map[i].Count(); j++) {
                    if(map[i][j] > 9) {
                        flashes += FlashOctopus(i, j, map);
                    }
                }
            }

            PrintMap(map);
            Console.WriteLine("Round {0}: {1} flashes", round, flashes);
            totalFlashes += flashes;
        }

        Console.WriteLine(totalFlashes);
        
    }

    public static int FlashOctopus(int x, int y, List<List<int>> map) {
        if(map[x][y] == 0) {
            return 0;
        }

        int totalFlashes = 1;
        map[x][y] = 0;

        for(int i = -1; i < 2; i++) {
            for(int j = -1; j < 2; j++) {
                if(x + i >= 0 && x + i < map.Count() && y + j >= 0 && y + j < map[x+i].Count()) {
                    int octopus = map[x + i][y + j];

                    if(octopus != 0)
                        octopus = map[x+i][y+j]++;
                    if(octopus >= 9)
                        totalFlashes += FlashOctopus(x+i, y+j, map);
                }
            }
        }

        return totalFlashes;
    }

    public static void PrintMap(List<List<int>> map) {
        for(int i = 0; i < map.Count(); i++) {
                for(int j = 0; j < map[i].Count(); j++) {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
    }

    public static void Part2(StreamReader sr) {
        List<List<int>> map = new List<List<int>>();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            List<int> row = new List<int>();
            foreach(char octopus in line) {
                row.Add(int.Parse(octopus.ToString()));
            }
            map.Add(row);
        }

        for(int round = 1; round <= 1000; round++) {
            int flashes = 0;
            for(int i = 0; i < map.Count(); i++) {
                for(int j = 0; j < map[i].Count(); j++) {
                    map[i][j]++;
                }
            }

            for(int i = 0; i < map.Count(); i++) {
                for(int j = 0; j < map[i].Count(); j++) {
                    if(map[i][j] > 9) {
                        flashes += FlashOctopus(i, j, map);
                    }
                }
            }

            if(flashes == 100) {
                Console.WriteLine(round);
                Console.WriteLine(flashes);
                PrintMap(map);
                break;
            }
        }
    }
}