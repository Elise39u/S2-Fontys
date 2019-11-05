using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircusTrain.classes
{
    public class Train
    {
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public List<Wagon> ClosedWagons { get; set; } = new List<Wagon>();
        public int WagonSpace = 0;
        public Wagon WagonObj = new Wagon();

        public List<Wagon> DivideAnimals(List<Animal> animals)
        {
            //animals.Sort();
            foreach(Animal animal in animals)
            {
                if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Big)
                {
                    AddWagon(animal);
                    CloseWagons();
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Normal)
                {
                    AddWagon(animal);
                    CloseWagons();
                }
                else if (animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    if (Wagons.Count() == 0)
                    {
                        AddWagon(animal);
                    }
                    else
                    {
                        foreach (Wagon wagon in Wagons.ToList())
                        {
                            foreach (Animal wagonAnimal in wagon.WagonAnimals.ToList())
                            {
                                if (WagonSpace == 10)
                                {
                                    break;
                                }
                                else
                                {
                                    WagonSpace = WagonObj.CalculateWagonSize(wagonAnimal, WagonSpace);
                                }
                            }

                            if (WagonSpace == 10)
                            {
                                CloseWagons();
                                AddWagon(animal);
                            }
                            else
                            {
                                wagon.AddAnimal(animal);
                            }
                            WagonSpace = 0;
                        }
                    }
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    CloseWagons();
                    if (Wagons.Count() == 0)
                    {
                        AddWagon(animal);
                    }
                    else
                    {
                        foreach (Wagon wagon in Wagons.ToList())
                        {
                            foreach (Animal wagonAnimal in wagon.WagonAnimals.ToList())
                            {
                                if (wagonAnimal.Diet == Diet.Carnivore)
                                {
                                    AddWagon(animal);
                                }
                                else
                                {
                                    int wagonSize = WagonObj.CalculateWagonSize(animal, WagonSpace);
                                    if (wagonSize >= 10)
                                    {
                                        WagonSpace = 0;
                                        AddWagon(animal);
                                    }
                                    else
                                    {
                                        wagon.WagonAnimals.Add(animal);
                                    }
                                }
                            }
                        }
                        WagonSpace = 0;
                    }
                }
                else
                {
                    if (Wagons.Count() == 0)
                    {
                        AddWagon(animal);
                    }
                    else
                    {
                        foreach (Wagon wagon in Wagons.ToList())
                        {
                            foreach (Animal wagonAnimal in wagon.WagonAnimals.ToList())
                            {
                                if (WagonSpace >= 10)
                                {
                                    break;
                                }
                                else
                                {
                                    WagonSpace = WagonObj.CalculateWagonSize(wagonAnimal, WagonSpace);
                                }
                            }

                            if (WagonSpace == 10)
                            {
                                CloseWagons();
                                AddWagon(animal);
                            }
                            else if (animal.Diet == Diet.Herbivore && WagonSpace >= 9 && animal.AnimalSize == AnimalSize.Normal)
                            {
                                CloseWagons();
                                AddWagon(animal);
                            }
                            else
                            {
                                wagon.AddAnimal(animal);
                            }
                        }
                        WagonSpace = 0;
                    }
                }
            }
            CloseWagons();
            return ClosedWagons;
        }

        public void AddWagon(Animal animal)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }

        public void CloseWagons()
        {
            WagonSpace = 0;
            int wagonsCount = Wagons.Count();
            //Issue loops works once on Big and Normal Carnivore
            for (int i = 0; i < Wagons.Count(); i++)
            {
                ClosedWagons.Add(Wagons[i]);
                Wagons.Remove(Wagons[i]);
            }
        }
    }
}
