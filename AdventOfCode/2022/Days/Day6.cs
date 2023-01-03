  //https://adventofcode.com/2022/day/6
  
  class Day6    
  {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            char one = line[0];
            char two = line[1];
            char three = line[2];
            int iterator = 3;
            Boolean done = false;
            while (!done){
                if (one == line[iterator] || two == line[iterator] || three == line[iterator] || one == two || one == three || two == three){
                    one = two;
                    two = three;
                    three = line[iterator];
                    iterator++;
                }
                else{
                    done = true;
                    iterator++;
                }
            }
            Console.Write(line[iterator]);     
            Console.Write(iterator);

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<char> messageChecker = new List<char>();
            for (int i = 0; i < 14; i++){
                messageChecker.Add(line[i]);
            }
            int iterator = 14;
            Boolean done = false;
            while (!done){
                for (int i = 0; i < 13; i++){
                    messageChecker[i] = messageChecker[i+1];
                }
                messageChecker[13] = line[iterator];

                Boolean unique = true;
                for (int i = 0; i < 14; i++){
                    for (int j = 0; j < 14; j++){
                        if (j!=i && messageChecker[i] == messageChecker[j]){
                            unique = false;
                        }
                    }
                }
                iterator++;
                if(unique){ 
                    done = true;
                }
            }
            Console.WriteLine(iterator);     

        }
    }