using System;
using System.Collections.Generic;


namespace EFAppExample
{
    /// <summary>
    /// Repository of preset data for using in program as example
    /// </summary>
    public class Repository
    {
        public List<Cat> Cats { get; set; }
        public List<string> Names { get; set; }
        public List<string> Breeds { get; set; }
        public List<string> Colors { get; set; }

        public Repository()
        {
            Cats = new List<Cat>()
            {
                new Cat("Sam", "British", "Blue", 2, 6.8),
                new Cat("Max", "Scottish", "Rouge", 3, 5.3),
                new Cat("Jack", "Bengal", "Spotted", 1, 3.9),
                new Cat("Leo", "Abissin", "Sandy", 4, 2.8),
                new Cat("Kim", "Oriental", "Brown", 2, 4.1),
                new Cat("Bob", "Ragdoll", "Tabby", 5, 7.2),

            };

            Names = new List<string>()
            {
                "Kirk", "Mick", "Tiger", "Fluff", "Ivy", "Mike", "Tom", "Bob", "Moss"
            };

            Breeds = new List<string>()
            {
                "Brirish", "Scottish", "Oriental", "Bengal", "Abissin", "MaineCoon", "Ragdoll", "Persian", "Birman"
            };

            Colors = new List<string>()
            {
                "White", "Silver", "Smoke", "Sandy", "Browh", "Stripped", "Tabby", "Black", "Blue"
            };

        }

    }
}
