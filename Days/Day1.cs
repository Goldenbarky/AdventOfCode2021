
class Day1 {

    static String InputFile = "Input/input1.txt";

    public static void Part1() {
        StreamReader sr = new StreamReader(InputFile);

        int numIncreases = 0;
        int prev = Int32.Parse(sr.ReadLine());
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            int curr = Int32.Parse(line);

            if(prev < curr) {
                numIncreases++;
            }

            prev = curr;
        }

        Console.WriteLine(numIncreases);
    }

    public static void Part2() {
        StreamReader sr = new StreamReader(InputFile);

        int numIncreases = 0;

        Queue<int> values = new Queue<int>();

        values.Enqueue(Int32.Parse(sr.ReadLine()));
        values.Enqueue(Int32.Parse(sr.ReadLine()));
        values.Enqueue(Int32.Parse(sr.ReadLine()));

        int prevSum = values.Sum();
        //Console.WriteLine(prevSum);

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            values.Enqueue(Int32.Parse(line));
            values.Dequeue();

            int sum = values.Sum();
            //Console.WriteLine(sum);

            if(prevSum < sum)
                numIncreases++;

            prevSum = sum;
        }

        Console.WriteLine("Total increases was " + numIncreases);
    }
}
