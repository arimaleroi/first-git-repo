namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst("a");
            list.AddFirst("b");
            list.AddLast("9");
            list.AddLast("12");
            list.AddFirst("c");

            var a = list.Contains("a");

            var b = list.Find("9");

            Console.WriteLine(b);



        }
    }
}