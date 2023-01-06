  class Day14
    {


        public static void addColumn(List<List<char>> grid){
            grid.Add(new List<char>());
            for (int i = 0; i < grid[0].Count; i++){
                grid[grid.Count-1].Add('.');
            }
        }
        public static void addRow(List<List<char>> grid){
            for (int i = 0; i < grid.Count; i++){
                grid[i].Add('.');
            }
        }

        public static bool sandDrop(HashSet<(int, int)> grid, int x, int y, int bottom){
            if (y > bottom){
                return false;
            }

            if (!grid.Contains((x, y+1))){
                return (sandDrop(grid, x, y+1, bottom));
            }
            else if (!grid.Contains((x-1, y+1))){
                return (sandDrop(grid, x-1, y+1, bottom));
            }
            else if (!grid.Contains((x+1, y+1))){
                return (sandDrop(grid, x+1, y+1, bottom));
            }
            else{
                grid.Add((x, y));
                return true;
            }
        }

        public static void Part1(StreamReader sr)
        {
            string line = "";
            HashSet<(int, int)> grid = new HashSet<(int, int)>();
            int bottom = 0;
            int dripDrop = 0;
            line = sr.ReadLine();
            while (line!=null){
                string[] input = line.Split(" -> ");
                string[] lastCoords = null;
                for (int i = 0; i < input.Count(); i++){
                    string[] coordinates = input[i].Split(',');
                    if (lastCoords != null){
                        if (coordinates[0]!=lastCoords[0]){
                            int lower = Math.Min(int.Parse(coordinates[0]), int.Parse(lastCoords[0]));
                            int higher = Math.Max(int.Parse(coordinates[0]), int.Parse(lastCoords[0]));
                            if (int.Parse(coordinates[1]) > bottom){
                                 bottom = int.Parse(coordinates[1]);
                            }
                            for(int j = lower; j <= higher; j++){
                                grid.Add((j, int.Parse(coordinates[1])));
                            }
                        }
                        else{
                            int lower = Math.Min(int.Parse(coordinates[1]), int.Parse(lastCoords[1]));
                            int higher = Math.Max(int.Parse(coordinates[1]), int.Parse(lastCoords[1]));
                            if (higher > bottom)
                                bottom = higher;
                            for(int j = lower; j <= higher; j++){
                                grid.Add((int.Parse(coordinates[0]), j));
                            }
                        }
                    }
                    lastCoords = coordinates;
                }
                line = sr.ReadLine();
            }
            bool rockBottom = true;
            while(rockBottom){
                if (sandDrop(grid, 500, 0, bottom)){
                    dripDrop++;
                } 
                else{
                    rockBottom = false;
                }
            }
            Console.Write(dripDrop);     
        }

        public static bool sandFloorDrop(HashSet<(int, int)> grid, int x, int y, int bottom){
            if (!grid.Contains((x, y+1))){
                if (y+1 == bottom+2){
                    grid.Add((x, y));
                    return true;
                }
                return (sandFloorDrop(grid, x, y+1, bottom));
            }
            else if (!grid.Contains((x-1, y+1))){
                if (y+1 == bottom+2){
                    grid.Add((x, y));
                    return true;
                }
                return (sandFloorDrop(grid, x-1, y+1, bottom));
            }
            else if (!grid.Contains((x+1, y+1))){
                if (y+1 == bottom+2){
                    grid.Add((x, y));
                    return true;
                }
                return (sandFloorDrop(grid, x+1, y+1, bottom));
            }
            else if (y == 0 && x == 500){
                return false;
            }
            else{
                grid.Add((x, y));
                return true;
            }
        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            HashSet<(int, int)> grid = new HashSet<(int, int)>();
            int bottom = 0;
            int dripDrop = 0;
            line = sr.ReadLine();
            while (line!=null){
                string[] input = line.Split(" -> ");
                string[] lastCoords = null;
                for (int i = 0; i < input.Count(); i++){
                    string[] coordinates = input[i].Split(',');
                    if (lastCoords != null){
                        if (coordinates[0]!=lastCoords[0]){
                            int lower = Math.Min(int.Parse(coordinates[0]), int.Parse(lastCoords[0]));
                            int higher = Math.Max(int.Parse(coordinates[0]), int.Parse(lastCoords[0]));
                            if (int.Parse(coordinates[1]) > bottom){
                                 bottom = int.Parse(coordinates[1]);
                            }
                            for(int j = lower; j <= higher; j++){
                                grid.Add((j, int.Parse(coordinates[1])));
                            }
                        }
                        else{
                            int lower = Math.Min(int.Parse(coordinates[1]), int.Parse(lastCoords[1]));
                            int higher = Math.Max(int.Parse(coordinates[1]), int.Parse(lastCoords[1]));
                            if (higher > bottom)
                                bottom = higher;
                            for(int j = lower; j <= higher; j++){
                                grid.Add((int.Parse(coordinates[0]), j));
                            }
                        }
                    }
                    lastCoords = coordinates;
                }
                line = sr.ReadLine();
            }
            bool rockBottom = true;
            while(rockBottom){
                if (sandFloorDrop(grid, 500, 0, bottom)){
                    dripDrop++;
                } 
                else{
                    rockBottom = false;
                    dripDrop++;
                }
            }
            Console.Write(dripDrop);     
        }
    }