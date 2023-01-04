   //https://adventofcode.com/2022/day/10
 
  class Day10
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            int sigStrength = 1;
            int finalStrength = 0;
            int cycle = 0;
            line = sr.ReadLine();
            while (line!=null){
                if ((cycle-20)%40 == 0){
                    finalStrength+=cycle*sigStrength;
                }
                string[] splitter = line.Split(" ");
                if (splitter[0] == "addx"){
                    cycle++;
                    if ((cycle-20)%40 == 0){
                        finalStrength+=cycle*sigStrength;
                    }
                    cycle++;
                    sigStrength += Int32.Parse(splitter[1]);
                }
                else if (splitter[0] == "noop"){
                    cycle++;
                }
                line = sr.ReadLine();
            }

            Console.Write(finalStrength);     

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            int register = 1;
            int pixelPos = 0;
            int cycle = 0;
            List<string> image = new List<string>();
            line = sr.ReadLine();
            while (line!=null){
                if (cycle == register || cycle == register-1 || cycle == register+1){
                    image.Add("#");
                }
                else{
                    image.Add(".");
                }
                if ((cycle+1)%40 == 0){
                    image.Add("\n");
                    cycle -= 40;
                }
                string[] splitter = line.Split(" ");
                if (splitter[0] == "addx"){
                    cycle++;
                    if (cycle == register || cycle == register-1 || cycle == register+1){
                        image.Add("#");
                    }
                    else{
                        image.Add(".");
                    }
                    if ((cycle+1)%40 == 0){
                        image.Add("\n");
                        cycle-=40;
                    }
                    cycle++;
                    register += Int32.Parse(splitter[1]);
                }
                else if (splitter[0] == "noop"){
                    cycle++;

                }
                line = sr.ReadLine();
            }

            for(int i = 0; i < image.Count(); i++){
                Console.Write(image[i]);
            }      

        }
    }