﻿namespace Quhinja.Data.Entiities
{
    using global::Quhinja.Data.Entities;
    using System;

    namespace Quhinja.Data.Entiities
    {
        class UserCommentsForDish
        {
            public int Id { get; set; }

            public int UserId { get; set; }

            public User User { get; set; }

            public int DishId { get; set; }

            public Dish Dish { get; set; }
            public string com { get; set; }
            public DateTime DateOfComment { get; set; }
        }
    }

}
