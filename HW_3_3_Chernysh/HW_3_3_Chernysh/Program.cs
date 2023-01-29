namespace HW_3_4_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 100, -10, 22, 36, 893, 13, 104, 33, 1, 3, -10, 22, 22, 36, 13, 1, 2 };

            Console.WriteLine("Первое задание: ");

            var divisibleNumbers = numbers.Where(x => x % 2 == 0 && x % 3 == 0);

            foreach (var number in divisibleNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Второе задание: ");

            var sumOfNumbers = numbers.Sum(x => x);

            Console.WriteLine(sumOfNumbers);

            Console.WriteLine("Третье задание: ");

            var averageOfNumbers = numbers.Average(x => x);

            Console.WriteLine(averageOfNumbers);

            Console.WriteLine("Четвертое задание: ");

            var maxOfNumbers = numbers.Max(x => x);

            Console.WriteLine(maxOfNumbers);

            Console.WriteLine("Пятое задание: ");

            var minOfNumbers = numbers.Min(x => x);

            Console.WriteLine(minOfNumbers);

            Console.WriteLine("Шестое задание: ");

            var moreThanTen = numbers.Where(x => x > 10).Select(x => x * 10);


            foreach (int number in moreThanTen)
            {


                Console.Write(number + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Седьмое задание: ");

            string strings = "Abilities forfeited situation extremely my to he resembled. Old had conviction discretion understood put principles you.";

            char[] chars = strings.ToCharArray();

            var uniqueChars = chars.Distinct();

            foreach (var c in uniqueChars)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Восьмое задание: ");

            var freq = from x in numbers
                       group x by x into xFreq
                       select xFreq;

            foreach (var a in freq)
            {
                Console.WriteLine($"Число {a.Key} встречалось {a.Count()} раз");
            }

            Console.WriteLine("Девятое задание: ");

            var groupNumbersEven = from x in numbers
                                   where x % 2 == 0
                                   select x;
            var maxEvenNumber = groupNumbersEven.Max(x => x);

            var groupNumbersOdd = from x in numbers
                                  where x % 2 != 0
                                  select x;

            var maxOddNumber = groupNumbersOdd.Max(x => x);

            Console.WriteLine($"Чётные числа: ");
            foreach (var a in groupNumbersEven)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Максимальное число из чётных: {maxEvenNumber}");

            Console.WriteLine($"Нечётные числа: ");
            foreach (var a in groupNumbersOdd)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Максимальное чилсо из нечётных: {maxOddNumber}");

            Console.WriteLine("Десятое задание: ");

            var moreThanAvg = numbers.Where(x => x > numbers.Average());

            foreach (var a in moreThanAvg)
            {
                Console.WriteLine(a);
            }

            string[] strings2 = { "Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled",
                                  "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you" };


            Console.WriteLine("Одинадцатое задание: ");

            var byLength = strings2.OrderBy(x => x.Length).ToArray();

            foreach (var a in byLength)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Двенадцатое задание: ");

            var elementWithSubstr = strings2.Where(x => x.Contains("ti")).OrderBy(x => x.Length).Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower()).ToList();

            foreach (var a in elementWithSubstr)
            {
                Console.WriteLine(a);
            }

        }
    }
}
