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

        public bool Create(Car entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Car>> Select()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
