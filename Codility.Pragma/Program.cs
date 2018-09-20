using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Pragma
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = { 2, 3, 4, 1, 5 };
            //int[] A = { 1, 3, 4, 2, 5 };
            //solution1(A);

            //int[] A = { 1, 3, -3 };
            int[] A = { -8, 4, 0, 5, -3, 6 };
            var result = solution2(A);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int solution1(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = 0;
            int[] turnOn = new int[A.Length];

            for (int time = 0; time < A.Length; time++)
            {
                turnOn[time] = A[time];
                for (int currentBulb = turnOn[time]; currentBulb > 0; currentBulb--)
                {
                    int find = Math.Max(currentBulb - 1, 1);
                    if (!turnOn.Contains(find))
                    {
                        break;
                    }
                    if (currentBulb == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;
            for (int p = 0; p < A.Length; p++)
            {
                result = Math.Max(A[p] + A[p] + (p - p), result);
                for (int q = A.Length - 1; q > p; q--)
                {
                    result = Math.Max(A[p] + A[q] + (q - p), result);
                }
            }
            return result;
        }

    }
}
