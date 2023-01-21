namespace HW3_2_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserLinkedList<int> list = new UserLinkedList<int>();

            list.Add(1);
            list.Add(5);
            list.Add(7);
            list.Add(2);
            list.Add(8);
            list.Add(15);
            list.Add(9);
            list.Add(7);

            list.Remove(2);

            var a = list.Search(3);
            Console.WriteLine(a);
            Console.WriteLine();

            var b = list.WhereEquals(7);

            foreach(var x in b)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}