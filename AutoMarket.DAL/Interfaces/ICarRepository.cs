using AutoMarket.Domain.Entity;
using System.Collections.Generic;

namespace AutoMarket.DAL.Interfaces
{
    public interface ICarRepository: IBaseRepository<Car>
    {
        Car GetByName(string name);
    }
}
