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
                var passangerData = System.IO.File.ReadAllText("Data/SeedData/PassangerData.json");
                var passangers = JsonConvert.DeserializeObject<List<Passangers>>(passangerData);
                foreach (var passanger in passangers)
                {
                    context.Passangers.Add(passanger);
                }
                context.SaveChanges();
            }

            if (!context.SecurityChecks.Any())
            {
                var securityCheckData = System.IO.File.ReadAllText("Data/SeedData/SecurityCheckData.json");
                var securityCheck = JsonConvert.DeserializeObject<List<SecurityCheck>>(securityCheckData);
                foreach (var data in securityCheck)
                {
                    context.SecurityChecks.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.NoFlyLists.Any())
            {
                var noFlyListsData = System.IO.File.ReadAllText("Data/SeedData/NoFlyListsData.json");
                var noFlyLists = JsonConvert.DeserializeObject<List<NoFlyList>>(noFlyListsData);
                foreach (var data in noFlyLists)
                {
                    context.NoFlyLists.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.FlightManifests.Any())
            {
                var FlightManifestsData = System.IO.File.ReadAllText("Data/SeedData/FlightManifestsData.json");
                var FlightManifests = JsonConvert.DeserializeObject<List<FlightManifest>>(FlightManifestsData);
                foreach (var data in FlightManifests)
                {
                    context.FlightManifests.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.Bookings.Any())
            {
                var bookingsData = System.IO.File.ReadAllText("Data/SeedData/BookingData.json");
                var bookings = JsonConvert.DeserializeObject<List<Booking>>(bookingsData);
                foreach (var data in bookings)
                {
                    context.Bookings.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.BoardingPasses.Any())
            {
                var boardingPassData = System.IO.File.ReadAllText("Data/SeedData/BoardingPassData.json");
                var boardingPass = JsonConvert.DeserializeObject<List<BoardingPass>>(boardingPassData);
                foreach (var data in boardingPass)
                {
                    context.BoardingPasses.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.Baggages.Any())
            {
                var baggagesData = System.IO.File.ReadAllText("Data/SeedData/BaggageData.json");
                var baggages = JsonConvert.DeserializeObject<List<Baggage>>(baggagesData);
                foreach (var data in baggages)
                {
                    context.Baggages.Add(data);
                }
                context.SaveChanges();
            }

            if (!context.BaggageChecks.Any())
            {
                var baggageChecksData = System.IO.File.ReadAllText("Data/SeedData/BaggageCheckData.json");
                var baggageCheck = JsonConvert.DeserializeObject<List<BaggageCheck>>(baggageChecksData);
                foreach (var data in baggageCheck)
                {
                    context.BaggageChecks.Add(data);
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

