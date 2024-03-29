﻿using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль" )]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хэтчбек")]
        HatchBack = 2,
        [Display(Name = "Минивэн")]
        Minivan = 3,
        [Display(Name = "Спорткар")]
        SportCar = 4,
        [Display(Name = "Внедорожник")]
        Suv = 5

    }
}
