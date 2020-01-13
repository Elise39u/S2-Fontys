using NUnit.Framework;
using ContainerShip;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
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
        public void Can_A_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.cooleble, 4000);

            Assert.AreEqual(container.TypeContainer, TypeContainer.cooleble, "Container is not a cooleble");
            Assert.AreEqual(4000, container.Weight, "Container weight dind`t matched");
        }

        [Test]
        public void Can_A_TooHeavy_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.normal, 35000);
            
            Assert.IsNotNull(container, "A too heavy container has been made");
        }

        [Test]
        public void Can_A_TooLigth_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.normal, 2000);

            Assert.IsNotNull(container, "A too light container has been made");
        }

        [Test]
        public void Is_A_Cargo_TooLigth()
        {
            List<Container> containers = new List<Container>();

            for(int i = 0; i < 15; i ++)
            {
                Container container = new Container(50, 50, TypeContainer.normal, 3500);
            }

            List<Row> rows = new List<Row>();
            Ship ship = new Ship(100, 100, rows, 230000, 0);

            string weightCheck = ship.CalculateCargoWeight(containers);
            Assert.AreEqual("Cargo is too ligth", weightCheck, "Something went wrong with in the check");
        }
    }
}