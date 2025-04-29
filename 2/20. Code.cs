using System;

namespace OOP
{
    // Наследование с функциональной вариацией
    public class VariatingClass
    {
        private string _unSerializableProperty;

        // В базовом классе уже реализован метод ToString.
        // Класс-наследник меняет логику работы метода на новую, исключая значение поля из сериализации
        // В реальном опыте это, разумеется, лучше выполнять с помощью присваивания атрибутов свойствам, которые мы не хотим сериализовать
        public override string ToString()
        {
            string tmp = _unSerializableProperty;
            _unSerializableProperty = null;
            string result = base.ToString();
            _unSerializableProperty = tmp;
            return result;
        }
    }

    // Наследование с конкретизацией
    // Базовый абстрактный класс часов с методом Time(), возвращающим текущее время
    public abstract class Watch
    {
        public abstract TimeSpan Time();
    }

    // Солнечные часы требуют особой логики для определения времени в данный момент
    public class SunDial : Watch
    {
        public override TimeSpan Time()
        {
            Console.WriteLine("Смотрим, куда падает тень…");
            return new TimeSpan();
        }
    }

    // Наручные часы требуют другой логики, отличной от солнечных
    public class HandWatch : Watch
    {
        public override TimeSpan Time()
        {
            Console.WriteLine("Смотрим, куда показывают стрелки на циферблате");
            return new TimeSpan();
        }
    }

    //Структурное наследование
    public class ModelAttribute : Attribute
    {
        private string _name;
        
        public ModelAttribute(string name)
        {
            _name = name;
        }

        public Object Get(string condition)
        {
            // Логика получения объекта с условием согласно выбранной ОРМ
            return new Object();
        }
        
        // И такие же методы можно добавить для других операций с СУБД
    }
}