using System;

namespace OOP
{
    // Родительский класс. Реализует метод ParseToString
    public class Parser
    {
        public virtual string ParseToString(string input)
        {
            return "Входные текстовые данные распаршены";
        }
    }

    // Класс, наследующий класс Parser
    public class JsonParser : Parser
    {
        // Здесь класс JsonParser задаёт более специализированный случай родителя (парсинг JSON) 
        public override string ParseToString(string input)
        {
            return "Входные данные в формате JSON, распаршенные другим способом";
        }
        
        // Метод IsCorrectJson расширяет родительский класс, задавая более общий случай родителя
        public bool IsCorrectJson(string input)
        {
            return false;
        }
    }
}