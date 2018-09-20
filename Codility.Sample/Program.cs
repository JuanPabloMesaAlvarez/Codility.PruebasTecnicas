using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            //int[] A = { 1, 3, -3 };
            //int[] A = { -8, 4, 0, 5, -3, 6 };
            int min = 0;
            int max = 99;
            int[] A = new int[max];
            Random randNum = new Random();
            for (int i = min; i < max; i++)
            {
                var n = randNum.Next(1, 100);
                while (A.Contains(n))
                {
                    n = randNum.Next(min, max);
                }
                A[i] = n;
            }
            result = solution(A);

            //int[] A = { -1000000000 };
            //var result = solution2(A);

            //int N = 112;
            //var result = solution3(N);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int solution(int[] A)
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

        public static int solution3(int N)
        {
            
            var result = 0;
            result = evaluate(N);
            //for (int index = 1; index < N +1; index++)
            //{
            //    result += (index - 1) + index;
            //    if(result > N)
            //    {
            //        result = index;
            //        break;
            //    }
            //}
            return result;
        }

        public static int evaluate(int N)
        {
            var result = 0;
            if (N == 0)
            {
                return 0;
            }

            for (int index = 0; index < N; index++)
            {
                result += evaluate(index) + index;
                if (result > N)
                {
                    result = index;
                    break;
                }
            }
            return result;
        }
    }
}
