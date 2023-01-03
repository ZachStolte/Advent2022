  class Day9
    {
        public static void tailMove(List<int> headPos, List<int> tailPos){
            if (headPos[0]!=tailPos[0] && headPos[1]!=tailPos[1] && (Math.Abs(headPos[0]-tailPos[0])>1 || Math.Abs(headPos[1]-tailPos[1])>1)){
                if (headPos[0]-tailPos[0]>0 && headPos[1]-tailPos[1]>0){
                    tailPos[0]++;
                    tailPos[1]++;
                }
                if (headPos[0]-tailPos[0]<0 && headPos[1]-tailPos[1]>0){
                    tailPos[0]--;
                    tailPos[1]++;
                }
                if (headPos[0]-tailPos[0]>0 && headPos[1]-tailPos[1]<0){
                    tailPos[0]++;
                    tailPos[1]--;
                }
                if (headPos[0]-tailPos[0]<0 && headPos[1]-tailPos[1]<0){
                    tailPos[0]--;
                    tailPos[1]--;
                }

            }
            else if (Math.Abs(headPos[0]-tailPos[0])>1){
                if (headPos[0]-tailPos[0] > 0){
                    tailPos[0]++;
                }
                else{
                    tailPos[0]--;
                }
            }
            else if (Math.Abs(headPos[1]-tailPos[1])>1){
                if(headPos[1]-tailPos[1] > 0){
                    tailPos[1]++;
                }
                else{
                    tailPos[1]--;
                }
            }
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<int> headPos = new List<int>();
            headPos.Add(0);
            headPos.Add(0);
            List<int> tailPos = new List<int>();
            tailPos.Add(0);
            tailPos.Add(0);
            List<List<int>> visitedPos = new List<List<int>>();
            List<int> initialPos = new List<int>();
            initialPos.Add(0);
            initialPos.Add(0);
            visitedPos.Add(initialPos);
            while (line!=null){
                for (int i = 0; i < Int32.Parse(line[2].ToString()); i++){
                    if(line[0] == 'U'){
                    headPos[0] ++;
                    }
                    else if(line[0] == 'R'){
                        headPos[1] ++;
                    }
                    else if(line[0] == 'D'){
                        headPos[0] --;
                    }
                    else if(line[0] == 'L'){
                        headPos[1] --;
                    }
                    tailMove(headPos, tailPos);
                    Boolean unique = true;
                    for (int j = 0; j < visitedPos.Count(); j++){
                        if(tailPos[0] == visitedPos[j][0] && tailPos[1] == visitedPos[j][1]){
                            unique = false;
                        }
                    }
                    if (unique){
                        List<int> tempPos = new List<int>();
                        tempPos.Add(tailPos[0]);
                        tempPos.Add(tailPos[1]);
                        visitedPos.Add(tempPos);
                    }
                }
                line = sr.ReadLine();
            }
            Console.Write(visitedPos.Count());     

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