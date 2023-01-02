using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Day1
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            int iterator = 0;
            ArrayList elves = new ArrayList();
            elves.Add(0);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line == "")
                {
                    iterator++;
                    elves.Add(0);

                }
                else
                {
                    elves[iterator] = (int)elves[iterator] + int.Parse(line);
                }
                Console.WriteLine(line);
                line = sr.ReadLine();
            }

            int highest = 0;
            for (int i = 0; i < elves.Count; i++)
            {
                if ((int)elves[i] > highest)
                    highest = (int)elves[i];
            }

            Console.WriteLine(highest);

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            int iterator = 0;
            ArrayList elves = new ArrayList();
            elves.Add(0);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line == "")
                {
                    iterator++;
                    elves.Add(0);

                }
                else
                {
                    elves[iterator] = (int)elves[iterator] + int.Parse(line);
                }
                Console.WriteLine(line);
                line = sr.ReadLine();
            }

            int highest = 0;
            int middle = 0;
            int lowest = 0;
            for (int i = 0; i < elves.Count; i++)
            {
                if ((int)elves[i] > highest)
                {
                    lowest = middle;
                    middle = highest;
                    highest = (int)elves[i];
                }
                else if ((int)elves[i] > middle)
                {
                    lowest = middle;
                    middle = (int)elves[i];
                }
                else if ((int)elves[i] > lowest)
                {
                    lowest = (int)elves[i];
                }
            }

            Console.WriteLine(highest + middle + lowest);
        }
    }
