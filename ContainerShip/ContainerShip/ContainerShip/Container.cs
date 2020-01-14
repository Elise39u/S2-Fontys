using System;
using System.Collections.Generic;

namespace ContainerShip
{
    public enum ContainerType
    {
        valueble,
        normal,
        cooleble,
        valuebleCoolble
    };

    public class Container
    {
        private int width;
        private int height;
        private ContainerType typeContainer;
        private int weight;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public ContainerType TypeContainer { get => typeContainer; set => typeContainer = value; }
        public int Weight { get => weight; set => weight = value; }

        public Container(int width, int height, ContainerType typeContainer, int weight)
        {
            CheckContainerWeight(width, height, typeContainer, weight);
        }

        public string CheckContainerWeight(int width, int height, ContainerType typeContainer, int weight)
        {
            if(weight < 4000)
            {
                return "Container is too ligth";
            }
            else if(weight > 30000)
            {
                return "Container is too heavy";
            }
            else
            {
                CreateNewContainer(width, height, typeContainer, weight);
                return "Container is accepted";
            }
        }

        private void CreateNewContainer(int width, int height, ContainerType typeContainer, int weight)
        {
            Width = width;
            Height = height;
            TypeContainer = typeContainer;
            Weight = weight;
        }

        public List<Container> GenerateNewCargo(int wantedContainers)
        {
            List<Container> containers = new List<Container>();
            Random rnd = new Random();

            for (int i = 0; i < wantedContainers; i ++)
            {
                Container container = new Container(rnd.Next(0, 100), rnd.Next(0, 100), (ContainerType)rnd.Next(0,4), 0);
                containers.Add(container);
            }

            return containers;
        }
    }
}