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