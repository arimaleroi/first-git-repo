using HW_6_1_Chernysh.Core;
using HW_6_1_Chernysh.Core.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HW_6_1_Chernysh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSingleton<IBookRepository,BookRepository>();
            builder.Services.AddControllers();

               
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["http://localhost:51111"];
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            builder.Services.AddLocalization();
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add<LoggerFilter>();
                options.Filters.Add<ExceptionFilter>();

            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}