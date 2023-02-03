using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
namespace HW_3_5_Chernysh
{


    internal class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<string, int> dic = new ConcurrentDictionary<string, int>();

            Thread threadFactorial = new Thread(() =>
            {
                dic.TryAdd("Factorial:", Factorial(5));
            });
            Thread threadFibonachi = new Thread(() =>
            {
                dic.TryAdd("Fibonacci:", Fibonacci(5));
            });

            threadFactorial.Start();
            threadFactorial.Join();

            threadFibonachi.Start();
            threadFibonachi.Join();


            foreach(var a in dic)
            {
                Console.WriteLine(a.Key + " " + a.Value);
            }
        }
        public static int Fibonacci(int n)
        {
            int sum = 0;
            if (n == 1 || n == 2) return n;
            else sum += Fibonacci(n - 1) + Fibonacci(n - 2);
            return sum + 1;
        }

        public static int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
    }

}