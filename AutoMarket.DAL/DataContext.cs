using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.DAL
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Car> Cars { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(x => x.Price).HasColumnType("decimal").HasPrecision(18,2);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("AutoMarket.Domain")
        //}
    }
}
