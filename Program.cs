
using FluentAssertions.Common;
using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;



namespace ITI_Project
{
    public class Program()
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Dbcontext
            builder.Services.AddDbContext<ItiProjectContext>(optionsBuilder =>
            {

                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
                optionsBuilder.UseLazyLoadingProxies(true);
            });
            #endregion

            // Add services to the container
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
