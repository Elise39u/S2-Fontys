using NUnit.Framework;
using CircusTrain.classes;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarnivoreOnlyTest()
        {
            Train train = new Train();
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < 15; i++)
            {
                animals.Add(new Animal(AnimalSize.Normal, Diet.Carnivore));
            }

            for (int i = 0; i < 2; i++)
            {
                animals.Add(new Animal(AnimalSize.Small, Diet.Carnivore));
            }

            for (int i = 0; i < 10; i++)
            {
                animals.Add(new Animal(AnimalSize.Big, Diet.Carnivore));
            }

            List<Wagon> wagons = train.DivideAnimals(animals);

            Assert.AreEqual(27, wagons.Count());
        }

        [Test]
        public void HebivoreOnlyTest()
        {
            Train train = new Train();
            List<Animal> animals = new List<Animal>();
            for (int i = 0; i < 25; i++)
            {
                animals.Add(new Animal(AnimalSize.Small, Diet.Herbivore));
            }

            for (int i = 0; i < 5; i++)
            {
                animals.Add(new Animal(AnimalSize.Big, Diet.Herbivore));
            }

            for (int i = 0; i < 15; i++)
            {
                animals.Add(new Animal(AnimalSize.Normal, Diet.Herbivore));
            }
            List<Wagon> wagons = train.DivideAnimals(animals);

            Assert.AreEqual(10, wagons.Count());
        }
    }
}