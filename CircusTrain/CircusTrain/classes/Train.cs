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
        public bool CheckFlag = false;

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
                }
                else if (animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    if (Wagons.Count() == 0)
                    {
                        AddWagon(animal);
                    }
                    else
                    {
                        for (int i = 0; i < Wagons.Count(); i++)
                        {
                            foreach (Animal wagonAnimal in Wagons[i].WagonAnimals)
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
                                AddWagon(animal);
                            }
                            else if (animal.Diet == Diet.Herbivore && WagonSpace >= 6 && animal.AnimalSize == AnimalSize.Big)
                            {
                                AddWagon(animal);
                            }
                            else
                            {
                                Wagons[i].AddAnimal(animal);
                            }
                            WagonSpace = 0;
                        }
                        CloseWagons();
                    }
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    if (Wagons.Count() == 0)
                    {
                        AddWagon(animal);
                    }
                    else
                    {
                        foreach (Wagon wagon in Wagons.ToList())
                        {
                            foreach (Animal wagonAnimal in wagon.WagonAnimals)
                            {
                                if (wagonAnimal.Diet == Diet.Carnivore)
                                {
                                    AddWagon(animal);
                                    break;
                                }
                                else
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
                            }

                            if (WagonSpace == 10)
                            {
                                AddWagon(animal);
                            }
                            else if(WagonSpace < 10 && CheckFlag == false)
                            {
                                wagon.AddAnimal(animal);
                            }
                            else if (CheckFlag)
                            {
                                break;
                            }
                        }
                    }
                    WagonSpace = 0;
                    CloseWagons();
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
                            foreach (Animal wagonAnimal in wagon.WagonAnimals)
                            {
                                if (wagonAnimal.Diet == Diet.Carnivore)
                                {
                                    CloseWagons();
                                    AddWagon(animal);
                                    break;
                                }
                                else
                                {
                                    if (WagonSpace >= 10)
                                    {
                                    }
                                    else
                                    {
                                        WagonSpace = WagonObj.CalculateWagonSize(wagonAnimal, WagonSpace);
                                    }
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
                            WagonSpace = 0;
                        }
                    }
                }
            }
            CloseWagons();
            return ClosedWagons;
        }

        private void CloseWagons()
        {
            WagonSpace = 0;
            CheckFlag = true;
            int wagonCount = Wagons.Count();

            for (int i = 0; i < wagonCount; i++)
            {
                ClosedWagons.Add(Wagons[0]);
                Wagons.Remove(Wagons[0]);
            }
        }

        public void AddWagon(Animal animal)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }
    }
}
