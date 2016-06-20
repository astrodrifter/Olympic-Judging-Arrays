using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicJudgingArrays {
    /*
        Olympic Event Competitor Scoring

        Given any number of competitors greater than 1 and any
        number of scores greater than 2 calculate and output
        the winning competitor(s) and the highest scoring judge(s)

        Author:
        Date: April 2016
     */
    class Program {

        static void Main(string[] args) {

            /*
            int[,] results ={
                              { 4, 7, 9, 3, 8, 6},
                              { 4, 8, 6, 4, 8, 5}

                             };
                             */

            // TESTING MORE COMPETITORS AND LESS JUDGES

            int[,] results ={
                               { 1, 3, 2, 4, 9},
                               { 8, 1, 7, 4, 3},
                               { 5, 7, 9, 1, 4}

                              };

            //TESTING MUTLIPLE WINNERS AND MULTIPLE HIGHEST JUDGES
            /*
            int[,] results ={
                              { 1, 1, 1, 1, 1, 1},
                              { 1, 1, 1, 1, 1, 1},
                              { 1, 1, 1, 1, 1, 1}

                             };
                             */

            int rows = results.GetLength(0); //Assign the number of rows in the array to the rows variable
            int columns = results.GetLength(1); //Assign the number of columns in the array to the columns variable

            int[] Competitors = new int[rows];
            int[] Scores = new int[columns];

            int row_total = 0;
            int max_competitor = int.MinValue; // outrageously low number to ensure that at least 1 competitor will win
            int max_judge = int.MinValue;

            //Start a loop and increment the row
            for (int pos_row = 0; pos_row < rows; pos_row++) {
                row_total = 0; //Reset the row total as you move to the next row

                Write_Competitor(pos_row);

                int row_min = MinRow(results, pos_row);
                int row_max = MaxRow(results, pos_row);
                Competitors[pos_row] = TotalRow(results, pos_row, row_max, row_min);
                row_total = Competitors[pos_row];

                //start a loop and increment the column
                for (int pos_col = 0; pos_col < columns; pos_col++) {
                    Competitors_Scores(results, pos_row, pos_col);
                }
                Write_Row_Total(row_total);

            }
            for (int pos_col = 0; pos_col < columns; pos_col++) {
                Scores[pos_col] = TotalCol(results, pos_col);
            }


            max_competitor = Max_Single_Row(Competitors);
            max_judge = Max_Single_Row(Scores);

            Write_Highest_Competitor(Competitors, max_competitor);
            Write_Highest_Judge(Scores, max_judge);

            Exit_Program();
        }//end Main

        /// <summary>
        /// Given an array and a row, find the largest number in the row
        /// </summary>
        /// <param name="thisArray">The given array being searched through</param>
        /// <param name="row"> The given row being searched through</param>
        /// <returns>Returns "max"; the largest number in the specified row of the array</returns>
        static int MaxRow(int[,] thisArray, int row) {
            int max = int.MinValue; //outrageously low number to ensure that the max value is changed in the function
            int position = 0; //starting position in the array
            int max_position = 0; //the position of the largest number found


            while (position < thisArray.GetLength(1)) {
                if (thisArray[row, position] > max) {
                    max = thisArray[row, position];
                    max_position = position;
                }
                position++;
            }

            //return the largest value in the row
            return max;
        }// end MaxRow


        /// <summary>
        /// Given an array and a row, find the smallest number in the row
        /// </summary>
        /// <param name="thisArray">The given array being searched through  </param>
        /// <param name="row"> The given row of the array being searched through</param>
        /// <returns>Returns "Min"; the smallest number in the specified row of the array </returns>
        static int MinRow(int[,] thisArray, int row) {
            int min = int.MaxValue; //outrageously High number to ensure that the min value is changed in the function
            int position = 0; //starting position in the array
            int min_position = 0; //the position of the smallest number found


            while (position < thisArray.GetLength(1)) {
                if (thisArray[row, position] < min) {
                    min = thisArray[row, position];
                    min_position = position;
                }
                position++;
            }

            //return the smallest value in the row
            return min;
        }// end MinRow

        /// <summary>
        /// Calculates the total of the integers in a given row of a 2 dimensional array
        /// subtracting the maximum and minimum of the array
        /// </summary>
        /// <param name="thisArray"> The array in question</param>
        /// <param name="pos_row"> The row of the array being added up</param>
        /// <param name="row_max"> The maximum value in the row </param>
        /// <param name="row_min"> The minimum value in the row</param>
        /// <returns>Returns to row total minus the row maximum and minimum</returns>
        static int TotalRow(int[,] thisArray, int pos_row, int row_max, int row_min) {
            int row_total = 0;

            for (int position = 0; position < thisArray.GetLength(1); position++) {
                row_total = row_total + thisArray[pos_row, position];// add each value to the total in the row
            }

            row_total = row_total - (row_max + row_min);// subtract the maximum and the minimum as per the specifications

            return row_total;
        }//End TotalRow


        /// <summary>
        /// Searches through a 1 dimensional array to find the largest value in the array
        /// </summary>
        /// <param name="thisArray"> The array that is being searched through</param>
        /// <returns> Returns the maximum value from the given array</returns>
        static int Max_Single_Row(int[] thisArray) {
            int max = int.MinValue; //outrageously low number to ensure that the max value is changed in the function
            int position = 0; //starting position in the array
            int max_position = 0; //the position of the largest number found


            while (position < thisArray.Length) {
                // if the number at 'position' is greater than the current max value, change the max value to that number
                if (thisArray[position] > max) {
                    max = thisArray[position];
                    max_position = position;
                }
                position++;
            }

            //return the largest value in the row
            return max;
        }// end Max_Single_Row

        /// <summary>
        /// Finds the total for each column in the given array
        /// </summary>
        /// <param name="Array"> The 2 dimensional array in question</param>
        /// <param name="pos_col"> The current column that is being added up</param>
        /// <returns> Returns the total of the integers in the specified column</returns>
        static int TotalCol(int[,] Array, int pos_col) {
            int col_total = 0;

            for (int position = 0; position < Array.GetLength(0); position++) {
                col_total = col_total + Array[position, pos_col];// add each value to the total from the column
            }
            return col_total;
        }//End TotalCol

        static void Write_Row_Total(int row_total) {
            Console.WriteLine("and your total score was {0} ", row_total);
        }//End Write_Row_Total

        static void Competitors_Scores(int[,] Array, int pos_row, int pos_col) {
            Console.Write("{0} ", Array[pos_row, pos_col]);
        }//End Competitors_Scores

        static void Write_Competitor(int pos_row) {
            Console.Write("Competitor {0} your scores are: ", pos_row + 1);
        }//End Write_Competitor

        /// <summary>
        /// Print out the numbers of the judges who have a score equal to the highest judge score
        /// </summary>
        /// <param name="Scores">The Array of judges total scores</param>
        /// <param name="max_judge"> The highest a judge scored</param>
        static void Write_Highest_Judge(int[] Scores, int max_judge) {
            Console.Write("and the judge(s) with the highest scoring are");
            for (int position_2 = 0; position_2 < Scores.Length; position_2++) {
                if (Scores[position_2] == max_judge) {
                    Console.Write(" {0}", position_2 + 1);
                }
            }
            Console.WriteLine(" with a total scoring of {0}", max_judge);
        }// End Write_Highest_Judge

        /// <summary>
        /// Print out the numbers of the competitors who have a score equal to the highest competitors score
        /// </summary>
        /// <param name="Competitors">The Array of competitors total scores</param>
        /// <param name="max_competitor"> The highest a competitor scored</param>
        static void Write_Highest_Competitor(int[] Competitors, int max_competitor) {
            Console.Write("and the winner(s) are competitor(s)");
            for (int position = 0; position < Competitors.Length; position++) {
                if (Competitors[position] == max_competitor) {
                    Console.Write(" {0},", position + 1);
                }
            }
            Console.WriteLine(" with a total score of {0}", max_competitor);
        }// End Write_Highest_Competitor

        static void Exit_Program() {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
        }// End Exit_Program

    }//end class
}//end namespace
