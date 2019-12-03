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
        public bool CarniVoreAddCheck = false;
        public bool SameSizeCheck = false;
        public bool AddBigHebivore = false;

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
                    DivideCarnivoreAnimal(animal);
                }
                //Check if the animal is a big Hebivore 
                else if (animal.Diet == Diet.Herbivore && animal.AnimalSize == AnimalSize.Big)
                {
                    DivideAnimal(animal);
                }
                else if (animal.Diet == Diet.Carnivore && animal.AnimalSize == AnimalSize.Small)
                {
                    DivideCarnivoreAnimal(animal);
                }
                else
                {
                    DivideAnimal(animal);
                }
            }
            CloseWagons();
            return ClosedWagons;
        }

        private void DivideCarnivoreAnimal(Animal animal)
        {
            bool ContinuDividing = EmptyWagonListCheck(animal);

            if (ContinuDividing == false)
            {
                CheckWagonSearcher();
                DivideAnimal(animal);
            }
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
            if (WagonSpace >= 10 ||
                animal.Diet == Diet.Herbivore && WagonSpace >= 9 && animal.AnimalSize == AnimalSize.Normal
                || animal.Diet == Diet.Herbivore && WagonSpace >= 6 && animal.AnimalSize == AnimalSize.Big)
            {
                AddNewWagonWithAnimal(animal);
            }
            else if (AddBigHebivore == true)
            {
                AddBigHebivore = false;
                Wagons[J].AddAnimal(animal);
            }
            else if (CarniVoreAddCheck == true)
            {
                AddNewWagonWithCarnivore(animal);
            }
            else if (SameSizeCheck == true)
            {
                ChangeSizeCheck(animal);
            }
            else
            {
                Wagons[J].AddAnimal(animal);
            }
            WagonSpace = 0;
            J++;
        }

        private void AddNewWagonWithCarnivore(Animal animal)
        {
            CarniVoreAddCheck = false;
            AddWagon(animal);
        }

        private void AddNewWagonWithAnimal(Animal animal)
        {
            CloseWagons();
            AddWagon(animal);
        }

        private void ChangeSizeCheck(Animal animal)
        {
            SameSizeCheck = false;
            CloseWagons();
            AddWagon(animal);
        }

        private void CheckWagon(Animal animal)
        {
            foreach(Animal wagonAnimal in Wagons[J].WagonAnimals)
            {
                if(wagonAnimal.Diet == Diet.Carnivore || animal.Diet == Diet.Carnivore)
                {
                    DietCheck(animal, wagonAnimal);
                }
                else
                {
                    CheckWagonSpace(wagonAnimal);
                }
            }
        }

        private void DietCheck(Animal animal, Animal wagonAnimal)
        {
            if (wagonAnimal.Diet == animal.Diet)
            {
                CarniVoreAddCheck = true;
            }
            else
            {
                SizeCheck(animal, wagonAnimal);
            }
        }

        private void SizeCheck(Animal animal, Animal wagonAnimal)
        {
            if (wagonAnimal.AnimalSize == animal.AnimalSize
                || wagonAnimal.AnimalSize > animal.AnimalSize && wagonAnimal.Diet == Diet.Carnivore)
            {
                SameSizeCheck = true;
            }
            else
            {
                CheckWagonSpace(wagonAnimal);
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

        public void CheckWagonSpace(Animal animal)
        {
            if (WagonSpace == 11)
            {
                
            }
            else if(WagonSpace == 10 && animal.Diet == Diet.Herbivore && 
                animal.AnimalSize == AnimalSize.Big)
            {
                AddBigHebivore = true;
            }
            else
            {
                WagonSpace = WagonObj.CalculateWagonSize(animal, WagonSpace);
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
