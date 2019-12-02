using NUnit.Framework;
using CircusTrain.classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    public class Tests
    {
        public Train Train;
        public List<Animal> Animals;
        public List<Wagon> wagons;

        [SetUp]
        public void Setup()
        {
            Train = new Train();
            Animals = new List<Animal>();
        }

        public void SetupVars()
        {

        }

        [Test]
        public void CarnivoreOnlyTest()
        {
            for (int i = 0; i < 15; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            }

            for (int i = 0; i < 2; i++)
            {
                Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            }

            for (int i = 0; i < 10; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            }

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(27, wagons.Count());
        }

        
        [Test]
        public void HebivoreOnlyTest()
        {
            for (int i = 0; i < 25; i++)
            {
                Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            }

            for (int i = 0; i < 5; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            }

            for (int i = 0; i < 15; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(10, wagons.Count());
        }

        [Test]
        public void BigCarnavoreOnlyTwoWagonsTest()
        {

            for (int i = 0; i < 2; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void BigCarnavoreOnlyMoreWagonsTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(5, wagons.Count());
        }

        [Test]
        public void NormalCarnavoreOnlyTwoWagonsTest()
        {
            for (int i = 0; i < 2; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void NormalCarnavoreOnlyMoreWagonsTest()
        {
            for (int i = 0; i < 20; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(20, wagons.Count());
        }

        [Test]
        public void SmallCarnavoreOnlyTwoWagonsTest()
        {
            for (int i = 0; i < 2; i++)
            {
               Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void SmallCarnavoreOnlyMoreWagonsTest()
        {
            for (int i = 0; i < 10; i++)
            {
                Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(10, wagons.Count());
        }

        [Test]
        public void BigHebivoreOnlyOneWagonTest()
        {
            for (int i = 0; i < 2; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(1, wagons.Count());
        }

        [Test]
        public void SmallHebivorseOneWagonTest()
        {
            for (int i = 0; i < 10; i++)
            {
                Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(1, wagons.Count());
        }

        [Test]
        public void NormalHebivoreOnlyOneWagonTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(1, wagons.Count());
        }

        [Test]
        public void SmallHebivorseMoreWagonsTest()
        {
            for (int i = 0; i < 25; i++)
            {
                Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(3, wagons.Count());
        }

        [Test]
        public void BigHebivoreMoreWagonsTest()
        {
            for (int i = 0; i < 12; i++)
            {
                Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(6, wagons.Count());
        }

        [Test]
        public void NormalHebivoreMoreWagonsTest()
        {
            for (int i = 0; i < 10; i++)
            {
                Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            }
            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(4, wagons.Count());
        }

        [Test]
        public void RandomAnimalListTest1()
        {

            Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(11, wagons.Count());
        }

        [Test]
        public void RandomAnimalListTest2()
        {
            Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(4, wagons.Count());
        }

        [Test]
        public void RandomAnimalListTest3()
        {
            Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(6, wagons.Count());
        }

        [Test]
        public void RandomAnimalListTest4()
        {
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void RandomAnimalListTest5()
        {
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void H5AndC3OnlyTest()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
             
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(3, wagons.Count());
        }

        [Test]
        public void H5AndC3OnlyTestOneOfEach()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(1, wagons.Count());
        }

        [Test]
        public void H5AndC3OnlyTestTwoOfEach()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void SmallAndMediumCarnivoreOneOfEach()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void SmallAndMediumCarnivoreMoreOfEach()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(6, wagons.Count());
        }

        [Test]
        public void SmallHebivoreAndCarnivoreOnlyOne()
        {
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void SmallHebivoreAndCarnivoreTogether()
        {
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(6, wagons.Count());
        }

        [Test]
        public void MediumHebivoreAndCarnivoreOneofEach()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(2, wagons.Count());
        }

        [Test]
        public void MediumHebivoreAndCarnivore()
        {
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));

            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            Animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));

            List<Wagon> wagons = Train.DivideAnimals(Animals);

            Assert.AreEqual(4, wagons.Count());
        }
    }
}