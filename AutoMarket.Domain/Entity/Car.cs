using AutoMarket.Domain.Enum;

namespace AutoMarket.Domain.Entity
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Modek { get; set; }
        public string Description { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeCar TypeCar { get; set; }
    }
}
