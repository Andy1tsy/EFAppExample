using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Data.Entity;

namespace EFAppExample
{
    /// <summary>
    /// methods are being used for buttons clicks and other methods (controlling layer)
    /// </summary>
    public class Utility :BaseForBinding
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ObservableCollection<Cat> Cats { get; set; }
        public List<Cat> tempCats;
        public Cat NewCat { get; set; }
        public Repository Repository { get; set; }
        public CatContext catContext;
        /// <summary>
        /// Interval - shows estimated time of function work in milliseconds ( Property modified for binding)
        /// </summary>
        private int _interval;
        public int Interval
        {
            get => _interval;
            set
            {
                if (Equals(_interval, value)) return;

                _interval = value;
                OnPropertyChanged();
            }
        }

        public Utility(Repository repository)
        {
            Repository = repository;
            Cats = new ObservableCollection<Cat>(Repository.Cats);
            tempCats = new List<Cat>();
            NewCat = new Cat();
        }

        /// <summary>
        /// Saves current collection to DB file
        /// </summary>
        public void SaveToDb()
        {
            StartTime = DateTime.Now;
            tempCats = new List<Cat>(Cats);
            using (catContext = new CatContext())
            {
                foreach (var item in tempCats)
                {
                    catContext.Cats.Add(item);
                }
                catContext.SaveChanges();
            }
            EndTime = DateTime.Now;
            Interval = (int)EndTime.Subtract(StartTime).TotalMilliseconds;
        }

        /// <summary>
        /// Loads collection from DB file and replaces current collection
        /// </summary>
        public void LoadFromDb()
        {
            StartTime = DateTime.Now;
            Cats.Clear();
            tempCats.Clear();
            using (catContext = new CatContext())
            {
            var cats = catContext.Cats;
            foreach (var item in cats)
            {
                tempCats.Add(item);
            }
            foreach (var item in tempCats)
            {
                Cats.Add(item);
            }     
            }
            EndTime = DateTime.Now;
            Interval = (int)EndTime.Subtract(StartTime).TotalMilliseconds;
        }
        
        /// <summary>
        /// randomly generates new instane of Cat and adda it to current collection
        /// </summary>
        public void GenerateRandomCat()
        {
            NewCat = new Cat();
            var rn = new Random(DateTime.Now.Millisecond);
            NewCat.Name = Repository.Names[rn.Next(Repository.Names.Count)];
            NewCat.Breed = Repository.Breeds[rn.Next(Repository.Breeds.Count)];
            NewCat.Color = Repository.Colors[rn.Next(Repository.Colors.Count)];
            NewCat.Age = rn.Next(1, 10);
            NewCat.Weight = ((double)rn.Next(800) + 200.0) / 100.0;
            Cats.Add(NewCat);
        }
        /// <summary>
        /// adds manually entered Cat data (after validation)
        /// </summary>
        public void AddEnteredData()
        {
            if (!ValidateEnteredData(NewCat))
            {
                MessageBox.Show("Some data is missing!!!");
                return;
            }
            Cats.Add(NewCat);
        }

        /// <summary>
        /// validates entered Cat data
        /// </summary>
        /// <returns></returns>
        public bool ValidateEnteredData(Cat cat)
        {
            return !string.IsNullOrWhiteSpace(cat.Name)
                    && !string.IsNullOrWhiteSpace(cat.Breed)
                    && !string.IsNullOrWhiteSpace(cat.Color)
                    && cat.Age != 0
                    && cat.Weight != 0.0;
        }

    }
}
