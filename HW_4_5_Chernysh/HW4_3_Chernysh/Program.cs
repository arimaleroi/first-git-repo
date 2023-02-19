using HW4_3_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace HW4_3_Chernysh
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new DataBaseContext())
            {
                //1

                var first = from employeeprojects in dbContext.EmployeeProjects
                                   join employee in dbContext.Employees
                                   on employeeprojects.EmployeeId equals employee.EmployeeId into temp
                                   from result in temp.DefaultIfEmpty()

                                   join project in dbContext.Projects
                                   on employeeprojects.ProjectId equals project.ProjectId into tempSecond
                                   from resultSecond in tempSecond.DefaultIfEmpty()
                                   select new { employeeprojects.EmployeeId, result.Title, resultSecond.Name };

                //2

                var second = dbContext.Employees.Select(x => new { x.EmployeeId, Difference = EF.Functions.DateDiffDay(x.HiredDate, DateTime.Now) });
                dbContext.SaveChanges();

                //3

                var transaction = dbContext.Database.BeginTransaction();

                try
                {
                    (dbContext.Clients.ToList())[3].Email = "newemail@gmail.com";

                    (dbContext.Projects.ToList())[1].Name = "New ProjectName";

                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception)
                {
                    transaction.Rollback();
                }

                //4

                dbContext.Employees.Add(new Employee 
                { 
                    FirstName = "Sergey", LastName = "Chernysh", HiredDate = new DateTime(2022,10,10), 
                    Office = new Office { Ttitle = "New Office", Location = "New Location" },
                    Title = new Title { Name= "New Title" }
                });
                dbContext.SaveChanges();

                //5

                dbContext.Employees.Remove((dbContext.Employees.ToList())[0]);
                dbContext.SaveChanges();

                //6

                var sixth = dbContext.Employees.Where(x => !x.Title.Name.Contains("a")).GroupBy(x => x.Title.Name).Select(x => x.Key);
                dbContext.SaveChanges();

            }

        }
    }
}