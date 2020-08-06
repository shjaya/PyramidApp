using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    class Program
    {
       //Globally declared
       public static List<int> list = new List<int>();
        /// <summary>
        /// Function to return the maximum sum of the pyramid
        /// </summary>
        /// <param name="tri"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int maxSum(int[,] tri, int n)
        {
            //Declaration of Required variables 
            string flag = "odd";
            int lvpos = 0;
            int lvloc = 0;
            int lvnewval = 0;
            int lvpostmp = 0;
            int lvvar = tri[0,0];
            list.Add(lvvar);

            //Checking the first node whether it is even or odd 
            //And accordingly which type of next node should be setting in flag
            if (OddEvenCheck((tri[0, 0])) == "odd")
                flag = "even";
            else
                flag = "odd";

            for (int i = 1; i < n; i++)
            {
                for (int j = lvpos; j <= lvpos+1; j++)
                {
                    if (OddEvenCheck(tri[i, j]) == flag)
                    {
                        if (tri[i, j] + tri[i - 1, lvpos] > lvloc)
                        {
                            lvloc = tri[i, j] + tri[i - 1, lvpos];
                            lvnewval = tri[i, j];
                            lvpostmp = j;
                        }
                    }
                }

                lvpos = lvpostmp;
                lvvar = lvvar + lvnewval;
                list.Add(lvnewval);
                lvnewval = 0;
                lvloc = 0;
                lvpostmp = 0;
                if (flag == "odd")
                    flag = "even";
                else
                    flag = "odd";
            }
            return lvvar;

        }

        /// <summary>
        /// Takes the number as input and verify whether it is odd or even
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string OddEvenCheck(int number)
        {
            string flag = "";
            if (number % 2 == 0)
                flag = "even";
            else
                flag = "odd";
            return flag;
        }

        // Main 
        public static void Main(string[] args)
        {
            //Pyramid starting with odd number
            int[,] tri1 = 
            {
                {1,0,0,0},
                {8,9,0,0},
                {1,5,9,0},
                {4,5,2,3 } 
            };
            //Pyramid starting with odd number
            int[,] tri2 = 
            {
                {1,0,0,0,0},
                {4,6,0,0,0},
                {6,7,8,0,0},
                {9,8,1,4,0},
                {7,1,3,4,9}
            };

            //Pyramid starting with even number
            int[,] tri3 =
            {
                {2,0,0,0,0},
                {7,9,0,0,0},
                {6,7,8,0,0},
                {3,8,1,4,0},
                {7,1,3,4,9}
            };

            //Pyramid in the document
            int[,] tri =
            {
                {215, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {192, 124, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {117, 269, 442, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {218, 836, 347, 235, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {320, 805, 522, 417, 345, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {229, 601, 728, 835, 133, 124, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {248, 202, 277, 433, 207, 263, 257, 0, 0, 0, 0, 0, 0, 0, 0},
                {359, 464, 504, 528, 516, 716, 871, 182, 0, 0, 0, 0, 0, 0, 0},
                {461, 441, 426, 656, 863, 560, 380, 171, 923, 0, 0, 0, 0, 0, 0},
                {381, 348, 573, 533, 448, 632, 387, 176, 975, 449, 0, 0, 0, 0, 0},
                {223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444, 0, 0, 0, 0},
                {330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197, 0, 0, 0},
                {131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928, 0, 0},
                {223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121, 0},
                {924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230, 124, 233},
            };

            Console.WriteLine("Max sum: "+ maxSum(tri3, 5));            

            StringBuilder builder = new StringBuilder();
            string delimiter = "";
            foreach (var item in list)
            {
                builder.Append(delimiter);
                builder.Append(item);
                delimiter = ", ";
            }
            Console.WriteLine("Path: "+ builder.ToString());
            Console.ReadKey();
        }
    }
}




