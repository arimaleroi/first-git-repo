using HW_6_1_Chernysh.Core;

namespace HW_6_1_Chernysh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSingleton<IBookRepository,BookRepository>();
            builder.Services.AddControllers();


            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}