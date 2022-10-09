using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC_2021_codes
{
    class Ejercicio4
    {
        public static int ParteA()
        {
            string[] input = File.ReadAllLines("../../../inputEjer4A.txt");

            int[] numbers = Array.ConvertAll(input[0].Split(","), int.Parse);   //obtener los numeros
            int actualNumber = -1;
            int indexNext = 0;

            List<List<List<int>>> boards = new List<List<List<int>>>();
            bool[,,] numbersMarked;
            List<List<int>> numbersMarkedPerBoard;
            bool boardWinner = false;
            int boardWinnerPos = -1;

            //obtener los cartones y marcar sus numeros como NO usados
            for (int i = 2; i < input.Length; i += 5+1) {

                List<List<int>> newBoard = new List<List<int>>();
                int[] rowBoard = new int[5];  //the boards are 5x5
                for (int row = i; row < i + 5; row++) {

                    List<string> auxString = input[row].Split(' ').ToList<string>();
                    //mirar si hay alguno vacío
                    for (int posAux = 0; posAux < auxString.Count; posAux++) {
                        if (auxString[posAux] == String.Empty) {
                            //borrar de la lista
                            auxString.RemoveAt(posAux);
                            posAux--;
                        }
                    }

                    //save the row of the board
                    rowBoard = auxString.Select(int.Parse).ToArray<int>();
                    newBoard.Add(rowBoard.ToList<int>());
                }

                //save the board
                boards.Add(newBoard);
            }
            
            numbersMarked = new bool[boards.Count, boards[0].Count, boards[0][0].Count];
            numbersMarkedPerBoard = new List<List<int>>();
            for (int i = 0; i < boards.Count; i++) {    //fill it with -1 so it has i positions
                numbersMarkedPerBoard.Add(new List<int> { -1 });
            }

            //GAME LOOP
            while (!boardWinner && indexNext < numbers.Length) {
                //pic number
                actualNumber = numbers[indexNext];
                indexNext++;

                //mark boards´ numbers as checked
                foreach (List<int> nMarked in numbersMarkedPerBoard) {  //check if the number has been used in that board
                    if (nMarked.Contains(actualNumber)) {
                        continue;
                    }
                }

                for (int i = 0; i < boards.Count && !boardWinner; i++) {    //check if each board has the number
                    for (int j = 0; j < boards[0].Count && !boardWinner; j++) {
                        if (boards[i][j].Contains(actualNumber)) {
                            int indexOfActualNumber = boards[i][j].IndexOf(actualNumber);
                            //mark board´s numbers as checked
                            numbersMarked[i, j, indexOfActualNumber] = true;
                            numbersMarkedPerBoard[i].Add(actualNumber);

                            bool madeRow = true;
                            bool madeColumn = true;
                            //check if row
                            for (int k = 0; k < 5; k++) {
                                if (!numbersMarked[i, j, k]) {
                                    madeRow = false;
                                    break;
                                }
                            }

                            //check if column
                            for (int k = 0; k < 5; k++) {
                                if (!numbersMarked[i, k, indexOfActualNumber]) {
                                    madeColumn = false;
                                    break;
                                }
                            }

                            if (madeRow || madeColumn) {
                                boardWinner = true;
                                boardWinnerPos = i;
                            }
                        }
                    }
                }
            }

            //Calculate sum of all unmarked
            int finalSum = 0;
            for (int i = 0; i < boards[0].Count; i++) {
                for (int j = 0; j < boards[0][0].Count; j++) { 
                    if (numbersMarked[boardWinnerPos, i, j]) {
                        continue;
                    }

                    finalSum += boards[boardWinnerPos][i][j];
                }
            }

            finalSum *= actualNumber;

            return finalSum;
        }

        public static int ParteB()
        {
            return -1;
        }
    }
}
