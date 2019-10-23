using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircusTrain.classes
{
    class Train
    {
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public List<Wagon> ClosedWagons { get; set; } = new List<Wagon>();
        public int WagonSpace = 0;

        public List<Wagon> DivideAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Big)
                {
                    AddWagon(animal);
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Normal)
                {
                    AddWagon(animal);
                }
                else if (animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    List<Wagon> testwagons = new List<Wagon>();
                    testwagons = Wagons.ToList().Where(x => x.WagonAnimals.Count <= 1)
                    .Select(x => x)
                    .ToList();

                    foreach (Wagon wagon in testwagons)
                    {
                        int wagonSize = 0;
                        int checkedSize = 0;
                        foreach (Animal wagonAnimal in wagon.WagonAnimals)
                        {
                            wagonSize = wagonSize + (int)wagonAnimal.AnimalSize;
                            checkedSize = wagonSize + (int)animal.AnimalSize;
                            if (wagonAnimal.Diet == Diet.Carnivore && checkedSize < 10)
                            {
                                wagon.WagonAnimals.Add(animal);
                            }
                            else if (wagonAnimal.Diet == Diet.Herbivore && checkedSize < 10)
                            {

                            };
                        }
                    }
                    CloseWagons();
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    AddWagon(animal);
                }
                else
                {

                }
            }
            return Wagons;
        }

        public void AddWagon(Animal animal)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }
        
        public void CloseWagons()
        {
            for (int i = 0; i < Wagons.Count(); i++)
            {
                ClosedWagons.Add(Wagons[i]);
                Wagons.Remove(Wagons[i]);
            }
        }
    }
}
