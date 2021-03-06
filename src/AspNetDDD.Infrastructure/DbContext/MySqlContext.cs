using Microsoft.EntityFrameworkCore;
using AspNetDDD.Domain;

namespace AspNetDDD.Infrastructure
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private string connectionString = "server=127.0.0.1;port=3306;Database=AspNetDDD;user=root;password=password;";
        private MySqlServerVersion serverVersion = new MySqlServerVersion(new System.Version(8,0,21));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(serverVersion: serverVersion, connectionString: connectionString,
                    mySqlOptionsAction: builder => builder.EnableRetryOnFailure());
            }
        }
    }
}
