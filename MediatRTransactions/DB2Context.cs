using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace MediatRTransactions
{
    public class DB2Context : DbContext, IDbContext2
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                this.ConnectionString = configuration.GetConnectionString("DB2Connection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public string ConnectionString { get; set; }
        public DbSet<Names> Names { get; set; }
    }
}
