class Day23 {
    public static void Part1(StreamReader sr) {
        IArea[] hallway = ReadInput(sr, 2);
        PrintHallway(hallway, 2);
    }

    public static int Step() {
        return 0;
    }

    public static IArea[] ReadInput(StreamReader sr, int roomSize) {
        IArea[] hallway;

        //Trash the first line of just walls
        string line = sr.ReadLine();
        line = sr.ReadLine().Trim('#');
        
        hallway = new IArea[line.Length];
        
        //Read and create the room stacks
        
        for(int lineNum = 0; lineNum < roomSize; lineNum++) {
            line = sr.ReadLine();
            line = line.Substring(1, line.Length - 2);
            
            for(int i = 0; i < line.Length; i++) {
                char letter = line[i];
                if(letter == '#' || letter == ' ') hallway[i] = new Block('.');
                else {
                    if(hallway[i] is Room room) {
                        room.enqueue(letter);
                    } else {
                        Room newRoom = new Room(roomSize);
                        newRoom.enqueue(letter);
                        hallway[i] = newRoom;
                    }

                    if(lineNum == roomSize - 1 && hallway[i] is Room realRoom) realRoom.reverse();
                }
            }
        }

        return hallway;
    }

    public static void PrintHallway(IArea[] hallway, int roomSize) {
        Dictionary<int, Room> roomMap = new();
        int hallwayLength = hallway.Length;

        for(int i = 0; i < hallwayLength; i++) {
            if(hallway[i] is not Room) {
                Console.Write(hallway[i]);
            } else {
                roomMap.Add(i, (Room)hallway[i]);
                Console.Write('.');
            }
        }

        Console.WriteLine();

        for(int garbage = 0; garbage < roomSize; garbage++) {
            for(int i = 0; i < hallwayLength; i++) {
                if(roomMap.ContainsKey(i)) {
                    Console.Write(roomMap[i].contents.ElementAt(garbage));
                } else Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}

class Room : IArea { 
    public int size;
    public Stack<char> contents;

    public Room(int size) {
        this.size = size;
        this.contents = new Stack<char>(size);
    }

    public char readTop() {
        return contents.Peek();
    }

    public char readBottom() {
        return contents.ElementAt(0);
    }

    public void enqueue(char amphipod) {
        contents.Push(amphipod);
    }

    public char dequeue(char amphipod) {
        return contents.Pop();
    }

    public void reverse() {
        contents = new Stack<char>(contents);
    }
}

interface IArea {}

class Block : IArea {
    public bool room; 
    public Object contents;

    public Block(Object contents) {
        if(contents is Room) room = true;
        else room = false;

        this.contents = contents;
    }

    public override string ToString() {
        return contents.ToString();
    }
}