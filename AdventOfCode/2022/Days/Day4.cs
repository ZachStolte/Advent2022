  //https://adventofcode.com/2022/day/4
  class Day4
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            int sum = 0;
            String[] Ranges;
            String[] range1;
            String[] range2;
            line = sr.ReadLine();
            while (line!=null){
                Ranges = line.Split(',');
                range1 = Ranges[0].Split('-');
                range2 = Ranges[1].Split('-');
                Boolean done = false;
                //Console.Write("[" + range1[0]+"-"+range1[1]+"]" +"[" +range2[0]+"-"+range2[1]+"]\n");
                if (Int32.Parse(range1[0]) <= Int32.Parse(range2[0])){
                    if (Int32.Parse(range2[1]) <= Int32.Parse(range1[1])){
                        sum++;
                        done = true;
                        //Console.Write("Added\n");
                    }
                }
                if (Int32.Parse(range1[0]) >= Int32.Parse(range2[0]) && !done){
                    if (Int32.Parse(range2[1]) >= Int32.Parse(range1[1])){
                        sum++;
                        //Console.Write("Added\n");
                    }
                }
                line = sr.ReadLine();
            }     
            Console.Write(sum);
        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            int sum = 0;
            String[] Ranges;
            String[] range1;
            String[] range2;
            line = sr.ReadLine();
            while (line!=null){
                Ranges = line.Split(',');
                range1 = Ranges[0].Split('-');
                range2 = Ranges[1].Split('-');
                //Boolean done = false;
                //Console.Write("[" + range1[0]+"-"+range1[1]+"]" +"[" +range2[0]+"-"+range2[1]+"]\n");
                //if (Int32.Parse(range1[0]) == Int32.Parse(range2[0]) || Int32.Parse(range1[1]) == Int32.Parse(range2[1])){
                  //  sum++;
                    //done = true;
                //}
                if (Int32.Parse(range1[0]) >= Int32.Parse(range2[0]) && Int32.Parse(range1[0]) <= Int32.Parse(range2[1])){
                        sum++;
                        //done = true;
                        //Console.Write("Added\n");
                }
                else if (Int32.Parse(range1[1]) >= Int32.Parse(range2[0]) && Int32.Parse(range1[1]) <= Int32.Parse(range2[1])){
                        sum++;
                       // done = true;
                        //Console.Write("Added\n");
                }
                else if (Int32.Parse(range2[0]) >= Int32.Parse(range1[0]) && Int32.Parse(range2[0]) <= Int32.Parse(range1[1])){
                        sum++;
                        //done = true;
                        //Console.Write("Added\n");
                }
                else if (Int32.Parse(range2[1]) >= Int32.Parse(range1[0]) && Int32.Parse(range2[1]) <= Int32.Parse(range1[1])){
                        sum++;
                        //done = true;
                        //Console.Write("Added\n");
                }
                line = sr.ReadLine();
            }     
            Console.Write(sum);
        }
    }