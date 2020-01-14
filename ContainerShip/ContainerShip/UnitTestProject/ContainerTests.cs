using ContainerShip;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public class ContainerTests
    {
        [Test]
        public void Can_A_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.cooleble, 4000);

            Assert.AreEqual(container.TypeContainer, ContainerType.cooleble, "Container is not a cooleble");
            Assert.AreEqual(4000, container.Weight, "Container weight dind`t matched");
        }

        [Test]
        public void Can_A_TooHeavy_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.normal, 35000);

            Assert.IsNotNull(container, "A too heavy container has been made");
        }

        [Test]
        public void Can_A_TooLigth_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.normal, 2000);

            Assert.IsNotNull(container, "A too light container has been made");
        }

        [Test]
        public void Can_A_Normal_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.normal, 4500);

            Assert.AreEqual(ContainerType.normal, container.TypeContainer, "Container is not normal");
        }

        [Test]
        public void Can_A_Cooleble_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.cooleble, 4500);

            Assert.AreEqual(ContainerType.cooleble, container.TypeContainer, "Container is not cooleble");
        }

        [Test]
        public void Can_A_Valueble_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.valueble, 4500);

            Assert.AreEqual(ContainerType.valueble, container.TypeContainer, "Container is not valueble");
        }

        [Test]
        public void Can_A_Valueble_Coolble_Container_Be_Created()
        {
            Container container = new Container(20, 20, ContainerType.valuebleCoolble, 4500);

            Assert.AreEqual(ContainerType.valuebleCoolble, container.TypeContainer, "Container is not valueble coolble");
        }

        [Test]
        public void Can_A_Cargo_Be_Genarated()
        {
            List<Container> containers = new List<Container>();
            Container containerObj = new Container(0, 0, ContainerType.normal, 0);

            containers = containerObj.GenerateNewCargo(50);
            Assert.AreEqual(50, containers.Count(), "something went wrong in the makeing of the cargo");
        }
    }
}
