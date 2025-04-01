using System;

namespace OOP
{
    // Родительский класс, метод которого реализуют классы-наследники
    public interface IAnimal
    {
        void Speak();
    }

    // Классы-наследники с конкретной реализаций
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Meow!");
        }
    }

    // класс, который динамически связывает внутреннюю переменную pet с реализацией класса IAnimal, определяемой в рантайме
    public class PetOwner
    {
        private IAnimal pet;
        
        // в качестве параметра IAnimal может идти или класс Dog, или Cat (или любой другой, реализующий класс IAnimal)
        public PetOwner(IAnimal pet)
        {
            this.pet = pet;
        }

        public void PetPet()
        {
            pet.Speak();
        }
    }

    public class Main
    {
        public Main()
        {
        }

        // С помощью инструментов рефлексии рантайм создаёт (или не создаёт) соответствующий класс,
        // реализующий класс IAnimal (или выбрасывает ошибку)
        public static void Example(String[] args)
        {
            var pet = Activator.CreateInstance(Type.GetType(args[0]) ?? typeof(Object));

            // Создаём класс владельца (используя приведение классов)
            PetOwner owner = new PetOwner((IAnimal)pet);
            
            // В зависимости от того, что было передано в качестве аргумента программы будет выведено или Woof или Meow
            // Вместо рефлексии здесь может быть также DI 
            owner.PetPet();
        }
    }
}