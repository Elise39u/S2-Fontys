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
        private int leftSideWeight;
        private int rightSideWeight;

        public Random Rnd = new Random();
        public Row rowObj = new Row(0, new List<Place>());

        public int Length { get => length; set => length = value; }
        public int Width { get => width; set => width = value; }
        public List<Row> Rows { get => rows; set => rows = value; }
        public int MaxWeight { get => maxWeight; set => maxWeight = value; }
        public int LeftSideWeight { get => leftSideWeight; set => leftSideWeight = value; }
        public int RightSideWeight { get => rightSideWeight; set => rightSideWeight = value; }
        public int CurrentWeight { get => currentWeight; set => currentWeight = value; }

        public Ship(int length, int width, List<Row> rows, int maxWeight, int currentWeight)
        {
            Length = length;
            Width = width;
            Rows = rows;
            MaxWeight = maxWeight;
            CurrentWeight = currentWeight;
        }


        public void CreateShipRows()
        {
            rows = rowObj.GenereateLayout(Width, Length);
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
            containers = CheckIfContainerListIsNul(containers);

            string weightCheck = CalculateCargoWeight(containers);
            if (weightCheck.Contains("Accepted"))
            {
                return "";
            }
            else
            {
                return weightCheck;
            }
        }

        public List<Container> CheckIfContainerListIsNul(List<Container> containers)
        {
            if (containers.Count == 0)
            {
                Container container = new Container(50, 50, ContainerType.normal, 10000);
                containers = container.GenerateNewCargo(Rnd.Next(0, 100));
            }

            return containers;
        }

        public string CalculateCargoWeight(List<Container> containers)
        {
            int totalCargoWeight = CaclulateCargoList(containers);

            if (totalCargoWeight > MaxWeight)
            {
                return "Cargo weight is bigger than the max weight of the ship";
            }
            else
            {
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

        private static int CaclulateCargoList(List<Container> containers)
        {
            int totalCargoWeight = 0;

            foreach (Container container in containers)
            {
                totalCargoWeight += container.Weight;
            }

            return totalCargoWeight;
        }
    }
}
