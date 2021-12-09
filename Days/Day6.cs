class Day6 {
    public static void Part1(StreamReader sr) {
        string[] data = sr.ReadLine().Split(",");
        Int64[] fish = new Int64[data.Count()];

        for(int i = 0; i < data.Count(); i++) {
            fish[i] = Int16.Parse(data[i]);
        }

        Tank tank = new Tank(fish, 8);

        tank.PassTime(80);

        Console.WriteLine("After 80 days there are {0} fish.", tank.GetNumOfFish());
    }

    public static void Part2(StreamReader sr) {
        string[] data = sr.ReadLine().Split(",");
        Int64[] fish = new Int64[data.Count()];

        for(int i = 0; i < data.Count(); i++) {
            fish[i] = Int64.Parse(data[i]);
        }

        Tank tank = new Tank(fish, 8);

        tank.PassTime(256);

        Console.WriteLine("After 256 days there are {0} fish.", tank.GetNumOfFish());
    }
}

class Tank {
    Int64[] tank;
    int gestationTime;

    public Tank(Int64[] starting, int gestationTime) {
        this.gestationTime = gestationTime;
        this.tank = new Int64[gestationTime+1];

        foreach(int fish in starting) {
            tank[fish]++;
        }
    }

    public void PassTime(int days) {
        for(int i = 0; i < days; i++) {
            Int64 newFish = tank[0];

            for(int j = 1; j <= gestationTime; j++) {
                tank[j-1] = tank[j];
            }

            tank[gestationTime] = newFish;
            tank[6] += newFish;
        }
    }

    public Int64 GetNumOfFish() {
        return tank.Sum();
    }
}