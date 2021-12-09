using System.Collections;
class Day8 {
    public static void Part1(StreamReader sr) {
        int[] numDigits = new int[4];

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string[] data = line.Split("|");

            string[] panel1 = data[0].Split(" ");
            string[] panel2 = data[1].Split(" ");

            foreach(string num in panel2) {
                switch(num.Count()) {
                    case 2:
                        numDigits[0]++;
                        break;
                    case 4:
                        numDigits[1]++;
                        break;
                    case 3:
                        numDigits[2]++;
                        break;
                    case 7:
                        numDigits[3]++;
                        break;
                }
            }
        }
        
        Console.WriteLine("2: {0}\n4: {1}\n7: {2}\n8: {3}\nsum: {4}", numDigits[0], numDigits[1], numDigits[2], numDigits[3], numDigits.Sum());
    }

    public static void Part2(StreamReader sr) {
        int sum = 0;

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            char[] answerKey = new char[7];
            List<string>[] wires = new List<string>[8];

            string[] data = line.Split(" | ");

            string[] panel1 = data[0].Split(" ");
            string[] panel2 = data[1].Split(" ");

            foreach(string num in panel2) {
                if(wires[num.Count()] == null)
                    wires[num.Count()] = new List<string>();
                wires[num.Count()].Add(num);
            }

            foreach(string num in panel1) {
                if(wires[num.Count()] == null)
                    wires[num.Count()] = new List<string>();
                wires[num.Count()].Add(num);
            }

            //Locate "a" wire
            foreach(char wire in wires[3][0]) {
                if(!wires[2][0].Contains(wire.ToString())) {
                    answerKey[0] = wire;
                    break;
                }
            }

            //Locate "g" wire
            foreach(string entry in wires[6]) {
                List<char> display = entry.ToList();
                display.Remove(answerKey[0]);
                foreach(char wire in wires[4][0]) {
                    display.Remove(wire);
                }

                if(display.Count() == 1) {
                    answerKey[6] = display[0];
                }
            }

            //Locate "e" wire
            foreach(string entry in wires[6]) {
                List<char> display = entry.ToList();
                display.Remove(answerKey[0]);
                display.Remove(answerKey[6]);

                foreach(char wire in wires[4][0]) {
                    display.Remove(wire);
                }

                if(display.Count() == 1) {
                    answerKey[4] = display[0];
                    break;
                }
            }

            //Locate "b"
            foreach(string entry in wires[5]) {
                List<char> display = entry.ToList();
                display.Remove(answerKey[0]);
                display.Remove(answerKey[6]);

                List<char> four = wires[4][0].ToList();
                foreach(char wire in display) {
                    four.Remove(wire);
                }

                List<char> one = wires[2][0].ToList();
                foreach(char wire in one) {
                    four.Remove(wire);
                }

                if(four.Count() == 1) {
                    answerKey[1] = four[0];
                    break;
                }
            }

            List<char> display1 = wires[5][0].ToList();
            //Locate "d"
            foreach(string entry in wires[5]) {
                if(entry != wires[5][0]) {
                    foreach(char wire in entry) {
                        if(!display1.Contains(wire)) {
                            display1.Remove(wire);
                        }
                    }
                    foreach(char wire in wires[5][0]) {
                        if(!entry.Contains(wire.ToString())) {
                            display1.Remove(wire);
                        }
                    }
                }
            }
            display1.Remove(answerKey[0]);
            display1.Remove(answerKey[6]);
            answerKey[3] = display1[0];

            display1 = wires[7][0].ToList();
            //Locate "f"
            foreach(string entry in wires[6]) {
                foreach(char wire in wires[7][0]) {
                    if(!entry.Contains(wire)) {
                        display1.Remove(wire);
                    }
                }
            }
            
            display1.Remove(answerKey[0]);
            display1.Remove(answerKey[1]);
            display1.Remove(answerKey[4]);
            display1.Remove(answerKey[3]);
            display1.Remove(answerKey[6]);
            answerKey[5] = display1[0];

            display1 = wires[7][0].ToList();
            answerKey.ToList().ForEach(x=>display1.Remove(x));
            answerKey[2] = display1[0];

            answerKey.ToList().ForEach(x=>Console.Write("{0},", x));
            Console.WriteLine();

            int tempSum = 0;

            for(int i = 3; i >= 0; i--) {
                tempSum += ((int) Math.Pow(10, i)) * DisplayToNumber(panel2[3-i], answerKey);
            }

            Console.WriteLine(tempSum);

            sum += tempSum;
        }

        Console.WriteLine(sum);
    }

    public static int DisplayToNumber(String display, char[] answerKey) {
        if(display.Count() == 2) {
            return 1;
        } else if(display.Count() == 4) {
            return 4;
        } else if(display.Count() == 3) {
            return 7;
        } else if(display.Count() == 7) {
            return 8;
        }

        if(display.Count() == 5) {
            if(display.Contains(answerKey[1]) && display.Contains(answerKey[5])) {
                return 5;
            } else if(display.Contains(answerKey[2]) && display.Contains(answerKey[4])) {
                return 2;
            } else if(display.Contains(answerKey[2]) && display.Contains(answerKey[5])) {
                return 3;
            }
        }

        if(display.Count() == 6) {
            if(display.Contains(answerKey[3]) && display.Contains(answerKey[2])) {
                return 9;
            } else if(display.Contains(answerKey[3]) && display.Contains(answerKey[4])) {
                return 6;
            } else if(display.Contains(answerKey[2]) && display.Contains(answerKey[4])) {
                return 0;
            }
        }

        return -1;
    }
}