using System;
using System.Collections.Generic;

namespace ContainerShip
{
    public class Place
    {
        private List<Container> containers;
        private int currentWeight;

        public List<Container> Containers { get => containers; set => containers = value; }
        public int CurrentWeight { get => currentWeight; set => currentWeight = value; }

        public Place(List<Container> containers, int currentWeight)
        {
            Containers = containers;
            CurrentWeight = currentWeight;
        }

        public string placeContainer(Container container)
        {
            throw new NotImplementedException();
        }
    }
}