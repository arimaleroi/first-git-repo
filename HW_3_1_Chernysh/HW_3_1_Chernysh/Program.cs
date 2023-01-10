using System.Collections;
using System.Globalization;

namespace HW_3_1_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserList<string> list = new UserList<string>();

            list.Add("Andrey");
            list.Add("Sergey");
            list.Add("Denis");
            list.Add("Kolya");

            string[] strings = { "123", "555", "4590", "Boris"};

            list.AddRange(strings);

            var a = list.Remove("555");
            Console.WriteLine(a);

            list.RemoveAt(1);

            list.Sort();

            IEnumerable enumerable = list.arr as IEnumerable;
            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {

                string i = enumerator.Current as string;

                Console.WriteLine(i);
            }
        }
    }
}