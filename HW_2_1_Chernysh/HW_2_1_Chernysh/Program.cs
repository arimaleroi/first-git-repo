namespace HW_2_1_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.GetInstance().LogLevel = StatusEnum.Error;

            Starter.Run();

            Logger.GetInstance().Output();

            string path = "logs.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var log in Logger.GetInstance().Logs)
                {
                    writer.WriteLine($"{log.DateTime}: {log.Status}: {log.Message}");
                }
            }
        }
    }
}