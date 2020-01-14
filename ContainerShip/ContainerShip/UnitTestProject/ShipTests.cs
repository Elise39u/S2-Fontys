using NUnit.Framework;
using ContainerShip;
using System.Collections.Generic;
using System;
using System.Linq;

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
                Container container = new Container(50, 50, ContainerType.normal, 3500);
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
                Container container = new Container(50, 50, ContainerType.cooleble, 10000);
                containers.Add(container);
            }

            List<Row> rows = new List<Row>();
            Ship ship = new Ship(100, 100, rows, 80000, 0);

            string weightCheck = ship.CalculateCargoWeight(containers);
            Assert.AreEqual("Cargo weight is bigger than the max weight of the ship", weightCheck, "Something went wrong with in the check");
        }

        [Test]
        public void Can_A_Big_Cargo_Be_Placed()
        {
            List<Container> containers = new List<Container>();
            int containerWeight = 0;

            for(int i = 0; i < 65; i++)
            {
                Container container = new Container(50, 50, ContainerType.normal, 30000);
                containers.Add(container);
                containerWeight += container.Weight;
            }

            List<Row> rows = new List<Row>();
            Ship ship = new Ship(4, 4, rows, 120000, 0);
            
            bool weightCheck = containerWeight >= (ship.Width * ship.Length) * 120000;

            Assert.AreEqual(true, weightCheck, "Containers can be placed");
        }

        [Test]
        public void Can_A_Random_Cargo_Be_Genarated()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            List<Container> containers = new List<Container>();
            Container containerObj = new Container(0, 0, ContainerType.normal, 0);

            containers = containerObj.GenerateNewCargo(randomNumber);
            Assert.AreEqual(randomNumber, containers.Count(), "something went wrong in the makeing of the cargo");
        }

        [Test]
        public void Is_A_EmptyContainerList_Allowed()
        {
            List<Container> containers = new List<Container>();
            List<Row> rows = new List<Row>();

            Assert.IsEmpty(containers, "There is something inside the container list");

            Ship ship = new Ship(0, 0, rows, 1000000, 0);
            containers = ship.CheckIfContainerListIsNul(containers);

            Assert.IsNotEmpty(containers, "Found an empty cargo list");
        }

        [Test]
        public void Can_A_LayOut_Be_Generated()
        {
            List<Row> rows = new List<Row>();
            Ship ship = new Ship(4, 5, rows, 1000000, 0);

            Assert.IsEmpty(rows, "There is something inside the rows List");

            ship.CreateShipRows();

            Assert.AreEqual(4, ship.Rows.Count(), "row count dindt match");
            Assert.AreEqual(5, ship.Rows[0].Places.Count(), "place count dindt match");
        }
    }
}