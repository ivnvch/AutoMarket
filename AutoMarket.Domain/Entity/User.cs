using AutoMarket.Domain.Enum;

namespace AutoMarket.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
