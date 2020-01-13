using NUnit.Framework;
using ContainerShip;
using System.Collections.Generic;

namespace Tests
{
    public class ShipTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Can_A_Ship_Be_Created()
        {
            List<Row> rows = new List<Row>();
            Ship ship = new Ship(6, 4, rows, 10000, 0);

            Assert.IsNotNull(ship, "Ship object is empty");
            Assert.AreEqual(6, ship.Length, "Length doesn`t match");
            Assert.AreEqual(4, ship.Width, "Width doesn`t match");
            Assert.AreEqual(10000, ship.MaxWeight, "Max weight doesn`t match");
        }

        [Test]
        public void Is_A_Cargo_TooLigth()
        {
            List<Container> containers = new List<Container>();

            for(int i = 0; i < 15; i ++)
            {
                Container container = new Container(50, 50, TypeContainer.normal, 3500);
                containers.Add(container);
            }

            List<Row> rows = new List<Row>();
            Ship ship = new Ship(100, 100, rows, 230000, 0);

            string weightCheck = ship.CalculateCargoWeight(containers);
            Assert.AreEqual("Cargo is too ligth", weightCheck, "Something went wrong with in the check");
        }

        [Test]
        public void Is_A_Cargo_TooHeavy()
        {
            List<Container> containers = new List<Container>();

            for(int i = 0; i < 10; i ++)
            {
                Container container = new Container(50, 50, TypeContainer.cooleble, 10000);
                containers.Add(container);
            }

            List<Row> rows = new List<Row>();
            Ship ship = new Ship(100, 100, rows, 80000, 0);

            string weightCheck = ship.CalculateCargoWeight(containers);
            Assert.AreEqual("Cargo weight is bigger than the max weight of the ship", weightCheck, "Something went wrong with in the check");
        }
    }
}