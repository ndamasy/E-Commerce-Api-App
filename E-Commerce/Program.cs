
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeed;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            #region configuration Services
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeeding, DataSeeding>();

            #endregion
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            #region Services
            //create environment that contain sevices that i used in dependancy injection

            var Scope= app.Services.CreateScope();
            var objectOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            objectOfDataSeeding.DataSeeding();
            #endregion
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
