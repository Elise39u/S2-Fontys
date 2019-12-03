using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain.classes
{
    public class Wagon
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

        public int CalculateWagonSize(Animal animal, int wagonSize)
        {
            wagonSize = wagonSize + (int)animal.AnimalSize;

            if(wagonSize > 11)
            {
                wagonSize = 11;
            } 

            return wagonSize;
        }
    }
}
