namespace AutoMarket.Common.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string TypeCar { get; set; }
    }
}
