 
  class Day15
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            HashSet<(int, int)> grid = new HashSet<(int, int)>();
            int largestX = 0;
            int targetRow = 2000000;
            int iterator = 0;
            line = sr.ReadLine();
            while (line!=null){
                string[] input = line.Split(" ");

                string sensX = input[2].Split("=")[1];
                sensX = sensX.Split(",")[0];
                if (int.Parse(sensX) > largestX){
                    largestX = int.Parse(sensX);
                }

                string sensY = input[3].Split("=")[1];
                sensY = sensY.Split(":")[0];

                if (!grid.Contains((int.Parse(sensX), int.Parse(sensY))) && int.Parse(sensY) == targetRow){
                    grid.Add((int.Parse(sensX), int.Parse(sensY)));
                    iterator++;
                }

                string beacX = input[8].Split("=")[1];
                beacX = beacX.Split(",")[0];

                string beacY = input[9].Split("=")[1];
                if (!grid.Contains((int.Parse(beacX), int.Parse(beacY))) && int.Parse(beacY) == targetRow){
                    grid.Add((int.Parse(beacX), int.Parse(beacY)));
                }

                int taxiCab = Math.Abs(int.Parse(sensX) - int.Parse(beacX)) + Math.Abs(int.Parse(sensY) - int.Parse(beacY));

                if (targetRow < int.Parse(sensY)+taxiCab && targetRow > int.Parse(sensY)-taxiCab){
                    int offset = Math.Abs(targetRow - int.Parse(sensY));

                    for (int i = 0; i <= taxiCab - offset; i++){
                        if (!grid.Contains((int.Parse(sensX)+i, targetRow))){
                            grid.Add((int.Parse(sensX)+i, targetRow));
                            iterator++;
                        }
                        if (!grid.Contains((int.Parse(sensX)-i, targetRow))){
                            grid.Add((int.Parse(sensX)-i, targetRow));
                            iterator++;
                        }

                    }
                }
                line = sr.ReadLine();
            }
            Console.Write(iterator);    

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            while (line!=null){

                line = sr.ReadLine();
            }     

        }
    }