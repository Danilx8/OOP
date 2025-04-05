using System;

namespace OOP
{
    // В C# по дефолту все методы класса определяются как закрытые. 
    // Чтобы, наоборот, открыть метод класса для переопределения, применяют ключевое слово virtual
    // Выходит что-то типа такого:
    public class Parent {
        public virtual void OpenMethod()
        {
            Console.WriteLine("Этот метод имеет ключевое слово virtual, поэтому он открыт для переопределения");
        }

        public void ClosedMethod()
        {
            Console.WriteLine("Этот метод не имеет ключевое слово virtual, поэтому он закрыт для переопределения");
        }
    }

    public class Child : Parent
    {
        public override void OpenMethod()
        {
            Console.WriteLine("Дочерний класс переопределил открытый метод");
        }

        // Ошибка: There is no suitable method to overwrite
        // Этот метод нельзя переопределить
        // public override void ClosedMethod()
        // {
        //     
        // }
    }
}