  class Day16
    {

        public class Valve{
            public int flowRate;
            public List<string> connectors;
        }

        public static int getValvePressure(Dictionary<string, Valve> tunnels, List<string> onValves){
            
            int totalPressure = 0;
            for (int i = 0; i < onValves.Count; i++){
                totalPressure+=(tunnels[onValves[i]].flowRate);
            }
            return totalPressure;
        }

        public static int tunnelPressure(Dictionary<string, Valve> tunnels, List<string> onValves, Queue<(string, int)> queue){
            while (queue.Count > 0){
                string thisValve; 
                int currentPressure = 0;
                (string, int) temp = queue.Dequeue();
                int cycles = temp.Item2;
                string location = temp.Item1;
                if (cycles == 0){
                    return getValvePressure(tunnels, onValves);
                }

                //The first action of the pathfinding algorithm is always to try and turn on the valve, unless the flowrate is 0
                List<string> thisOnValves = new List<string>(); 

                int tempPressure = 0;

                if (!onValves.Contains(location)){
                    for (int i = 0; i < onValves.Count(); i++){
                        thisOnValves.Add(onValves[i]);
                    }
                    thisValve = location;
                    thisOnValves.Add(thisValve);
                    queue.Enqueue((location, cycles-1));
                }

                for(int i = 0; i < tunnels[location].connectors.Count(); i++){
                    string movement = tunnels[location].connectors[i];
                    queue.Enqueue((location, cycles-1));
                }

                tempPressure = getValvePressure(tunnels, thisOnValves) + tunnelPressure(tunnels, thisOnValves, queue);
                    if (tempPressure > currentPressure) currentPressure = tempPressure;
            }

            return 0; 
        }
        public static void Part1(StreamReader sr)
        {
            string line = "";
            Dictionary<string, Valve> tunnels = new Dictionary<string, Valve>();
            line = sr.ReadLine();
            while (line!=null){
                string[] input = line.Split(" ");
                string valveName = input[1];
                tunnels.Add(valveName, new Valve());
                
                int flowRate = int.Parse(input[4].Split("=")[1].Split(";")[0]);
                tunnels[valveName].flowRate = flowRate;
                tunnels[valveName].connectors = new List<string>();

                for (int i = 9; i < input.Count(); i++){
                    tunnels[valveName].connectors.Add(input[i].Split(",")[0]);
                }
                line = sr.ReadLine();
            }     
            List<String> onValves = new List<String>();
            Queue<(string, int)> queue = new Queue<(string, int)>();
            queue.Enqueue(("AA", 30));
            Console.Write(tunnelPressure(tunnels, onValves, queue));

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