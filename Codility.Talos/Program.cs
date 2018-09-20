using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Talos
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            //int[] A = { -8, 4, 0, 5, -3, 6 };
            int[] A = { 5, -2, 3, 8, 6 };
            //int[] A = { -5, -5, -5, -42, 6, 12 };

            //[ 2, 1, 4, 1, 9, 9 ]
            //[ 2, 1, 1, 1, 9, -4, -3, 1, -6, 10, 8, 16, 9 ]
            //[ −100000000, -1000000000, 2, 1000000000 ]

            //[ 6, -2, 1, 1, -1, 9, -4, -3, 1, -6, 10, 8, -12, 4, 4, 1, -8, 9, 9, 16, 9 ]
        result = solution(A);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int solution(int[] A)
        {
            int sum = 0;
            int winter = 0;
            for (int measure = 0; measure < A.Length; measure++)
            {
                sum += A[measure];
                if (A[measure + 1] > sum && A[measure + 1] > 0)
                {
                    //winter = A.Take(measure + 1).ToArray();
                    winter = measure + 1;

                    break;
                }
            }
            return winter;
        }
    }
}
