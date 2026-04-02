using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentAPI.Data;

namespace FluentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FluentAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FluentAPIContext") ?? throw new InvalidOperationException("Connection string 'FluentAPIContext' not found.")));

            builder.Services.AddScoped<FluentAPI.Repositories.IStudentRepository, FluentAPI.Repositories.StudentRepository>();
            builder.Services.AddScoped<FluentAPI.Repositories.ICourseRepository, FluentAPI.Repositories.CourseRepository>();

            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlSerializerFormatters();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
