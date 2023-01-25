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
            modelBuilder.Entity<Car>().Property(x => x.Price).HasColumnType("decimal").HasPrecision(18, 2);

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1, Mark = "Audi", Model = "R8", Price = 150000, Description = "Разгон с 0 до 100 менеее чем за 3,5 секунды/)", Speed = 310, TypeCar = Domain.Enum.TypeCar.SportCar
                });
        }       

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("AutoMarket.Domain")
        //}
    }
}
