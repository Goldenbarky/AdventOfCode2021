using System.Collections;

class Day15 {
    public static void Part1(StreamReader sr) {
        Block[,] map = ReadInput(sr);

        map[0,0].value = 0;

        PriorityQueue<Block, int> paths = new PriorityQueue<Block, int>();
        paths.Enqueue(map[0,0], 0);

        PrintMap(map, false);

        Dijkstras(map, paths);

        PrintMap(map, true);

        Console.WriteLine($"The best path is valued at {map[9,9].value}");
    }

    public static void Part2(StreamReader sr) {
        
    }

    public static Block[,] ReadInput(StreamReader sr) {
        string line = sr.ReadLine();
        Block[,] map = new Block[line.Length, line.Length];

        for(int i = 0; line != null && i < line.Length; i++) {
            for(int j = 0; j < line.Length; j++) {
                map[i,j] = new Block(int.Parse(line.Substring(j,1)), i, j);
            }
            line = sr.ReadLine();
        }

        return map;
    }

    public static void Dijkstras(Block[,] map, PriorityQueue<Block, int> paths) {
        while(paths.Count > 0) {
            Block node = paths.Dequeue();
            node.visited = true;

            for(int i = -1; i <= 1; i++) {
                for(int j = -1; j <= 1; j++) {
                    if(Math.Abs(i) != Math.Abs(j)) {
                        var (x, y) = node.coords;
                        if(x + i >= 0 && x + i < map.GetLength(0) && y + j >= 0 && y + j < map.GetLength(1) && !map[x+i,y+j].visited) {
                            Block nextNode = map[x+i,y+j];
                            nextNode.value = Math.Min(nextNode.value, node.value + nextNode.weight);
                            if(x+i == map.GetLength(0) - 1 && y + j == map.GetLength(1)) break;
                            paths.Enqueue(nextNode, nextNode.value);
                            //Console.WriteLine("Mapped a point");
                        }
                    }
                }
            }
        }
    }

    public static void PrintMap(Block[,] map, bool drawWeighted) {
        for(int i = 0; i < map.GetLength(0); i++) {
            for(int j = 0; j < map.GetLength(1); j++) {
                if(drawWeighted) Console.Write($"{map[i,j].value} ");
                else Console.Write(map[i,j].weight);
            }
            Console.WriteLine();
        }
    }
}

class Block : IComparable {
    public int weight;
    public int value;
    public bool visited;
    public (int, int) coords;

    public Block(int weight, int x, int y) {
        this.weight = weight;
        this.value = int.MaxValue;
        this.visited = false;
        this.coords = (x, y);
    }

    public int CompareTo(object obj) {
        return this.value.CompareTo(((Block)obj).value);
    }
}