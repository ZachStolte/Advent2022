using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Day2
    {
        public static void Part1(StreamReader sr)
        {
            string line = "";
            char player;
            char opponent;
            int value = 0;
            line = sr.ReadLine();
            while (line!=null){
                opponent = line[0];
                player = line[2];

                if (player == 'X')//rock
                    value+=1;
                else if (player == 'Y')//paper
                    value+=2;
                else if (player == 'Z')//scissors
                    value+=3;

                if (opponent == 'A' & player == 'Y')
                    value+=6;
                else if (opponent == 'B' & player == 'Z')
                    value +=6;
                else if (opponent == 'C' & player == 'X')
                    value +=6;
                else if (opponent == 'A' & player == 'X')
                    value +=3;
                else if (opponent == 'B' & player == 'Y')
                    value +=3;
                else if (opponent == 'C' & player == 'Z')
                    value +=3;
                line = sr.ReadLine();
            }   
            Console.Write(value);    

        }

        public static void Part2(StreamReader sr)
        {
            string line = "";
            char result;
            char opponent;
            int value = 0;
            line = sr.ReadLine();
            while (line!=null){
                opponent = line[0];
                result = line[2];

                if (opponent == 'A' & result == 'X')
                    value+=3; //Scissors + Lose
                else if (opponent == 'A' & result == 'Y')
                    value +=4; //Rock + Draw
                else if (opponent == 'A' & result == 'Z')
                    value +=8; //Paper + Win
                else if (opponent == 'B' & result == 'X')
                    value +=1; //Rock + Lose
                else if (opponent == 'B' & result == 'Y')
                    value +=5; //Paper + Draw
                else if (opponent == 'B' & result == 'Z')
                    value +=9; //Scissors + Win
                else if (opponent == 'C' & result == 'X')
                    value +=2; //Paper + Lose
                else if (opponent == 'C' & result == 'Y')
                    value +=6; //Scissors + Draw
                else if (opponent == 'C' & result == 'Z')
                    value +=7; //Rock + Win
                line = sr.ReadLine();
            }   
            Console.Write(value);
    }
    }