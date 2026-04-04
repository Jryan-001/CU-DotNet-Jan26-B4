using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VagabondAPI.Data;
using VagabondAPI.Repository;
using VagabondAPI.Services;
using VagabondAPI.Exceptions;

namespace VagabondAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<VagabondAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VagabondAPIContext") ?? throw new InvalidOperationException("Connection string 'VagabondAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
            builder.Services.AddScoped<IDestinationService, DestinationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
