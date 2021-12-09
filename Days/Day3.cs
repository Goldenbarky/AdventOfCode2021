using System.Collections;

class Day3 {
    public static void Part1(StreamReader sr) {
        int[] sumOfBits = new int[12];
        for(String line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            for(int i = 0; i < line.Length; i++) {
                if(line[i] == '1')
                    sumOfBits[i]++;
            }
        }

        double gamma = 0;
        String gammaBinary = "";
        double epsilon = 0;
        String epsilonBinary = "";

        for(int i = 0; i < sumOfBits.Length; i++) {
            double value = Math.Pow(2, i);
            if(sumOfBits[11 - i] > 500) {
                gamma += value;
                gammaBinary += "1";
                epsilonBinary += "0";
            } else {
                epsilon += value;
                epsilonBinary += "1";
                gammaBinary += "0";
            }
        }

        Console.WriteLine("Gamma: {0} \nEpsilon: {1}", gammaBinary, epsilonBinary);
        Console.WriteLine("Final power consumption: {0} * {1} = {2}", gamma, epsilon, gamma * epsilon);
    }

    public static void Part2(StreamReader sr) {
        ArrayList dataSet = new ArrayList();

        for(String line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            dataSet.Add(line);
        }

        ArrayList oxygenData = new ArrayList(dataSet);
        ArrayList carbonData = new ArrayList(dataSet);

        for(int i = 0; i < 12; i++) {
            if(oxygenData.Count > 1) {
                char bit = (SumOfBitsAtIndex(oxygenData, i)) ? '1' : '0';
                RemoveAllWithoutAtIndex(oxygenData, bit, i);
            }

            if(carbonData.Count > 1) {
                char bit = (SumOfBitsAtIndex(carbonData, i)) ? '0' : '1';
                RemoveAllWithoutAtIndex(carbonData, bit, i);
            }

        }

        String oxygenRating = oxygenData[0].ToString();
        String carbonRating = carbonData[0].ToString();

        int oxygen = BinaryToDecimal(oxygenRating);
        int carbon = BinaryToDecimal(carbonRating);

        Console.WriteLine("Oxygen rating: {0} = {1}\nCarbon rating: {2} = {3}", oxygenRating, oxygen, carbonRating, carbon);
        Console.WriteLine("Life support score: {0}", oxygen * carbon);
    }

    public static void RemoveAllWithoutAtIndex(ArrayList list, char ch, int index) {
        char bit = (ch == '1') ? '0' : '1';
        for (int i = list.Count - 1; i >= 0 ; i--) {
            if(list[i].ToString()[index] == bit)
                list.RemoveAt(i);
        }
    }

    public static Boolean SumOfBitsAtIndex(ArrayList data, int index) {
        int sum = 0;
        foreach(string num in data) {
            sum += Int16.Parse(num.Substring(index, 1));
        }

        return (double) sum >= (data.Count / 2.0);
    }

    public static int BinaryToDecimal(String binary) {
        int conversion = 0;
        for(int i = 0; i < binary.Length; i++) {
            double value = Math.Pow(2, i);
            conversion += (binary[binary.Length-i-1] == '1') ? (int)value : 0;
        }
        return conversion;
    }
}