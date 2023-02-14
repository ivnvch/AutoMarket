using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Domain.Enum
{
    public enum Role
    {
        [Display(Name ="Пользователь")]
        User = 0,
        [Display(Name ="Администратор")]
        Admin = 1,
    }
}
