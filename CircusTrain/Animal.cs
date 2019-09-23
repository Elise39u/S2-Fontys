using System;

public class Animal
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

    public Animal()
    {
        public Diet Diet { get; private set; }
        public AnimalSize AnimalSize { get; private set; }
    }
}
