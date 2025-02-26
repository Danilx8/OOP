using System;
using System.Collections.Generic;

namespace OOP
{
    // Это оригинальный класс. Он определеяет оригинальную сущность Car
    // Этот класс расширен классом Engine по свойству композиции
    // Класс Car содержит (has-a) класс Engine
    public class Car
    {
        public Engine Engine;
        public virtual void Drive()
        {
            Console.WriteLine("Машина в суперпозиции");
        }
    }

    // Класс, наследующий родительский класс Car
    public class RussianCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("Машина сломалась");
        }
    }

    // Класс, наследующий родительский класс Car
    public class JapaneseCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("Машина поехала");
        }
    }

    // Это класс, которым можно расширить класс посредством композиции
    public class Engine
    {
        public void Ignite()
        {
            Console.WriteLine("Двигатель заработал");
        }
    }
    
    public class Icp
    {
        public static void Main()
        {
            // Создаю список элементов классов RussianCar и JapaneseCar, обобщённые родительским классом Car
            List<Car> cars = new List<Car>
            {
                new RussianCar(),
                new JapaneseCar()
            };

            foreach (Car car in cars)
            {
                // Инициализация элементов композиции класса Engine
                car.Engine = new Engine();
                // Использование элемента композиции класса Engine
                car.Engine.Ignite();
                // Использование общего интерфейса Drive для обоих объектов вызывает различный результат
                // В случае класса RussianCar выводится "Машина сломалась"
                // В случае класса JapaneseCar выводится "Машина поехала"
                // Такое поведение - это демонстрация свойства полиморфизма
                car.Drive();
            }
        }
    }
}