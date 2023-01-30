using System.Xml.Serialization;

namespace Task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var result = await Task.WhenAll(ReadSite("https://soundcloud.com"), ReadSite("https://genius.com"));

            await Task.WhenAll(WriteToFile(result[0], "D:\\1.txt"), WriteToFile(result[1], "D:\\2.txt"));

            var file1 = await ReadFile("D:\\1.txt");
            var file2 = await ReadFile("D:\\2.txt");

            var resultWords = file1.Concat(file2).GroupBy(x => x);

            foreach (var str in resultWords)
            {
                Console.WriteLine(str.Key + " = " + str.Count());
            }
        }
        static async Task<string> ReadSite(string path)
        {
            string result = string.Empty;
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync(path);
                result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response.StatusCode);
            }
            return result;
        }
        static async Task WriteToFile(string text, string path)
        {
            using(var writer = new StreamWriter(path))
            {
                await writer.WriteLineAsync(text);
            }
        }
        
        static async Task<string[]> ReadFile(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }
    }
}