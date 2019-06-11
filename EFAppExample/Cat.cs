using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFAppExample
{
    /// <summary>
    /// Class which determins creating of entity "Cat" written to DB
    /// </summary>
    public class Cat :BaseForBinding
    {
        public int Id { get; set; }
        private string _name;
        private string _breed;
        private string _color;
        private int _age;
        private double _weight;


        public string Name
        {
            get => _name;
            set
            {
                if (Equals(_name, value)) return;

                _name = value;
                OnPropertyChanged();
            }
        }
        public string Breed
        {
            get => _breed;
            set
            {
                if (Equals(_breed, value)) return;

                _breed = value;
                OnPropertyChanged();
            }
        }
        public string Color
        {
            get => _color;
            set
            {
                if (Equals(_color, value)) return;

                _color = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (Equals(_age, value)) return;

                _age = value;
                OnPropertyChanged();
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (Equals(_weight, value)) return;

                _weight = value;
                OnPropertyChanged();
            }
        }

        public Cat()
        { }

        public Cat(string name, string breed, string color, int age, double weight)
        {
            Name = name;
            Breed = breed;
            Color = color;
            Age = age;
            Weight = weight;
        }

    }
}
