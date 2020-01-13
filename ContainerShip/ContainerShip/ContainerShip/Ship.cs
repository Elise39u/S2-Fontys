using System;
using System.Collections.Generic;

namespace ContainerShip
{
    public class Ship
    {
        private int length;
        private int width;
        private List<Row> rows;
        private int maxWeight;
        private int currentWeight;

        public int Length { get => length; set => length = value; }
        public int Width { get => width; set => width = value; }
        public List<Row> Rows { get => rows; set => rows = value; }
        public int MaxWeight { get => maxWeight; set => maxWeight = value; }
        public int CurrentWeight { get => currentWeight; set => currentWeight = value; }

        public Ship(int length, int width, List<Row> rows, int maxWeight, int currentWeight)
        {
            Length = length;
            Width = width;
            Rows = rows;
            MaxWeight = maxWeight;
            CurrentWeight = currentWeight;
        }

        public int CalculateCurrentWeigth()
        {
            throw new NotImplementedException();
        }

        public int CalculateSideWeigth()
        {
            throw new NotImplementedException();
        }

        public string PlaceCargoList(List<Container> containers)
        {
            throw new NotImplementedException();
        }

        public string CalculateCargoWeight(List<Container> containers)
        {
            int totalCargoWeight = 0;

            foreach(Container container in containers)
            {
                totalCargoWeight += container.Weight;
            }

            int halfShipWeight = MaxWeight / 2;
            if (totalCargoWeight < halfShipWeight)
            {
                return "Cargo is too ligth";
            }
            else
            {
                return "Cargo Accepted";
            }
        }
    }
}
