class Day7 {
    public static void Part1(StreamReader sr) {
        int[] crabs = Program.StringArrayToInt(sr.ReadLine().Split(","));

        double bestDepth = FindBestDepth(crabs, 2000, 1000, false);

        Console.WriteLine("Best depth is {0} with a score of {1}", bestDepth, GetDepthScore(crabs, (int) bestDepth, false));
    }

    public static void Part2(StreamReader sr) {
    int[] crabs = Program.StringArrayToInt(sr.ReadLine().Split(","));

        double bestDepth = FindBestDepth(crabs, 2000, 1000, true);

        Console.WriteLine("Best depth is {0} with a score of {1}", bestDepth, GetDepthScore(crabs, (int) bestDepth, true));
    }

    public static double FindBestDepth(int[] crabs, int window, int currDepth, bool exponentialCost) {
        double minScore = GetDepthScore(crabs, currDepth, exponentialCost);

        if(window == 1)
            return currDepth;
        else if(GetDepthScore(crabs, currDepth+1, exponentialCost) < minScore) {
            return FindBestDepth(crabs, window / 2, currDepth + (int)(Math.Ceiling(window / 4.0)), exponentialCost);
        } else if(GetDepthScore(crabs, currDepth-1, exponentialCost) < minScore) {
            return FindBestDepth(crabs, window / 2, currDepth - (int)(Math.Ceiling(window / 4.0)), exponentialCost);
        } else {
            return currDepth;
        }
    }

    public static double GetDepthScore(int[] crabs, int depth, bool exponential) {
        double sum = 0;
        foreach(int crabPos in crabs) {
            sum += (exponential) ? (Math.Abs(crabPos - depth)) * (Math.Abs(crabPos - depth) + 1) / 2.0 : (double) Math.Abs(crabPos - depth);
        }
        return sum;
    }
}