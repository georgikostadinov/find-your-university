﻿namespace FindYourUniversity.Data.Models
{
    using FindYourUniversity.Data.Common.Models;

    public class City : DeletableEntity
    {
        public City()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
