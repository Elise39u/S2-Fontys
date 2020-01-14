using System;
using System.Collections.Generic;

namespace ContainerShip
{
    public class Row
    {
        private int length;
        private List<Place> places;

        public int Length { get => length; set => length = value; }
        public List<Place> Places { get => places; set => places = value; }

        public Row(int length, List<Place> places)
        {
            Length = length;
            Places = places;
        }

        public List<Row> GenereateLayout(int width, int length)
        {
            List<Row> rows = new List<Row>();

            for(int i = 0; i < length; i ++)
            {
                List<Place> spaces = new List<Place>();
                for (int num = 0; num < width; num++)
                {
                    List<Container> containers = new List<Container>();
                    spaces.Add(new Place(containers, 0));
                }
                rows.Add(new Row(width, spaces));
            }

            return rows;
        }

        public Place fillPlace(Place place, Container container)
        {
            throw new NotImplementedException();
        }

        public int CalculatePlaceWeight(Place place)
        {
            throw new NotImplementedException();
        }
    }
}