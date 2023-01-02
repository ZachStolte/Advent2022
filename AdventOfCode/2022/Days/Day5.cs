  //https://adventofcode.com/2022/day/5
  
  class Day5
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            List<List<char>> Towers = new List<List<char>>();

            for (int i = 0; i < 9; i++){
                List<char> column = new List<char>();
                Towers.Add(column);
            }
            for (int i = 0; i < 8; i++){ //initializes the lists, but in reverse
                line = sr.ReadLine();
                if (line != null){
                    if (line[1] != ' ' ){
                        Towers[0].Add(line[1]);
                    }
                    if (line[5] != ' '){
                        Towers[1].Add(line[5]);
                    }
                    if (line[9] != ' '){
                        Towers[2].Add(line[9]);
                    }
                    if (line[13] != ' '){
                        Towers[3].Add(line[13]);
                    }
                    if (line[17] != ' '){
                        Towers[4].Add(line[17]);
                    }
                    if (line[21] != ' '){
                        Towers[5].Add(line[21]);
                    }
                    if (line[25] != ' '){
                        Towers[6].Add(line[25]);
                    }
                    if (line[29] != ' '){
                        Towers[7].Add(line[29]);
                    }
                    if (line[33] != ' '){
                        Towers[8].Add(line[33]);
                    }   
                }
            }

            for (int i = 0; i < 9; i++){ //reverses the lists so the "top" value is at the end of the list
                Towers[i].Reverse();
            }


            line = sr.ReadLine(); 
            line = sr.ReadLine(); //skips a line ahead, reaches main input
            line = sr.ReadLine();
            while (line!=null){
                int extraDigit = 0;
                int moveNum = 0;
                String converterString;
                int start = 0;
                int end = 0;

                if (line[6] != ' '){
                    extraDigit = 1;
                    converterString = line[5].ToString() + line[6].ToString();
                }
                else{
                    converterString = line[5].ToString();
                }
                moveNum = Int32.Parse(converterString);

                start = Int32.Parse(line[12+extraDigit].ToString())-1;
                end = Int32.Parse(line[17+extraDigit].ToString())-1;

                for (int i = 0; i < moveNum; i++){
                    Towers[end].Add(Towers[start].Last());
                    Towers[start].RemoveAt(Towers[start].Count - 1);
                }

                line = sr.ReadLine();
            }
            String finalString = "";
            for (int i = 0; i < 9; i++){
                finalString+=Towers[i].Last().ToString();
            }
            Console.Write(finalString);

        }

        public static void Part2(StreamReader sr)
{
            string line = "";
            List<List<char>> Towers = new List<List<char>>();

            for (int i = 0; i < 9; i++){
                List<char> column = new List<char>();
                Towers.Add(column);
            }
            for (int i = 0; i < 8; i++){ //initializes the lists, but in reverse
                line = sr.ReadLine();
                if (line != null){
                    if (line[1] != ' ' ){
                        Towers[0].Add(line[1]);
                    }
                    if (line[5] != ' '){
                        Towers[1].Add(line[5]);
                    }
                    if (line[9] != ' '){
                        Towers[2].Add(line[9]);
                    }
                    if (line[13] != ' '){
                        Towers[3].Add(line[13]);
                    }
                    if (line[17] != ' '){
                        Towers[4].Add(line[17]);
                    }
                    if (line[21] != ' '){
                        Towers[5].Add(line[21]);
                    }
                    if (line[25] != ' '){
                        Towers[6].Add(line[25]);
                    }
                    if (line[29] != ' '){
                        Towers[7].Add(line[29]);
                    }
                    if (line[33] != ' '){
                        Towers[8].Add(line[33]);
                    }   
                }
            }

            for (int i = 0; i < 9; i++){ //reverses the lists so the "top" value is at the end of the list
                Towers[i].Reverse();
            }


            line = sr.ReadLine(); 
            line = sr.ReadLine(); //skips a line ahead, reaches main input
            line = sr.ReadLine();
            while (line!=null){
                int extraDigit = 0;
                int moveNum = 0;
                String converterString;
                int start = 0;
                int end = 0;
                List<char> charPile = new List<char>();

                if (line[6] != ' '){
                    extraDigit = 1;
                    converterString = line[5].ToString() + line[6].ToString();
                }
                else{
                    converterString = line[5].ToString();
                }
                moveNum = Int32.Parse(converterString);

                start = Int32.Parse(line[12+extraDigit].ToString())-1;
                end = Int32.Parse(line[17+extraDigit].ToString())-1;

                for (int i = 0; i < moveNum; i++){
                    charPile.Add(Towers[start].Last());
                    Towers[start].RemoveAt(Towers[start].Count-1);
                }
                charPile.Reverse();
                for (int i = 0; i < moveNum; i++){
                    Towers[end].Add(charPile[i]);
                }

                line = sr.ReadLine();
            }
            String finalString = "";
            for (int i = 0; i < 9; i++){
                finalString+=Towers[i].Last().ToString();
            }
            Console.Write(finalString);

        }
    }