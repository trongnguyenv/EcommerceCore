using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace City_Shop.Data.EF
{
    public class CityShopDbContextFactory : IDesignTimeDbContextFactory<CityShopDbContext>
    {
        public CityShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   //Microsoft.FileExtension
                   .SetBasePath(Directory.GetCurrentDirectory())
                   //Microsoft.Extension.Json
                   .AddJsonFile("appsettings.json")
                   .Build();
            var connectionString = configuration.GetConnectionString("CityDatabase");

            var optionBuilder = new DbContextOptionsBuilder<CityShopDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new CityShopDbContext(optionBuilder.Options);
        }
    }
}