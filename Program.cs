class Program {

    static string FILE_NAME = "Input/input{0}.txt";
    static string TEST_FILE_NAME = "Input/input{0}sample.txt";

    public static void Main(String[] args) {

        string day = args[0];
        string part = args[1];

        Type type = Type.GetType(String.Concat("Day", day));
        var method = type.GetMethod(String.Concat("Part", part));
        StreamReader sr = null;
        if(args.Count() >= 3 && args[2] == "test")
            sr = new StreamReader(string.Format(TEST_FILE_NAME, day));
        else {
            sr = new StreamReader(string.Format(FILE_NAME, day));
        }

        object[] arguments = {sr};

        method.Invoke(null, arguments);
    }

    public static int[] StringArrayToInt(string[] input) {
        int[] array = new int[input.Count()];
        for(int i = 0; i < input.Count(); i++) {
            array[i] = int.Parse(input[i]);
        }

        return array;
    }
}
