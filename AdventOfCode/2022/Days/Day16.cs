
  class Day16
    {

        public class Valve{
            public int flowRate;
            public List<Valve> connectors;
            public bool open;
            public string name;

            public Valve (string name){
                this.name = name;
                this.flowRate = 0;
                this.connectors = new List<Valve>();
                this.open = false;
            }
        }

        public class mathJockey{
            public Dictionary<(string[], Valve, int), int> topScore;
            Dictionary<(string, string), int> distances;

            public mathJockey(){
                topScore = new Dictionary<(string[], Valve, int), int>();
                distances = new Dictionary<(string, string), int>();
            }

            public int getDistance(string valve1, string valve2, Dictionary<string, Valve> valves){
                if (distances.ContainsKey((valve1, valve2))){
                    return distances[(valve1, valve2)];
                }

                return doTheMath(valve1, valve2, valves);
            }

            public int doTheMath(string valve1, string valve2, Dictionary<string, Valve> valves){
                if (valve1 == valve2){
                    return 0;
                }

                Queue<Valve> queue = new Queue<Valve>();
                Dictionary<Valve, int> distanceSet = new Dictionary<Valve, int>();
                queue.Enqueue(valves[valve1]);
                distanceSet.Add(valves[valve1], 0);

                    while(queue.Count > 0){
                        Valve current = queue.Dequeue();
                        int distance = distanceSet[current];

                        if(current == valves[valve2]){
                            distances.Add((valve1, valve2), distance);
                            distances.Add((valve2, valve1), distance);
                            return distance;
                        }

                        foreach(Valve valve in current.connectors){
                            if (!distanceSet.ContainsKey(valve)){
                                queue.Enqueue(valve);
                                distanceSet.Add(valve, distanceSet[current]+1);
                            }
                        }
                    }

                return -1;
            }
        }

        public static void Part1(StreamReader sr)
        {
            string line = "";
            Dictionary<string, Valve> valves = new Dictionary<string, Valve>();
            line = sr.ReadLine();
            while (line!=null){
                (Valve, int, List<String>) parsed = readInput(line);
                if (!valves.ContainsKey(parsed.Item1.name)){
                    valves.Add(parsed.Item1.name, parsed.Item1);
                } else {
                    valves[parsed.Item1.name].flowRate = parsed.Item2;
                    valves[parsed.Item1.name].connectors = parsed.Item1.connectors;
                }

                foreach(string name in parsed.Item3){
                    if (!valves.ContainsKey(name)){
                        Valve valve = new Valve(name);
                        valves.Add(name, valve);
                        parsed.Item1.connectors.Add(valve);
                    }
                    else{
                        parsed.Item1.connectors.Add(valves[name]);
                    }
                }
                //valves[parsed.Item1.name].flowRate = parsed.Item2;
                line = sr.ReadLine();
            }

            Dictionary<string, Valve> realValves = new Dictionary<string, Valve>();
            foreach(Valve valve in valves.Values){
                if (valve.flowRate>0 || valve.name == "AA") realValves.Add(valve.name, valve);
            }

            int shortestPath = findShortestPath(realValves, new mathJockey(), new List<String>(), 30, valves["AA"]);     

            Console.Write(shortestPath);

        }

        public static int findShortestPath(Dictionary<string, Valve> valves, mathJockey glasses, List<string> openValves, int minutes, Valve current){
            string[] valveStorage = openValves.ToArray();
            List<string> localValves = new List<string>();
            foreach(string i in openValves) localValves.Add(i);
            if (glasses.topScore.ContainsKey((valveStorage, current, minutes))) return glasses.topScore[(valveStorage, current, minutes)];

            int score = 0;
            if (current.flowRate > 0 && !current.open && minutes > 0){
                minutes--;
                current.open = true;
                score = minutes * current.flowRate;
                localValves.Add(current.name);
            }
            else if (minutes <= 0){
                return score;
            }

            PriorityQueue<Valve, double> prioQueue = new PriorityQueue<Valve, double>();

            foreach(Valve valve in valves.Values){
                if (!(current == valve || valve.flowRate == 0 || valve.open)){
                    int distance = glasses.getDistance(current.name, valve.name, valves);
                    double mathedDistance = valve.flowRate / distance;

                    prioQueue.Enqueue(valve, mathedDistance);
                }
            }

            Queue<Valve> queue = new Queue<Valve>();
                while (prioQueue.Count > 0){
                    queue.Enqueue(prioQueue.Dequeue());
                }
                queue.Reverse();

            int topScore = 0;
            while(queue.Count > 0){
                Valve valve = queue.Dequeue();
                int distance = glasses.getDistance(valve.name, current.name, valves);
                if (! (distance > minutes)){
                    minutes -= distance;
                    topScore = Math.Max(findShortestPath(valves, glasses, localValves, minutes, valve), topScore);
                    minutes += distance;
                }
            }

            score += topScore;
            glasses.topScore.Add((valveStorage, current, minutes), topScore);
            current.open = false;

            return score;
        }

        public static (Valve, int, List<String>) readInput(string line){
            string name = line.Substring(6, 2);
            int flow = int.Parse(line.Substring(line.IndexOf('=')+1).Split(";")[0]);

            string list = line.Split(';')[1];
            list = list.Substring(list.IndexOf("valve"));

            Valve valve = new Valve(name);
            valve.flowRate = flow;
            
            List<string> connections = new List<string>();
            foreach(string item in list.Split(" ")){
                string newItem = item;
                if (item[0] == 'v'){
                    continue;
                }

                newItem.Trim();
                newItem = newItem.Split(",")[0];
                connections.Add(newItem);
            }

            return(valve, flow, connections);
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