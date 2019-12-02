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
        //Make a new aviable wagon list and closed wagon list 
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public List<Wagon> ClosedWagons { get; set; } = new List<Wagon>();
        
        //Make some new nesscary global vars 
        public int WagonSpace = 0;
        public Wagon WagonObj = new Wagon();
        public bool CheckFlag = false;
        public int J = 0;

        public List<Wagon> DivideAnimals(List<Animal> animals)
        {
            //Loop over the animal List given by the user
            foreach (Animal animal in animals)
            {
                //Check if the animal is a big Carnivore
                if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Big)
                {
                    //If the animal is a carnivore and big add him to a wagon an close the wagon
                    AddWagon(animal);
                    CloseWagons();
                }
                //Check if the animal is a normal carnivore
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Normal)
                {
                    //If the animal is a normal carnivore add him to a new wagon
                    AddWagon(animal);
                }
                //Check if the animal is a big Hebivore 
                else if (animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    DivideAnimal(animal);
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    bool ContinuDividing = EmptyWagonListCheck(animal);

                    if (ContinuDividing == false)
                    {
                        CheckWagonSearcher();
                        DivideAnimal(animal);
                    }
                }
                else
                {
                    DivideAnimal(animal);
                }
            }
            CloseWagons();
            return ClosedWagons;
        }

            public void DivideAnimal(Animal animal)
            {
                bool ContinuDividing = EmptyWagonListCheck(animal);
                CheckWagonSearcher();

                if (ContinuDividing == false)
                {
                    // loop once over the next wagon and its animals 
                    for (int i = 0; i < 1; i++)
                    {
                        CheckWagon(animal);
                        AddingCheck(animal);
                    }
                }
            }

        private void AddingCheck(Animal animal)
        {
            if (WagonSpace == 10)
            {
                CloseWagons();
                AddWagon(animal);
            }
            else if(animal.Diet == Diet.Herbivore && WagonSpace >= 9 && animal.AnimalSize == AnimalSize.Normal)
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

        private void CheckWagon(Animal animal)
        {
            //Loop over the animals in the current wagon
            foreach (Animal wagonAnimal in Wagons[J].WagonAnimals)
            {
                if (wagonAnimal.Diet == Diet.Carnivore && animal.Diet == Diet.Carnivore)
                {
                    AddWagon(animal);
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
        }

        private void CheckWagonCarnivore(Animal animal)
        {
            foreach (Animal wagonAnimal in Wagons[J].WagonAnimals)
            {
                if(wagonAnimal.Diet == Diet.Carnivore)
                {
                    AddWagon(animal);
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
        }

        public void CheckWagonSearcher()
        {
            //If there are wagons check first if J is bigger or equal than the Wagons
            if (J >= Wagons.Count())
            {
                //If j is bigger or equal rest J back to 0
                J = 0;
            }
        }

        public bool EmptyWagonListCheck(Animal animal)
        {
            //If there are no wagons make a new one and add the Big hebivore in
            if (Wagons.Count == 0)
            {
                AddWagon(animal);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CloseWagons()
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
