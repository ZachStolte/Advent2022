 
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
            Dictionary<(int, int), (int, int)> pairs = new Dictionary<(int, int), (int, int)>();
            HashSet<(int, int)> beacons = new HashSet<(int, int)>();
            int largestX = 0;
            int targetRow = 2000000;
            int iterator = 0;
            line = sr.ReadLine();
            int dimensions = 4000000;
            while (line!=null){
                string[] input = line.Split(" ");

                string sensX = input[2].Split("=")[1];
                sensX = sensX.Split(",")[0];
                if (int.Parse(sensX) > largestX){
                    largestX = int.Parse(sensX);
                }

                string sensY = input[3].Split("=")[1];
                sensY = sensY.Split(":")[0];

                (int, int) sensorCoords = (int.Parse(sensX), int.Parse(sensY));

                string beacX = input[8].Split("=")[1];
                beacX = beacX.Split(",")[0];

                string beacY = input[9].Split("=")[1];
                (int, int) beacon = (int.Parse(beacX), int.Parse(beacY));

                pairs.Add(sensorCoords, beacon);
                beacons.Add(beacon);

                int taxiCab = Math.Abs(int.Parse(sensX) - int.Parse(beacX)) + Math.Abs(int.Parse(sensY) - int.Parse(beacY));
                line = sr.ReadLine();
            }
            
            for (int i = 0; i < dimensions; i++){
                for (int j = 0; j < dimensions; j++){
                    PriorityQueue<(int, int), int> scannerQueue = new PriorityQueue<(int, int), int>();
                    foreach((int, int) scanner in pairs.Keys.ToList()){
                        int distance =  Math.Abs(j - scanner.Item1) + Math.Abs(i-scanner.Item2);
                        int scanRange = Math.Abs(scanner.Item1 - pairs[scanner].Item1) + Math.Abs(scanner.Item2 - pairs[scanner].Item2);
                        scannerQueue.Enqueue(scanner, distance-scanRange);
                    }

                    bool located = true;
                    while(scannerQueue.Count > 0 && located){
                        (int, int) scanner = scannerQueue.Dequeue();
                        (int, int) beacon = pairs[scanner];
                        int scanRange = Math.Abs(scanner.Item1 - pairs[scanner].Item1) + Math.Abs(scanner.Item2 - pairs[scanner].Item2);

                        if (scanRange >= Math.Abs(j - scanner.Item1) + Math.Abs(i - scanner.Item2)){
                            located = false;

                            int xDistance = scanner.Item1 - j;
                            int remover = Math.Abs(scanRange - Math.Abs(i - scanner.Item2));

                            j+=xDistance + remover;
                        }
                    }

                    if (located){
                        Console.Write(j + ", " + i + "\n" + (j*dimensions + i));
                        i = dimensions;
                        j = dimensions;
                    }
                }
            }

        }
    }