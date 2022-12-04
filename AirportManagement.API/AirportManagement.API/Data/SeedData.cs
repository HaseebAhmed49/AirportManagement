using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirportManagement.API.Data
{
    public static class SeedData
    {
        private static void SeedUsers(AppDbContext context)
        {
            if (!context.Passangers.Any())
            {
                var passangerData = System.IO.File.ReadAllText("Data/SinglePassangerSeedData.json");
                var passangers = JsonConvert.DeserializeObject<List<Passangers>>(passangerData);
                foreach (var passanger in passangers)
                {
                    context.Passangers.Add(passanger);
                }
                context.SaveChanges();
            }
        }

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    context.Database.Migrate();
                    SeedUsers(context);
                }
                catch (Exception ex)
                {
                    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An occur occured during migration");
                }
            }
        }
    }
}

