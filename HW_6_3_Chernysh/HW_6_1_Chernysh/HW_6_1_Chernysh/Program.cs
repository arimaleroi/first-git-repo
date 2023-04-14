using HW_6_1_Chernysh.Core;
using HW_6_1_Chernysh.Core.Filters;

namespace HW_6_1_Chernysh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSingleton<IBookRepository,BookRepository>();
            builder.Services.AddControllers();


            builder.Services.AddMvc(options =>
            {
                options.Filters.Add<LoggerFilter>();
                options.Filters.Add<ExceptionFilter>();

            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}