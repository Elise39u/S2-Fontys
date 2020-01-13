using System;

namespace ContainerShip
{
    public enum TypeContainer
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
        private TypeContainer typeContainer;
        private int weight;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public TypeContainer TypeContainer { get => typeContainer; set => typeContainer = value; }
        public int Weight { get => weight; set => weight = value; }

        public Container(int width, int height, TypeContainer typeContainer, int weight)
        {
            CheckContainerWeight(width, height, typeContainer, weight);
        }

        public string CheckContainerWeight(int width, int height, TypeContainer typeContainer, int weight)
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

        private void CreateNewContainer(int width, int height, TypeContainer typeContainer, int weight)
        {
            Width = width;
            Height = height;
            TypeContainer = typeContainer;
            Weight = weight;
        }
    }
}