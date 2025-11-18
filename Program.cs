using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Utilities.Seeder;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Text.Json.Serialization;
using DTFusionZ_BE.Config;
using DTFusionZ_BE.Services;
using Stripe;

namespace DTFusionZ_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DTFusionZDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Configure Stripe
            builder.Services.Configure<StripeSettings>(
                builder.Configuration.GetSection("Stripe"));
            
            // Initialize Stripe
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            builder.Services.AddScoped<StripeService>();

            // Register the PasswordHasher service
            //builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            var app = builder.Build();
            app.UseCors("AllowAll");

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<DTFusionZDbContext>();
                    dbContext.Database.Migrate(); // Apply any pending migrations
                    DataSeeder.SeedData(dbContext); // Seed initial data
                    Console.WriteLine("Database migrated and seeded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
                }
            }

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