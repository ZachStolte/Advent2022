  class Template
    {

        public class Tree {
            public int x;
            public int y; 
            public int size;
            public int gridEdge;
            public List<Tree> neighbors;
            public Boolean checkVis(Char Direction){
                if (Direction = 'N'){
                    if(y == 0){
                        return true;
                    }
                    else if (neighbors[0].size < size){
                        return neighbors[0].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction = 'E'){
                    if(X == gridEdge){
                        return true;
                    }
                    else if (neighbors[0].size < size){
                        return neighbors[0].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction = 'S'){
                    if(y == gridEdge){
                        return true;
                    }
                    else if (neighbors[0].size < size){
                        return neighbors[0].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction = 'W'){
                    if(x == 0){
                        return true;
                    }
                    else if (neighbors[0].size < size){
                        return neighbors[0].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
            }
        }

        public static void populateNeighbors(List<List<Tree>> grid, int gridDim){
            for (int i = 0; i < gridDim; i++){
                for (int j = 0; j < gridDim; j++){
                    if (i!=0){
                        grid[i][j].neighbors[0] = grid[i-1][j];
                    }
                    else{
                        grid[i][j].neighbors[0] = null;
                    }

                    if (j!=gridDim){
                        grid[i][j].neighbors[1] = grid[i][j+1];
                    }
                    else{
                        grid[i][j].neighbors[1] = null;
                    }

                    if (i!=gridDim){
                        grid[i][j].neighbors[2] = grid[i+1][j];
                    }
                    else{
                        grid[i][j].neighbors[2] = null;
                    }

                    if (j!=0){
                        grid[i][j].neighbors[3] = grid[i][j-1];
                    }
                    else{
                        grid[i][j].neighbors[3] = null;
                    }
                }
            }
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            int gridDim = line.Length;
            int iterator = 0;
            List<List<Tree>> grid = new List<List<Tree>>();
            for (int i = 0; i < gridDim; i++){
                grid.Add(new List<Tree>());
            }
            while (line!=null){
                for (int i = 0; i < gridDim; i++){
                    grid[iterator][i] = new Tree();
                    grid[iterator][i].x = i;
                    grid[iterator][i].y = iterator;
                    grid[iterator][i].size = Int32.Parse(line[i]);
                    grid[iterator][i].gridEdge = gridDim;
                }
                line = sr.ReadLine();
            }
            populateNeighbors(grid, gridDim);

            int visibleNum = 0;
            for (int i = 0; i < gridDim; i++){
                for (int j = 0; j < gridDim; j++){
                    Boolean visible = false;
                    if (grid[i][j].checkVis('N'))
                        visible = true;
                    if (grid[i][j].checkVis('E'))
                        visible = true;
                    if (grid[i][j].checkVis('S'))
                        visible = true;
                    if (grid[i][j].checkVis('W'))
                        visible = true;
                    if (visible)
                        visibleNum++;        
                }
            }
            Console.Write(visibleNum);     

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