    class Day3
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            string comp1 = "";
            string comp2 = "";
            char shared = '0';
            int totalvalue = 0;
            line = sr.ReadLine();
            while (line!=null){
                comp1 = line.Substring(0,line.Length/2);
                comp2 = line.Substring((int)line.Length/2, (int)(line.Length - line.Length/2));
                for (int i = 0; i < comp1.Length; i++){
                    for (int j = 0; j < comp2.Length; j++){
                        if(comp1[i] == comp2[j]){
                            if(comp1[i]!=shared){
                                if( (int) comp1[i] < 91){ //uppercase
                                    totalvalue+= (int) comp1[i]-38;
                                    shared = comp1[i];
                                }
                                else if ((int) comp1[i] > 96){ //lowercase
                                   totalvalue+= (int)comp1[i]-96;
                                   shared = comp1[i];
                                }
                            }
                        }
                    }
                }
                //Console.Write(totalvalue);
                //Console.Write("\n");
                shared = '0';
                line = sr.ReadLine();
            }     
            Console.Write(totalvalue);

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            int totalvalue = 0;
            int iter = 0;
            string comp1 = "";
            string comp2 = "";
            string comp3 = "";
            char shared = '0';
            line = sr.ReadLine();
            while (line!=null){
                if (iter == 0){
                    comp1 = line;
                    iter++;
                }
                else if (iter == 1){
                    comp2 = line;
                    iter++;
                }
                else if (iter == 2){
                    comp3 = line;
                    iter = 0;
                    for (int i = 0; i < comp1.Length; i++){
                        for (int j = 0; j < comp2.Length; j++){
                            for (int k = 0; k < comp3.Length; k++){
                                if (comp1[i] == comp2[j] && comp2[j] == comp3[k]){
                                    if (comp1[i]!=shared){
                                    if( (int) comp1[i] < 91){ //uppercase
                                        totalvalue+= (int) comp1[i]-38;
                                        shared = comp1[i];
                                    }
                                    else if ((int) comp1[i] > 96){ //lowercase
                                        totalvalue+= (int)comp1[i]-96;
                                        shared = comp1[i];
                                    }
                                    }
                                }
                            }
                        }
                    }
                //Console.Write(totalvalue);
                //Console.Write("\n");
                shared = '0';
                
                }
                line = sr.ReadLine();
            }
            Console.Write(totalvalue);     

        }
    }