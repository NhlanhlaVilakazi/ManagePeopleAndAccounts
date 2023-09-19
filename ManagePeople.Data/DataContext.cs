using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagePeople.Data
{
    public class DataContext : DbContext
    {
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new SqlConnection(ServicesExtensions.defaultConnectionString));
        }
    }
}