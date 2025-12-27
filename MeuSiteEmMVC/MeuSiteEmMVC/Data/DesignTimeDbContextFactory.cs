using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeuSiteEmMVC.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BancoContext>
    {
        public BancoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BancoContext>();
            var connectionString = configuration.GetConnectionString("DataBase");

            builder.UseSqlServer(connectionString);

            return new BancoContext(builder.Options);
        }
    }
}
