  class Day12
    {

        public class Node{
            public int[] location = new int[2];
            public Boolean visited = false;
            public int distance = 0;
            public char value;

        }
        public static int shortestPath(List<List<Node>> grid, List<Node> queue){
            while(queue[0]!=null){
                if (queue[0].value > 'z'){
                    return queue[0].distance;
                }
                if(queue[0].location[0] > 0){
                    if (queue[0].value - grid[queue[0].location[0]-1][queue[0].location[1]].value >= -1 && grid[queue[0].location[0]-1][queue[0].location[1]].visited == false){
                        queue.Add(grid[queue[0].location[0]-1][queue[0].location[1]]);
                        grid[queue[0].location[0]-1][queue[0].location[1]].visited = true;
                        grid[queue[0].location[0]-1][queue[0].location[1]].distance = queue[0].distance + 1;
                    }
                }
                if(queue[0].location[0] < grid.Count()-1){
                    if (queue[0].value - grid[queue[0].location[0]+1][queue[0].location[1]].value >= -1 && grid[queue[0].location[0]+1][queue[0].location[1]].visited == false){
                        queue.Add(grid[queue[0].location[0]+1][queue[0].location[1]]);
                        grid[queue[0].location[0]+1][queue[0].location[1]].visited = true;
                        grid[queue[0].location[0]+1][queue[0].location[1]].distance = queue[0].distance + 1;
                    }
                }
                if(queue[0].location[1] > 0){
                    if (queue[0].value - grid[queue[0].location[0]][queue[0].location[1]-1].value >= -1 && grid[queue[0].location[0]][queue[0].location[1]-1].visited == false){
                        queue.Add(grid[queue[0].location[0]][queue[0].location[1]-1]);
                        grid[queue[0].location[0]][queue[0].location[1]-1].visited = true;
                        grid[queue[0].location[0]][queue[0].location[1]-1].distance = queue[0].distance + 1;
                    }
                }
                if(queue[0].location[1] < grid[0].Count()-1){
                    if (queue[0].value - grid[queue[0].location[0]][queue[0].location[1]+1].value >= -1 && grid[queue[0].location[0]][queue[0].location[1]+1].visited == false){
                        queue.Add(grid[queue[0].location[0]][queue[0].location[1]+1]);
                        grid[queue[0].location[0]][queue[0].location[1]+1].visited = true;
                        grid[queue[0].location[0]][queue[0].location[1]+1].distance = queue[0].distance + 1;
                    }
                }
                queue.RemoveAt(0);
                return shortestPath(grid, queue);
            }
            return 0;
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<List<Node>> grid = new List<List<Node>>();
            List<Node> queue = new List<Node>();
            int iterator = 0;
            Node start = new Node();
            while (line!=null){
                grid.Add(new List<Node>());
                for (int i = 0; i < line.Count(); i++){
                    grid[iterator].Add(new Node());
                    grid[iterator][i].location[0] = iterator;
                    grid[iterator][i].location[1] = i;
                    grid[iterator][i].value = line[i];
                    if (line[i]=='S'){
                        grid[iterator][i].value = (char)('a' - 1);
                        grid[iterator][i].visited = true;
                        start = grid[iterator][i];
                        queue.Add(start);
                    }
                    if (line[i] == 'E'){
                        grid[iterator][i].value = (char)('z' + 1);
                    }
                }
                iterator++;
                line = sr.ReadLine();
            }
            Console.Write(shortestPath(grid, queue));     

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