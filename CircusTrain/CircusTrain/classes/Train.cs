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
                  List<Wagon> testwagons = new List<Wagon>();
                  testwagons = Wagons.ToList().Where(x => x.WagonAnimals.Count <= 1)
                  .Select(x => x)
                  .ToList();

                  //testwagons = testwagons.ForEach(x => x)
                  // Het probleem voor mij is dat ik niet met linq kan komen bij
                  //  wagon -> Test wagons en daar in de animals list 
                  //Gebruik dit nu maar zover het kan
                    foreach(Wagon wagon in testwagons)
                    {
                        int wagonSize = 0;
                        int checkedSize = 0;
                        foreach(Animal wagonAnimal in wagon.WagonAnimals)
                        {
                            wagonSize = wagonSize + (int)wagonAnimal.AnimalSize;
                            checkedSize = wagonSize + (int)animal.AnimalSize;
                            if(wagonAnimal.Diet == Diet.Carnivore && checkedSize < 10)
                            {
                                wagon.WagonAnimals.Add(animal);
                            }
                            else if(wagonAnimal.Diet == Diet.Herbivore && checkedSize < 10)
                            {

                            };
                        }
                    }
                }
                else if(animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    int countAvilableWagons = Wagons.Count();
                    if(countAvilableWagons == 0)
                    {
                        Wagon wagon = new Wagon();
                        wagon.AddAnimal(animal);
                        Wagons.Add(wagon);
                    }
                    else
                    {
                        /*
                         * Train --> Wagons 
                         * Wagons --> Loopen
                         * Wagon.AnimalList --> Animals 
                        
                        List<Animal> wagonAnimals = Wagons
                            .Select(x => x)
                            .Where(x => x.WagonAnimals);

                        List<Wagon> avilbaleWagons = wagonAnimals
                            .Select(x => x.)

                        */
                        List<Animal> wagonAnimals = new List<Animal>();

                        foreach (Wagon wagon in Wagons)
                        {
                            wagonAnimals = wagon.WagonAnimals;
                        }
                    }
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
