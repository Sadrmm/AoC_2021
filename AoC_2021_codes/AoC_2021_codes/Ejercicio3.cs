using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AoC_2021_codes
{
    class Ejercicio3
    {
        public static int ParteA()
        {
            string[] input = File.ReadAllLines("../../../inputEjer3A.txt");

            string gamma = "";
            string epsilon = "";

            int gammaNumber, epsilonNumber;

            for (int j = 0; j < input[0].Length; j++) {     //recorrer posiciones
                int cont1 = 0;
                int cont0 = 0;

                for (int i = 0; i < input.Length; i++) {    //recorrer cada uno
                    if (input[i][j] == '1')
                        cont1++;
                    else if (input[i][j] == '0')
                        cont0++;
                    else
                        Console.WriteLine("HAY ALGO MAL");
                }
                
                if (cont1 > cont0) {
                    gamma += '1';
                    epsilon += '0';
                }
                else {
                    gamma += '0';
                    epsilon += '1';
                }
            }

            gammaNumber = Convert.ToInt32(gamma, 2);
            epsilonNumber = Convert.ToInt32(epsilon, 2);

            return gammaNumber * epsilonNumber;
        }

        public static int ParteB()
        {
            string[] input = File.ReadAllLines("../../../inputEjer3B.txt");

            List<string> actualNumbersO2 = new List<string>(input);    //lista que modificaremos dinamicamente para el O2
            List<string> actualNumbersCO2 = new List<string>(input);    //lista que modificaremos dinamicamente para el CO2

            int o2Number = 0;
            int co2Number = 0;
            //parte O2
            for (int j = 0; j < actualNumbersO2[0].Length; j++) { //recorrer posiciones
                int cont1 = 0;
                int cont0 = 0;

                for (int i = 0; i < actualNumbersO2.Count; i++) {
                    if (actualNumbersO2[i][j] == '1')
                        cont1++;
                    else if (actualNumbersO2[i][j] == '0')
                        cont0++;
                    else
                        Console.WriteLine("HAY ALGO MAL");
                }

                if (cont1 >= cont0) {
                    DeleteStartWith('0', j, actualNumbersO2);
                }
                else {
                    DeleteStartWith('1', j, actualNumbersO2);
                }

                if (actualNumbersO2.Count == 1) {
                    o2Number = Convert.ToInt32(actualNumbersO2[0], 2);
                    break;
                }
            }
            //parte CO2
            for (int j = 0; j < actualNumbersCO2[0].Length; j++) { //recorrer posiciones
                int cont1 = 0;
                int cont0 = 0;

                for (int i = 0; i < actualNumbersCO2.Count; i++) {
                    if (actualNumbersCO2[i][j] == '1')
                        cont1++;
                    else if (actualNumbersCO2[i][j] == '0')
                        cont0++;
                    else
                        Console.WriteLine("HAY ALGO MAL");
                }

                if (cont1 < cont0) {
                    DeleteStartWith('0', j, actualNumbersCO2);
                }
                else {
                    DeleteStartWith('1', j, actualNumbersCO2);
                }

                if (actualNumbersCO2.Count == 1) {
                    co2Number = Convert.ToInt32(actualNumbersCO2[0], 2);
                    break;
                }
            }
            Console.WriteLine(o2Number + " " + co2Number);
            return o2Number * co2Number;
        }

        private static void DeleteStartWith(char charToCompare, int position, List<string> list)
        {
            for (int i = 0; i < list.Count; i++) {
                if (list[i][position] == charToCompare) {
                    list.RemoveAt(i);
                    i--;    //porque al borrar nos pondriamos en el siguiente y asi no lo saltamos
                }
            }
        }
    }
}
