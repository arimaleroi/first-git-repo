using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Task13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Ivan", Surname = "Ivanov", Email = "ivanovivan@gmail.com",
                           DateOfBirth = new DateTime(2001, 09, 15), Id = 0 },

                new User { Name = "Petr", Surname = "Petrov", Email = "petrpetrov@gmail.com",
                           DateOfBirth = new DateTime(1991, 05, 01), Id = 1 },

                new User { Name = "Andrey", Surname = "Ivanov", Email = "andreyivanov@gmail.com",
                           DateOfBirth = new DateTime(1977, 12, 27), Id = 2 },

                new User { Name = "Olexandr", Surname = "Shapoval", Email = "olexandrshapoval@protonmail.com",
                           DateOfBirth = new DateTime(2004, 07, 09), Id = 3 },

                new User { Name = "Nikita", Surname = "Petrov", Email = "nikitasazonov@gmail.com",
                           DateOfBirth = new DateTime(2010, 02, 12), Id = 4 },

                new User { Name = "Pavlo", Surname = "Ivanov", Email = "pavloivanov@protonmail.com",
                           DateOfBirth = new DateTime(1990, 10, 10), Id = 5 },

                new User { Name = "Ivan", Surname = "Avramenko", Email = "ivanavramenko@ukr.net",
                           DateOfBirth = new DateTime(1986, 07, 03), Id = 6 },

                new User { Name = "Oleg", Surname = "Vinnik", Email = "olegvinnik@gmail.com",
                           DateOfBirth = new DateTime(2004, 05, 15), Id = 7 },

                new User { Name = "Sergey", Surname = "Derkach", Email = "sergeyderkach@gmail.com",
                           DateOfBirth = new DateTime(2006, 12, 12), Id = 8 },

                new User { Name = "Viktor", Surname = "Vovk", Email = "viktorvovk@protonmail.com",
                           DateOfBirth = new DateTime(1995, 04, 20), Id = 9 }
            };

            var today = DateTime.Today;

            var usersMoreThanEighteen = users.Where(x => (today.Year - x.DateOfBirth.Year) > 18).Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                DateOfBirth = x.DateOfBirth,
                FullYears = today.Year - x.DateOfBirth.Year
            });

            foreach (var a in usersMoreThanEighteen)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            var usersDomain = users.GroupBy(x => x.Email.Split('@')[1]).OrderByDescending(x => x.Count()).Select(x => (x.Key, x.Count())).First();

            Console.WriteLine($"Наиболее используемый домен: {usersDomain.Key}, количество пользователей: {usersDomain.Item2}");
            Console.WriteLine();

            var usersHashSet = users.ToHashSet();

            var findHashSet = usersHashSet.TryGetValue(new User { Id = 1 }, out _);

            Console.WriteLine("Поиск: " + findHashSet);

            var family = users.GroupBy(x => x.Surname).ToDictionary(x => x.Key, x => x.Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                DateOfBirth = x.DateOfBirth,
            }).OrderBy(x=>x.DateOfBirth));

            foreach (var a in family)
            {
                Console.WriteLine("Возможные родственники: " + a.Key);
                foreach (var b in a.Value)
                {
                    Console.WriteLine(b);
                }
                
            }
        }
    }
}