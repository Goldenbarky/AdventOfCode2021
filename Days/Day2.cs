class Day2 {

    public static void Part1(StreamReader sr){
        int posX = 0;
        int posY = 0;

        for(String line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            String[] data = line.Split(" ");

            String command = data[0];
            int pos = Int32.Parse(data[1]);

            switch(command) {
                case "forward":
                    posX += pos;
                    break;
                case "up":
                    posY -= pos;
                    break;
                case "down":
                    posY += pos;
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }

        Console.WriteLine("Final position was (x, y): {0}, {1}", posX, posY);
        Console.WriteLine("Answer is: {0}", posX * posY);
    }

    public static void Part2(StreamReader sr){
        int posX = 0;
        int posY = 0;
        int aim = 0;

        for(String line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            String[] data = line.Split(" ");

            String command = data[0];
            int pos = Int32.Parse(data[1]);

            switch(command) {
                case "forward":
                    posX += pos;
                    posY += aim * pos;
                    break;
                case "up":
                    aim -= pos;
                    break;
                case "down":
                    aim += pos;
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }

        Console.WriteLine("Final position was (x, y): {0}, {1}", posX, posY);
        Console.WriteLine("Answer is: {0}", posX * posY);
    }
}
