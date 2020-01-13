using ContainerShip;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class ContainerTests
    {
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
        public void Can_A_Normal_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.normal, 4500);

            Assert.AreEqual(TypeContainer.normal, container.TypeContainer, "Container is not normal");
        }

        [Test]
        public void Can_A_Cooleble_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.cooleble, 4500);

            Assert.AreEqual(TypeContainer.cooleble, container.TypeContainer, "Container is not cooleble");
        }

        [Test]
        public void Can_A_Valueble_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.valueble, 4500);

            Assert.AreEqual(TypeContainer.valueble, container.TypeContainer, "Container is not valueble");
        }

        [Test]
        public void Can_A_Valueble_Coolble_Container_Be_Created()
        {
            Container container = new Container(20, 20, TypeContainer.valuebleCoolble, 4500);

            Assert.AreEqual(TypeContainer.valuebleCoolble, container.TypeContainer, "Container is not valueble coolble");
        }
    }
}
