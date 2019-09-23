using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain.classes
{
    class Train
    {
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public List<Wagon> ClosedWagons { get; set; } = new List<Wagon>();

        public List<Wagon> DivideAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                if(animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Big)
                {
                    Wagon wagon = new Wagon();
                    wagon.AddAnimal(animal);
                    ClosedWagons.Add(wagon);
                }
                else if(animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Normal)
                {
                    Wagon wagon = new Wagon();
                    wagon.AddAnimal(animal);
                    Wagons.Add(wagon);
                }
                else if(animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    /* Paar dingen doen
                     *   1. Alle wagons ophalen
                     *   2. Dieren er in checken
                     *   3. eisen checken
                     *   3.1 De waarde moet kleiner of gelijk dan 10
                     */
                    List<Wagon> testwagons = new List<Wagon>();
                    testwagons = Wagons.ToList().Where(x => x.WagonAnimals.Count <= 1)
                        .Select(x => x)
                        .ToList();

                    //testwagons = testwagons.ForEach(x => x
                    //Gebruik dit nu maar zover het kan
                    foreach(Wagon wagon in testwagons)
                    {
                        foreach(Animal wagonAnimal in wagon.WagonAnimals)
                        {
                            Console.WriteLine("-------Found the next--------");
                            Console.WriteLine(wagonAnimal.AnimalSize);
                            Console.WriteLine(wagonAnimal.Diet);
                            Console.WriteLine("-------Next wagon--------");
                        }
                    }

                    /*
                    foreach (Animal testAnimal in wagon.WagonAnimals)
                    {
                        List<Wagon> testwagons = Wagons.ToList()
                         .Select(x => x.WagonAnimals)
                         .Where(x => x.Diet == Diet.Carnivore && x.AnimalSize == AnimalSize.Normal)
                         .Select(x => wagon.WagonAnimals.Count > 1)
                         .ToList();
                    }
                    */
                }
            }

            return Wagons;
        }

        public List<Wagon> AddWagon(List<Wagon> wagons)
        {
            return Wagons;
        }

        public void RemoveWagon(Wagon wagon)
        {

        }
    }
}
