using ManagePeople.Data.DataModels.Person;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagePeople.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = ServicesExtensions.GetApplicationConnectionString();
            optionsBuilder.UseSqlServer(new SqlConnection(conn));
        }
    }
}