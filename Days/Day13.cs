using System.Collections;

class Day13 {
    public static void Part1(StreamReader sr) {
        bool[,] map = InputToArray(sr);

        //PrintMap(map);

        string[] instructions = sr.ReadLine().Split(" ");
        string[] line = instructions[2].Split("=");

        char foldDim = char.Parse(line[0]);
        int foldIndex = int.Parse(line[1]);

        Console.WriteLine($"Folding along {foldDim} = {foldIndex}...");

        map = FoldAlongLine(foldDim, foldIndex, map);

        //PrintMap(map);

        int visibleDots = 0;
        foreach(bool value in map) {
            if(value) visibleDots++;
        }

        Console.WriteLine($"There are {visibleDots} dots visible");
    }

    public static void Part2(StreamReader sr) {
        bool[,] map = InputToArray(sr);

        string line = sr.ReadLine();
        while(line != null) {
            string[] instructions = line.Split(" ");
            string[] command = instructions[2].Split("=");

            char foldDim = char.Parse(command[0]);
            int foldIndex = int.Parse(command[1]);

            Console.WriteLine($"Folding along {foldDim} = {foldIndex}...");

            map = FoldAlongLine(foldDim, foldIndex, map);

            line = sr.ReadLine();
        }

        PrintMap(map);
    }

    public static bool[,] InputToArray(StreamReader sr) {
        string line = sr.ReadLine();

        int xMax = int.MinValue;
        int yMax = int.MinValue;

        while(line != "") {
            string[] coords = line.Split(",");

            xMax = Math.Max(xMax, int.Parse(coords[0]));
            yMax = Math.Max(yMax, int.Parse(coords[1]));

            if(xMax % 2 == 1) xMax++;
            if(yMax % 2 == 1) yMax++;

            line = sr.ReadLine();
        }

        bool[,] map = new bool[xMax+1,yMax+1];

        sr.DiscardBufferedData();
        sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        
        line = sr.ReadLine();
        while(line != "") {
            string[] coords = line.Split(",");

            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);

            map[x,y] = true;

            line = sr.ReadLine();
        }

        Console.WriteLine($"Dim: {map.GetLength(0)},{map.GetLength(1)}");

        return map;
    }

    public static bool[,] FoldAlongLine(char dim, int foldIndex, bool[,] map) {
        bool[,] newMap = null;
        if(dim == 'x') {
            newMap = new bool[map.GetLength(0)/2, map.GetLength(1)];

            for(int i = 0; i < map.GetLength(0)/2; i++) {
                for(int j = 0; j < map.GetLength(1); j++) {
                    newMap[i,j] = map[i,j] || map[map.GetLength(0)-i-1,j];
                }
            }
        } else if(dim == 'y') {
            newMap = new bool[map.GetLength(0), map.GetLength(1)/2];

            for(int i = 0; i < map.GetLength(0); i++) {
                for(int j = 0; j < map.GetLength(1)/2; j++) {
                    newMap[i,j] = map[i,j] || map[i,map.GetLength(1)-j-1];
                }
            }
        } else {
            Console.WriteLine("What");
        }

        Console.WriteLine($"New Dim: {newMap.GetLength(0)},{newMap.GetLength(1)}");

        return newMap;
    }
    
    public static void PrintMap(bool[,] map) {
        for(int i = 0; i < map.GetLength(1); i++) {
            for(int j = 0; j < map.GetLength(0); j++) {
                if(map[j,i]) Console.Write("# ");
                else Console.Write(". ");
            }
            Console.WriteLine();
        }
    }
}