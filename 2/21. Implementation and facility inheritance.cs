using System;
using System.Collections.Generic;

namespace OOP
{
    // Наследование реализации
    // Существует определённый базовый класс, покрывающий весь базовый функционал самостоятельно
    // Он служит базой для создания всех ролей в системе и не должен использоваться самостоятельно
    // По такой схеме работает, например, Entity Framework в .NET
    public class User {
        public void Login(string credentials)
        {
            // какая-то логика
        }

        public void Logout()
        {
            // какая-то логика
        }
    }
    
    // Наследник реализует свою отдельную логику
    public class Manager : User
    {
        public void CreateTask(string task)
        {
            // какая-то логика
        }
    }
    
    // Льготное наследование
    // У нас есть базовый класс обработчиков событий, в котором изначально реализованы:
    public class Event
    {
        // Общее хранилище данных
        public Dictionary<string, string> DataStore;
        
        // Регистр обработчиков событий
        public Dictionary<string, Object> HandlersRegister;
        
        // Регистр продюсеров событий 
        public Dictionary<string, Object> ProducersRegister;
    }
    
    // Наследники могут добавлять какую-то особую логику, но основные инструменты уже реализованы в предке
    public class PurchasesHandler : Event {}
}