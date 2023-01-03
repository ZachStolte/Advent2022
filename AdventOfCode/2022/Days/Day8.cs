  class Day8
    {

        public class Tree {
            public int x;
            public int y; 
            public int size;
            public int gridEdge;
            public List<Tree> neighbors = new List<Tree>();
            public Boolean checkVis(Char Direction){
                if (size == -1){
                    return true;
                }
                if (Direction == 'N'){
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
                if (Direction == 'E'){
                    if(x == gridEdge-1){
                        return true;
                    }
                    else if (neighbors[1].size < size){
                        return neighbors[1].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction == 'S'){
                    if(y == gridEdge-1){
                        return true;
                    }
                    else if (neighbors[2].size < size){
                        return neighbors[2].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction == 'W'){
                    if(x == 0){
                        return true;
                    }
                    else if (neighbors[3].size < size){
                        return neighbors[3].checkVis(Direction);
                    }
                    else{
                        return false;
                    }
                }
                return false;
            }
        }

        public static void populateNeighbors(List<List<Tree>> grid, int gridDim){
            Tree emptyTree = new Tree();
            emptyTree.size = -1;
            for (int i = 0; i < gridDim-1; i++){
                for (int j = 0; j < gridDim-1; j++){
                    for(int k = 0; k < 4; k++){
                        grid[i][j].neighbors.Add(emptyTree);
                    }
                    if (i!=0){
                        grid[i][j].neighbors[0] = grid[i-1][j];
                    }
                    else{
                        grid[i][j].neighbors[0] = emptyTree;
                    }

                    if (j!=gridDim){
                        grid[i][j].neighbors[1] = grid[i][j+1];
                    }
                    else{
                        grid[i][j].neighbors[1] = emptyTree;
                    }

                    if (i!=gridDim){
                        grid[i][j].neighbors[2] = grid[i+1][j];
                    }
                    else{
                        grid[i][j].neighbors[2] = emptyTree;
                    }

                    if (j!=0){
                        grid[i][j].neighbors[3] = grid[i][j-1];
                    }
                    else{
                        grid[i][j].neighbors[3] = emptyTree;
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
                for (int j = 0; j < gridDim; j++){
                    grid[i].Add(new Tree());
                }
            }
            while (line!=null){
                for (int i = 0; i < gridDim; i++){
                    //grid[iterator][i] = new Tree();
                    grid[iterator][i].x = i;
                    grid[iterator][i].y = iterator;
                    grid[iterator][i].size = Int32.Parse(line[i].ToString());
                    grid[iterator][i].gridEdge = gridDim;
                    //for (int j = 0; j < 4; j++){
                        //grid[iterator][i].neighbors.Add(new Tree());
                    //}
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