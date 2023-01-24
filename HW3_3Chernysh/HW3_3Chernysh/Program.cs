
namespace HW3_3Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post();
            post.Notify += Subscribe;

            Newspapers TheNewYorkTimes = new Newspapers("The New York Times", "ПУТИН УМЕР", "Бла, бла, бла...");
            Newspapers Politico = new Newspapers("Politico", "ШОЛЬЦ СОГЛАСИЛСЯ ПЕРЕДАТЬ ТАНКИ", "Остальные новости бла бла...");
            Newspapers Forbes = new Newspapers("Forbes", "ГЛАВА FTX БЫЛ АРЕСТОВАН", "Он всех обманул и бла бла...");

            post.Subscribe(TheNewYorkTimes);
            post.Subscribe(Politico);
            post.Subscribe(Forbes);

            post.Notify -= Subscribe;

            post.Notify += UnSubscribe;
            post.UnSubscribe(Forbes);
            post.Notify -= UnSubscribe;

            post.Notify += Send;
            post.Send(TheNewYorkTimes);
            post.Send(Politico);
            post.Send(Forbes);

            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            List<string> list = new List<string>() { "Anton", "Sergey", "Valentina", "Nikola", "Svyatoslav" };

            var first = list.FirstOrDefault2(s => s.Length == 6);

            Console.WriteLine(first);

            Console.WriteLine();

            var second = list.SkipWhile2(s => s.Length == 6);

            foreach (var item in second)
            {
                Console.WriteLine(item);
            }
        }

        static void Subscribe(Newspapers newspapers)
        {
            Console.WriteLine($"Вы подписались на {newspapers.NameOfNewspaper}");
        }

        static void UnSubscribe(Newspapers newspapers)
        {
            Console.WriteLine($"Вы отписались от {newspapers.NameOfNewspaper}");
        }
        static void Send(Newspapers newspapers)
        {
            Console.WriteLine();
            Console.WriteLine($"Вы получили новость от {newspapers.NameOfNewspaper}");
            Console.WriteLine($"Новость дня: {newspapers.Headline}");
            Console.WriteLine($"Остальные новости: {newspapers.Information}");
        }
    }
}