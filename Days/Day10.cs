class Day10 {
    public static void Part1(StreamReader sr) {
        int sum = 0;

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string syntax = "";
            bool valid = true;
            int score = 0;
            foreach(char ch in line) {
                if(!valid)
                    break;
                int prevIndex = syntax.Length - 1;
                switch(ch) {
                    case ')':
                        if(syntax[prevIndex] != '(') {
                            score = 3;
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case ']':
                        if(syntax[prevIndex] != '[') {
                            score = 57;
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case '}':
                        if(syntax[prevIndex] != '{') {
                            score = 1197;
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case '>':
                        if(syntax[prevIndex] != '<') {
                            score = 25137;
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    default:
                        syntax += ch;
                        break;
                }
            }

            sum += score;
        }

        Console.WriteLine(sum);
    }

    public static void Part2(StreamReader sr) {
        List<string> incomplete = new List<string>();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string syntax = "";
            bool valid = true;
            foreach(char ch in line) {
                if(!valid)
                    break;
                int prevIndex = syntax.Length - 1;
                switch(ch) {
                    case ')':
                        if(syntax[prevIndex] != '(') {
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case ']':
                        if(syntax[prevIndex] != '[') {
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case '}':
                        if(syntax[prevIndex] != '{') {
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    case '>':
                        if(syntax[prevIndex] != '<') {
                            valid = false;
                        } else {
                            syntax = syntax.Remove(prevIndex);
                        }
                        break;
                    default:
                        syntax += ch;
                        break;
                }
            }
            
            if(valid)
                incomplete.Add(syntax);
        }

        List<long> scores = new List<long>();
        foreach(string line in incomplete) {
            List<char> syntax = line.Reverse().ToList();

            long score = 0;
            foreach(char ch in syntax) {
                score *= 5;

                switch(ch) {
                    case '(':
                        score += 1;
                        break;
                    case '[':
                        score += 2;
                        break;
                    case '{':
                        score += 3;
                        break;
                    case '<':
                        score += 4;
                        break;
                }
            }

            scores.Add(score);
        }

        scores.Sort();

        scores.ForEach(x=>Console.WriteLine(x));

        long winner = scores[scores.Count / 2];

        Console.WriteLine(winner);
    }
}