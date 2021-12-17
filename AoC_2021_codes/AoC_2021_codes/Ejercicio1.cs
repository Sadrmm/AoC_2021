using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AoC_2021_codes
{
    class Ejercicio1
    {
        //Ejercicio Correcto
        public static int ParteA()
        {
            int[] input = Array.ConvertAll(File.ReadAllLines("../../../inputEjer1A.txt"), int.Parse);

            int numActual, numPrevio;
            int solucion = 0;
            for (int i = 1; i < input.Length; i++) {
                numActual = input[i];
                numPrevio = input[i - 1];

                if (numActual > numPrevio)
                    solucion++;
            }
            return solucion;
        }

        public static int ParteB()
        {
            int[] input = Array.ConvertAll(File.ReadAllLines("../../../inputEjer1B.txt"), int.Parse);

            int sumaActual, sumaPrevia;
            int solucion = 0;
            for (int i = 3; i < input.Length; i++) {
                sumaActual = input[i] + input[i-1] + input[i-2];
                sumaPrevia = input[i-1] + input[i-2] + input[i-3];

                if (sumaActual > sumaPrevia)
                    solucion++;
            }
            return solucion;
        }
    }
}
