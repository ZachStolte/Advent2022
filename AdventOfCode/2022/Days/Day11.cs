  class Day11
    {

        public class Monkey{
            public int monkeyNum;
            public List<int> values = new List<int>();
            public int numCounted = 0;
            public String[] operation = new string[3];
            public int testDiv;
            public int testSuccessTarget;
            public int testFailTarget;


        }

        public static void monkeyAround(List<Monkey> monkeys){
                for (int i = 0; i < monkeys.Count(); i++){
                    int removeNum = 0;
                    for(int j = 0; j < monkeys[i].values.Count(); j++){
                        int firstOperationPosition = 0;
                        int secondOperationPosition = 0;
                        int value = 0;

                        if(monkeys[i].operation[0].Contains("old")){
                            firstOperationPosition = monkeys[i].values[j];
                        }
                        else{
                            firstOperationPosition = Int32.Parse(monkeys[i].operation[0]);
                        }

                        string midOperator = monkeys[i].operation[1];
                        if(monkeys[i].operation[2].Contains("old")){
                            secondOperationPosition = monkeys[i].values[j];
                        }
                        else{
                            secondOperationPosition = Int32.Parse(monkeys[i].operation[2]);
                        }

                        if (midOperator == "+"){
                            value = firstOperationPosition + secondOperationPosition;
                        }
                        else if (midOperator == "*"){
                            value = firstOperationPosition * secondOperationPosition;
                        }

                        value = value/3;

                        if (value%monkeys[i].testDiv == 0){
                            monkeys[monkeys[i].testSuccessTarget].values.Add(value);
                            removeNum++;
                        }
                        else{
                            monkeys[monkeys[i].testFailTarget].values.Add(value);
                            removeNum++;
                        }
                        monkeys[i].numCounted++;
                    }
                    if (removeNum > 0){
                        for (int j = 0; j < removeNum; j++){
                            monkeys[i].values.RemoveAt(0);
                        }
                    }
                }
        }

        public static void monkeyHarder(List<Monkey> monkeys, int blackMagic){ //I was unable to work out the "trick" to this part, needed a friend to give a hint. Code is my own.
                for (int i = 0; i < monkeys.Count(); i++){
                    int removeNum = 0;
                    for(int j = 0; j < monkeys[i].values.Count(); j++){
                        int firstOperationPosition = 0;
                        int secondOperationPosition = 0;
                        int value = 0;

                        if(monkeys[i].operation[0].Contains("old")){
                            firstOperationPosition = monkeys[i].values[j];
                        }
                        else{
                            firstOperationPosition = Int32.Parse(monkeys[i].operation[0]);
                        }

                        string midOperator = monkeys[i].operation[1];
                        if(monkeys[i].operation[2].Contains("old")){
                            secondOperationPosition = monkeys[i].values[j];
                        }
                        else{
                            secondOperationPosition = Int32.Parse(monkeys[i].operation[2]);
                        }

                        if (midOperator == "+"){
                            value = firstOperationPosition + secondOperationPosition;
                        }
                        else if (midOperator == "*"){
                            value = firstOperationPosition * secondOperationPosition;
                        }

                        if (value < 0){
                            Console.Write(value + "\n");
                        }
                        value = value % blackMagic;
                        int testNum = monkeys[i].testDiv;
                        if (value%testNum == 0){
                            monkeys[monkeys[i].testSuccessTarget].values.Add(value);
                            //Console.Write(value + "%" + testNum + ": Monkey " + i + "\n");
                            removeNum++;
                        }
                        else{
                            monkeys[monkeys[i].testFailTarget].values.Add(value);
                            removeNum++;
                        }
                        monkeys[i].numCounted++;
                    }
                    if (removeNum > 0){
                        for (int j = 0; j < removeNum; j++){
                            monkeys[i].values.RemoveAt(0);
                        }
                    }
                }
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<Monkey> monkeys = new List<Monkey>();
            int iterator = 0;
            String[] lineSplitter;
            while (line!=null){
                lineSplitter = line.Split(" ");
                if(lineSplitter.Count() > 1){
                    if(lineSplitter[0].Contains("Monkey")){
                        monkeys.Add(new Monkey());
                        monkeys[iterator].monkeyNum = iterator;
                    }
                    else if(lineSplitter[2]=="Starting"){
                        for(int i = 4; i < (lineSplitter.Count()); i++){
                            monkeys[iterator].values.Add(Int32.Parse(lineSplitter[i].Split(",")[0]));
                        }
                    }
                    else if(lineSplitter[2]=="Operation:"){
                        monkeys[iterator].operation = new string[3];
                        monkeys[iterator].operation[0] = lineSplitter[5];
                        monkeys[iterator].operation[1] = lineSplitter[6];
                        monkeys[iterator].operation[2] = lineSplitter[7];
                    }
                    else if(lineSplitter[2]=="Test:"){
                        monkeys[iterator].testDiv = Int32.Parse(lineSplitter[5]);
                    }
                    else if(lineSplitter[5]=="true:"){
                        monkeys[iterator].testSuccessTarget = Int32.Parse(lineSplitter[9]);
                    } 
                    else if(lineSplitter[5].Contains("false:")){
                        monkeys[iterator].testFailTarget = Int32.Parse(lineSplitter[9]);
                        iterator++;
                    }  
                }
                line = sr.ReadLine();
            }

            for(int i = 0; i < 20; i++){
                monkeyAround(monkeys);
            }

            int highest = 0;
            int second = 0;
            for (int i = 0; i < monkeys.Count(); i++){
                if (monkeys[i].numCounted > highest){
                    second = highest;
                    highest = monkeys[i].numCounted;
                }
                else if (monkeys[i].numCounted > second){
                    second = monkeys[i].numCounted;
                }
            }

            Console.Write(second * highest);     

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            line = sr.ReadLine();
            List<Monkey> monkeys = new List<Monkey>();
            int iterator = 0;
            String[] lineSplitter;
            while (line!=null){
                lineSplitter = line.Split(" ");
                if(lineSplitter.Count() > 1){
                    if(lineSplitter[0].Contains("Monkey")){
                        monkeys.Add(new Monkey());
                        monkeys[iterator].monkeyNum = iterator;
                    }
                    else if(lineSplitter[2]=="Starting"){
                        for(int i = 4; i < (lineSplitter.Count()); i++){
                            monkeys[iterator].values.Add(Int32.Parse(lineSplitter[i].Split(",")[0]));
                        }
                    }
                    else if(lineSplitter[2]=="Operation:"){
                        monkeys[iterator].operation = new string[3];
                        monkeys[iterator].operation[0] = lineSplitter[5];
                        monkeys[iterator].operation[1] = lineSplitter[6];
                        monkeys[iterator].operation[2] = lineSplitter[7];
                    }
                    else if(lineSplitter[2]=="Test:"){
                        monkeys[iterator].testDiv = Int32.Parse(lineSplitter[5]);
                    }
                    else if(lineSplitter[5]=="true:"){
                        monkeys[iterator].testSuccessTarget = Int32.Parse(lineSplitter[9]);
                    } 
                    else if(lineSplitter[5].Contains("false:")){
                        monkeys[iterator].testFailTarget = Int32.Parse(lineSplitter[9]);
                        iterator++;
                    }  
                }
                line = sr.ReadLine();
            }
            int blackMagic = 1;
            for (int i = 0; i < monkeys.Count(); i++){
                blackMagic = blackMagic * monkeys[i].testDiv;
            }

            for(int i = 0; i < 10000; i++){
                monkeyHarder(monkeys, blackMagic);
            }

            int highest = 0;
            int second = 0;
            for (int i = 0; i < monkeys.Count(); i++){
                if (monkeys[i].numCounted > highest){
                    second = highest;
                    highest = monkeys[i].numCounted;
                }
                else if (monkeys[i].numCounted > second){
                    second = monkeys[i].numCounted;
                }
            }

            Console.Write(second * highest);     

        }
    }