using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("-->Seeding data!");
                context.Platforms.AddRange(
                    new Platform() {Name="Dot net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name = "SQL Server Express", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name = "Kubernetes", Publisher="Cloud Native Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("-->We already have data!");
            }
        }
    }
}