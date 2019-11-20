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
        public int J = 0;
        public bool CarnivoreCheck = false;

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
                        if(J >= Wagons.Count())
                        {
                            J = 0;
                        }

                        for(int i = 0; i < 1; i++)
                        {
                            foreach (Animal wagonAnimal in Wagons[J].WagonAnimals)
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
                            else if (animal.Diet == Diet.Herbivore && WagonSpace >= 6 && animal.AnimalSize == AnimalSize.Big)
                            {
                                CloseWagons();
                                AddWagon(animal);
                            }
                            else
                            {
                               Wagons[J].AddAnimal(animal);
                            }
                           WagonSpace = 0;
                           J++;
                        }
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
                        if (J >= Wagons.Count())
                        {
                            J = 0;
                        }

                        for (int i = 0; i < 1; i++)
                        {
                            foreach (Animal wagonAnimal in Wagons[J].WagonAnimals)
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
                                CloseWagons();
                                AddWagon(animal);
                            }
                            else if(WagonSpace < 10 && CheckFlag == false)
                            {
                                Wagons[J].AddAnimal(animal);
                            }
                            else if (CheckFlag)
                            {
                                break;
                            }
                            WagonSpace = 0;
                        }
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
                        if (J >= Wagons.Count())
                        {
                            J = 0;
                        }

                        for (int i = 0; i < 1; i++)
                        {
                            foreach (Animal wagonAnimal in Wagons[J].WagonAnimals)
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
                                Wagons[J].AddAnimal(animal);
                            }
                            WagonSpace = 0;
                            J++;
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
