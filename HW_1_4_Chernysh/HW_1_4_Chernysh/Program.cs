using System;
using System.Buffers;
using System.Reflection.Emit;
using System.Text;

namespace HW_1_4_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> list = new List<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
            {
                list.Add(c);
            }

            char[] alphabet = list.ToArray();

            Console.WriteLine("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            Random random = new Random();

            int evenNums = 0;
            int oddNums = 0;

            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(1, 26);

                if (arr[i] % 2 == 0)
                {
                    evenNums++;
                }
                else
                {
                    oddNums++;
                }
            }

            object[] evenNumsArray = new object[evenNums];
            object[] oddNumsArray = new object[oddNums];

            int indexEven = 0;
            int indexOdd = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenNumsArray[indexEven] = arr[i];
                    indexEven++;
                }
                else
                {
                    oddNumsArray[indexOdd] = arr[i];
                    indexOdd++;
                }
            }

            int counterEven = 0;
            int counterOdd = 0;

            Console.WriteLine("Вывод чётного массива: ");

            for (int i = 0; i < indexEven; i++)
            {
                evenNumsArray[i] = alphabet[(int)evenNumsArray[i]];

                if ((char)evenNumsArray[i] == 'A' || (char)evenNumsArray[i] == 'E' ||
                    (char)evenNumsArray[i] == 'I' || (char)evenNumsArray[i] == 'D' ||
                    (char)evenNumsArray[i] == 'H' || (char)evenNumsArray[i] == 'J')
                {
                    counterEven++;
                }
                else
                {
                    evenNumsArray[i] = evenNumsArray[i].ToString().ToLower();
                }

                Console.Write(evenNumsArray[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Вывод нечётного массива: ");

            for (int i = 0; i < indexOdd; i++)
            {
                oddNumsArray[i] = alphabet[(int)oddNumsArray[i]];

                if ((char)oddNumsArray[i] == 'A' || (char)oddNumsArray[i] == 'E' ||
                   (char)oddNumsArray[i] == 'I' || (char)oddNumsArray[i] == 'D' ||
                   (char)oddNumsArray[i] == 'H' || (char)oddNumsArray[i] == 'J')
                {
                    counterOdd++;
                }
                else
                {
                    oddNumsArray[i] = oddNumsArray[i].ToString().ToLower();
                }

                Console.Write(oddNumsArray[i] + " ");
            }

            Console.WriteLine();

            if (counterEven > counterOdd)
            {
                Console.WriteLine("В чётном массиве больше букв в верхнем регистре, а именно: " + counterEven);
            }
            else if (counterEven == counterOdd)
            {
                Console.WriteLine("В двух массивах одинаковое количество букв в верхнем регистре.");
            }
            else
            {
                Console.WriteLine("В нечётном массиве больше букв в верхнем регистре, а именно: " + counterOdd);
            }

            Console.ReadLine();
        }
    }
}