using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain.classes
{
    enum Diet
    {
        Carnivore,
        Herbivore,
        Omnivore
    }

    enum AnimalSize
    {
        Small = 1,
        Normal = 3,
        Big = 5
    }


    class Animal
    {
        public Diet Diet { get; private set; }
        public AnimalSize AnimalSize { get; private set; }

        public Animal(AnimalSize animalSize, Diet diet)
        {
            AnimalSize = animalSize;
            Diet = diet;
        }

        public Animal()
        {

        }
    }
}
