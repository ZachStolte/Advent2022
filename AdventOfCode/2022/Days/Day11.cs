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
                            secondOperationPosition = Int32.Parse(monkeys[i].operation[0]);
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
                            monkeys[i].values.RemoveAt(0);
                        }
                        else{
                            monkeys[monkeys[i].testFailTarget].values.Add(value);
                            monkeys[i].values.RemoveAt(0);
                        }
                        monkeys[i].numCounted++;
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
                    if(lineSplitter[0] == "Monkey"){
                        monkeys.Add(new Monkey());
                        monkeys[iterator].monkeyNum = iterator;
                    }
                    if(lineSplitter[0]=="Starting"){
                        for(int i = 2; i < (lineSplitter.Count()); i++){
                            monkeys[iterator].values.Add(Int32.Parse(lineSplitter[i].Split(",")[0]));
                        }
                    }
                    if(lineSplitter[0]=="Operation:"){
                        monkeys[iterator].operation = new string[3];
                        monkeys[iterator].operation[0] = lineSplitter[3];
                        monkeys[iterator].operation[1] = lineSplitter[4];
                        monkeys[iterator].operation[2] = lineSplitter[5];
                    }
                    if(lineSplitter[0]=="Test:"){
                        monkeys[iterator].testDiv = Int32.Parse(lineSplitter[3]);
                    }
                    if(lineSplitter[1]=="true:"){
                        monkeys[iterator].testSuccessTarget = Int32.Parse(lineSplitter[5]);
                    } 
                    if(lineSplitter[1]=="false:"){
                        monkeys[iterator].testFailTarget = Int32.Parse(lineSplitter[5]);
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
            while (line!=null){

                line = sr.ReadLine();
            }     

        }
    }