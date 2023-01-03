  class Day8
    {

        public class Tree {
            public int x;
            public int y; 
            public int size;
            public int gridEdge;
            public List<Tree> neighbors = new List<Tree>();
            public Boolean checkVis(Char Direction, int treeSize){
                if (size == -1){
                    return true;
                }
                if (Direction == 'N'){
                    if(y == 0){
                        return true;
                    }
                    else if (neighbors[0].size < treeSize){
                        return neighbors[0].checkVis(Direction, treeSize);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction == 'E'){
                    if(x == gridEdge-1){
                        return true;
                    }
                    else if (neighbors[1].size < treeSize){
                        return neighbors[1].checkVis(Direction, treeSize);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction == 'S'){
                    if(y == gridEdge-1){
                        return true;
                    }
                    else if (neighbors[2].size < treeSize){
                        return neighbors[2].checkVis(Direction, treeSize);
                    }
                    else{
                        return false;
                    }
                }
                if (Direction == 'W'){
                    if(x == 0){
                        return true;
                    }
                    else if (neighbors[3].size < treeSize){
                        return neighbors[3].checkVis(Direction, treeSize);
                    }
                    else{
                        return false;
                    }
                }
                return false;
            }

            public int getScore(Char Direction, int treeSize){
                if (size == -1){
                    return 0;
                }
                if (Direction == 'N'){
                    if(y == 0){
                        return 0;
                    }
                    else if (neighbors[0].size < treeSize){
                        return 1 + neighbors[0].getScore(Direction, treeSize);
                    }
                    else{
                        return 1;
                    }
                }
                if (Direction == 'E'){
                    if(x == gridEdge-1){
                        return 0;
                    }
                    else if (neighbors[1].size < treeSize){
                        return 1+neighbors[1].getScore(Direction, treeSize);
                    }
                    else{
                        return 1;
                    }
                }
                if (Direction == 'S'){
                    if(y == gridEdge-1){
                        return 0;
                    }
                    else if (neighbors[2].size < treeSize){
                        return 1+neighbors[2].getScore(Direction, treeSize);
                    }
                    else{
                        return 1;
                    }
                }
                if (Direction == 'W'){
                    if(x == 0){
                        return 0;
                    }
                    else if (neighbors[3].size < treeSize){
                        return 1+neighbors[3].getScore(Direction, treeSize);
                    }
                    else{
                        return 1;
                    }
                }
                return 0;
            }
        }


        public static void populateNeighbors(List<List<Tree>> grid, int gridDim){
            Tree emptyTree = new Tree();
            emptyTree.size = -1;
            emptyTree.gridEdge = gridDim;
            for (int i = 0; i < gridDim; i++){
                for (int j = 0; j < gridDim; j++){
                    for(int k = 0; k < 4; k++){
                        grid[i][j].neighbors.Add(emptyTree);
                    }
                    if (i!=0){
                        grid[i][j].neighbors[0] = grid[i-1][j];
                    }
                    else{
                        grid[i][j].neighbors[0] = emptyTree;
                    }

                    if (j!=gridDim-1){
                        grid[i][j].neighbors[1] = grid[i][j+1];
                    }
                    else{
                        grid[i][j].neighbors[1] = emptyTree;
                    }

                    if (i!=gridDim-1){
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
                    grid[iterator][i].x = i;
                    grid[iterator][i].y = iterator;
                    grid[iterator][i].size = Int32.Parse(line[i].ToString());
                    grid[iterator][i].gridEdge = gridDim;
                }
                iterator++;
                line = sr.ReadLine();
            }
            populateNeighbors(grid, gridDim);

            int visibleNum = 0;
            for (int i = 0; i < gridDim; i++){
                for (int j = 0; j < gridDim; j++){
                    Boolean visible = false;
                    if (grid[i][j].checkVis('N', grid[i][j].size))
                        visible = true;
                    if (grid[i][j].checkVis('E', grid[i][j].size))
                        visible = true;
                    if (grid[i][j].checkVis('S', grid[i][j].size))
                        visible = true;
                    if (grid[i][j].checkVis('W', grid[i][j].size))
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
                    grid[iterator][i].x = i;
                    grid[iterator][i].y = iterator;
                    grid[iterator][i].size = Int32.Parse(line[i].ToString());
                    grid[iterator][i].gridEdge = gridDim;
                }
                iterator++;
                line = sr.ReadLine();
            }
            populateNeighbors(grid, gridDim);

            int highScore = 0;
            for (int i = 0; i < gridDim; i++){
                for (int j = 0; j < gridDim; j++){
                    int tempScore = (grid[i][j].getScore('N', grid[i][j].size) * grid[i][j].getScore('E', grid[i][j].size)
                     * grid[i][j].getScore('S', grid[i][j].size) * grid[i][j].getScore('W', grid[i][j].size));
                    if (tempScore > highScore)
                        highScore = tempScore;
                }
            }
            Console.Write(highScore);
        }
    }