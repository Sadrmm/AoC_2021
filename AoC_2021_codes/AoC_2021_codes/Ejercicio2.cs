using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AoC_2021_codes
{
    class Ejercicio2
    {
        public static int ParteA()
        {
            int horizontal = 0;
            int depth = 0;
            
            string[] input = File.ReadAllText("../../../inputEjer2A.txt").Replace("\n", " ").Split(' ');
            
            for (int i = 0; i < input.Length-1; i += 2) {   //input.Length - 1 para ignorar el ultimo espacio
                switch (input[i]) {
                    case "forward":
                        horizontal += Convert.ToInt32(input[i+1]);
                        break;
                    case "down":
                        depth += Convert.ToInt32(input[i+1]);
                        break;
                    case "up":
                        depth -= Convert.ToInt32(input[i+1]);
                        break;
                    default:
                        Console.WriteLine("ALGO HA IDO MAL");
                        break;
                }
            }
            return horizontal * depth;
        }

        public static int ParteB()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            string[] input = File.ReadAllText("../../../inputEjer2B.txt").Replace("\n", " ").Split(' ');

            for (int i = 0; i < input.Length - 1; i += 2) {
                switch (input[i]) {
                    case "forward":
                        int x = Convert.ToInt32(input[i+1]);
                        horizontal += x;
                        depth += aim * x;
                        break;
                    case "down":
                        aim += Convert.ToInt32(input[i+1]);
                        break;
                    case "up":
                        aim -= Convert.ToInt32(input[i+1]);
                        break;
                    default:
                        Console.WriteLine("ALGO HA IDO MAL");
                        break;
                }
            }
            return depth * horizontal;
        }
    }
}
