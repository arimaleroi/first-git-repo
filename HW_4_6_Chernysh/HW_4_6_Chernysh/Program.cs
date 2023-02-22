using HW_4_6_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HW_4_6_Chernysh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new DataBaseContext())
            {
                var first = dbContext.Songs.Where(x => x.Genre != null && x.Artists.Any())
                    .Select(x => new { x.Title, GenreName = x.Genre.Title, Artist = string.Join(',', x.Artists.Select(p => p.Name)) })
                    .ToList();

                var second = dbContext.Songs.GroupBy(x => x.Genre.Title).Select(x => new { x.Key, Count = x.Count() }).ToList();

                var third = dbContext.Songs.Where(x => x.ReleasedDate < dbContext.Artists.Max(p => p.DateOfBirth)).ToList();

            }
        }
    }
}