  class Day7
    {

        public class Directory{
            public Directory Parent;
            public String Name;
            public List<Directory> Children = new List<Directory>();
            public int fileSum = 0;

            public int getChildSum(){
                if(Children.Count>0){
                    for (int i = 0; i < Children.Count(); i++){
                        fileSum+=Children[i].getChildSum();
                    }
                }
                return fileSum;
            }

            public int gatherFinalSum(){
                int finalSum = 0;
                if (Children.Count>0){
                    for (int i = 0; i < Children.Count(); i++){
                        finalSum+=Children[i].gatherFinalSum();
                    }
                }
                if (fileSum <= 100000){
                    finalSum+=fileSum;
                }
                return finalSum;
            }

            public int searchSmall(int Min){
                int smallSum = fileSum;
                if (smallSum > Min){
                    for (int i = 0; i < this.Children.Count; i++){
                        int childSum = this.Children[i].searchSmall(Min);
                        if (childSum >= Min && childSum < smallSum){
                            smallSum = childSum;
                        }
                    }
                }
                
                return smallSum;
            }
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<Directory> dirList = new List<Directory>();
            Directory initial = new Directory();
            dirList.Add(initial);
            initial.Name = "/";
            int debugCheck = 0;
            Directory current = initial;
            while (line!=null){
                if(line.Contains("cd") && line.Contains("$")){
                    if (line.Contains("..")){
                        if (current.Parent != null){
                            current = current.Parent;
                            debugCheck++;
                        }
                    }
                    if (line.Contains("/")){
                        current = initial;
                    }
                    else{
                        String target = line.Split(' ')[2];
                        for (int i = 0; i < current.Children.Count(); i++){
                            if(current.Children[i].Name == target){
                                current = current.Children[i];
                            }
                        }
                    }
                }

                else if (line.Contains("dir")){
                    String target = line.Split(" ")[1];
                    Boolean newDir = true;
                    for (int i = 0; i < current.Children.Count(); i++){
                        if(current.Children[i].Name == target){
                            newDir = false;
                            break;
                        }
                    }
                    if (newDir){
                        Directory Dir = new Directory();
                        Dir.Parent = current;
                        Dir.Name=target;
                        current.Children.Add(Dir);
                        dirList.Add(Dir);                        
                    }
                }

                else if (!line.Contains("$")){
                    String num = line.Split(" ")[0];
                    int size = Int32.Parse(num);
                    current.fileSum+=size;
                }
                line = sr.ReadLine();
            }

            
            initial.getChildSum();
            int finalSum = initial.gatherFinalSum();
            Console.Write(finalSum); 

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<Directory> dirList = new List<Directory>();
            Directory initial = new Directory();
            dirList.Add(initial);
            initial.Name = "/";
            int debugCheck = 0;
            Directory current = initial;
            while (line!=null){
                if(line.Contains("cd") && line.Contains("$")){
                    if (line.Contains("..")){
                        if (current.Parent != null){
                            current = current.Parent;
                            debugCheck++;
                        }
                    }
                    if (line.Contains("/")){
                        current = initial;
                    }
                    else{
                        String target = line.Split(' ')[2];
                        for (int i = 0; i < current.Children.Count(); i++){
                            if(current.Children[i].Name == target){
                                current = current.Children[i];
                            }
                        }
                    }
                }

                else if (line.Contains("dir")){
                    String target = line.Split(" ")[1];
                    Boolean newDir = true;
                    for (int i = 0; i < current.Children.Count(); i++){
                        if(current.Children[i].Name == target){
                            newDir = false;
                            break;
                        }
                    }
                    if (newDir){
                        Directory Dir = new Directory();
                        Dir.Parent = current;
                        Dir.Name=target;
                        current.Children.Add(Dir);
                        dirList.Add(Dir);                        
                    }
                }

                else if (!line.Contains("$")){
                    String num = line.Split(" ")[0];
                    int size = Int32.Parse(num);
                    current.fileSum+=size;
                }
                line = sr.ReadLine();
            }

            
            initial.getChildSum();
            int finalSum = initial.searchSmall(8381165);
            Console.Write(finalSum); 

        }
    }