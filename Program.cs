class Program {

    public static void Main(String[] args) {
        Type type = Type.GetType(String.Concat("Day",args[0]));
        var method = type.GetMethod(String.Concat("Part", args[1]));
        object[] test;
        if(args.Count() >= 3 && args[2] == "test")
            test = new object[] {true};
        else {
            test = new object[] {false};
        }
        method.Invoke(null, test);
    }

    public static int[] StringArrayToInt(string[] input) {
        int[] array = new int[input.Count()];
        for(int i = 0; i < input.Count(); i++) {
            array[i] = int.Parse(input[i]);
        }

        return array;
    }
}
