using System;
  
  class Day13
    {
        public class Packet{
            public string type = "int";
            public int depth = 0;
            public int num = 0;
            public List<Packet> children = new List<Packet>();
            public Packet parent;

        }

        public static int populatePacket(Packet packet, string line){
            for (int i = 1; i < line.Count(); i++){
                if (Char.IsDigit(line[i])){
                    if (Char.IsDigit(line[i+1])){
                        Packet digit = new Packet();
                        digit.depth = packet.depth+1;
                        digit.parent = packet;
                        string num = line[i].ToString();
                        num+=line[i+1].ToString();
                        digit.num = Int32.Parse(num);
                        packet.children.Add(digit);                       
                    }
                    else{
                        Packet digit = new Packet();
                        digit.depth = packet.depth+1;
                        digit.parent = packet;
                        string num = line[i].ToString();
                        digit.num = Int32.Parse(num);
                        packet.children.Add(digit); 
                    }
                }
                if (line[i] == '['){
                    string tempLine = line.Substring(i);
                    Packet list = new Packet();
                    list.type = "list";
                    list.depth = packet.depth+1;
                    list.parent = packet;
                    i += populatePacket(list, tempLine)+1;
                    packet.children.Add(list);
                }
                if (line[i] == ']'){
                    return i;
                }
            }
            return 0;
        }

        public static int comparePackets(Packet pack1, Packet pack2){ //2 = Correct, 1 = Incorrect, 0 = Inconclusive
            int smallestSize = pack1.children.Count;
            int leftSmaller = 0;
            if (pack1.children.Count < pack2.children.Count){
                leftSmaller = 2;
            }
            else if (pack1.children.Count > pack2.children.Count){
                smallestSize = pack2.children.Count;
                leftSmaller = 1;
            }

            for (int i = 0; i < smallestSize; i++){
                    if (pack1.children[i].type == "int" && pack2.children[i].type == "int"){
                        if (pack1.children[i].num < pack2.children[i].num){
                            return 2; //Correct
                        }
                        else if (pack1.children[i].num > pack2.children[i].num){
                            return 1; //False
                        }
                    }
                    if (pack1.children[i].type == "list" && pack2.children[i].type == "list"){
                        int listResult = comparePackets(pack1.children[i], pack2.children[i]);
                        if (listResult != 0){
                            return listResult;
                        }
                    }
                    if (pack1.children[i].type == "int" && pack2.children[i].type == "list"){
                        Packet tempPack = new Packet();
                        tempPack.type = "list";
                        tempPack.children.Add(pack1.children[i]);
                        int listresult = comparePackets(tempPack, pack2.children[i]);
                        if (listresult != 0){
                            return listresult;
                        }
                    }
                    if (pack2.children[i].type == "int" && pack1.children[i].type == "list"){
                        Packet tempPack = new Packet();
                        tempPack.type = "list";
                        tempPack.children.Add(pack2.children[i]);
                        int listresult = comparePackets(pack1.children[i], tempPack);
                        if (listresult != 0){
                            return listresult;
                        }
                    }
            }
            return leftSmaller;
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            Packet packet1;
            Packet packet2;
            List<string> list1 = new List<string>();
            int iterator = 1;
            int finalSum = 0;
            line = sr.ReadLine();
            while (line!=null){
                packet1 = new Packet();
                packet1.type = "list";
                populatePacket(packet1, line);
                line = sr.ReadLine();
                packet2 = new Packet();
                packet2.type = "list";
                populatePacket(packet2, line);

                if (comparePackets(packet1, packet2) == 2){
                    finalSum += iterator;
                }

                iterator++;
                line = sr.ReadLine();
                line = sr.ReadLine();
            }  

            Console.Write(finalSum);  

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