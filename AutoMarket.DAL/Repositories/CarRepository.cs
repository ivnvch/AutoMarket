using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Car entity)
        {
            await _context.Cars.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
           _context.Cars.Remove(entity);
           await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Car> Get(int id)
        {
           return await _context.Cars.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _context.Cars.FirstOrDefaultAsync(x=>x.Mark == name);
        }

        public async Task<List<Car>> Select()
        {
            return await _context.Cars.AsNoTracking().ToListAsync();
        }

    }
}
