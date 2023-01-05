  class Day12
    {

        public class Node{
            public int[] location = new int[2];
            public int distance = int.MaxValue;
            public char value;

        }
        public static int shortestPath(List<List<Node>> grid, Queue<Node> queue){
            while(queue.Count > 0){
                Node current = queue.Dequeue();
                if (current.value > 'z'){
                    return current.distance;
                }
                if(current.location[0] > 0){
                    if (current.value - grid[current.location[0]-1][current.location[1]].value >= -1 && grid[current.location[0]-1][current.location[1]].distance == int.MaxValue){
                        queue.Enqueue(grid[current.location[0]-1][current.location[1]]);
                        grid[current.location[0]-1][current.location[1]].distance = current.distance + 1;
                    }
                }
                if(current.location[0] < grid.Count()-1){
                    if (current.value - grid[current.location[0]+1][current.location[1]].value >= -1 && grid[current.location[0]+1][current.location[1]].distance == int.MaxValue){
                        queue.Enqueue(grid[current.location[0]+1][current.location[1]]);
                        grid[current.location[0]+1][current.location[1]].distance = current.distance + 1;
                    }
                }
                if(current.location[1] > 0){
                    if (current.value - grid[current.location[0]][current.location[1]-1].value >= -1 && grid[current.location[0]][current.location[1]-1].distance == int.MaxValue){
                        queue.Enqueue(grid[current.location[0]][current.location[1]-1]);
                        grid[current.location[0]][current.location[1]-1].distance = current.distance + 1;
                    }
                }
                if(current.location[1] < grid[0].Count()-1){
                    if (current.value - grid[current.location[0]][current.location[1]+1].value >= -1 && grid[current.location[0]][current.location[1]+1].distance == int.MaxValue){
                        queue.Enqueue(grid[current.location[0]][current.location[1]+1]);
                        grid[current.location[0]][current.location[1]+1].distance = current.distance + 1;
                    }
                }
                return shortestPath(grid, queue);
            }
            return 0;
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<List<Node>> grid = new List<List<Node>>();
            Queue<Node> queue = new Queue<Node>();
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
                        grid[iterator][i].distance = 0;
                        start = grid[iterator][i];
                        queue.Enqueue(start);
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