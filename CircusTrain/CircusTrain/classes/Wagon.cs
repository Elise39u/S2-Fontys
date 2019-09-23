using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain.classes
{
    class Wagon
    {
        private int MaxWagonSize { get; } = 10;
        public List<Animal> WagonAnimals { get; private set; }

        public Wagon()
        {
            WagonAnimals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            WagonAnimals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {

        }

        public int CalculateWagonSize()
        {
            int wagonSize = 0;

            return wagonSize; 
        }
    }
}
