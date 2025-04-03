namespace OOP
{
    public abstract class NativeDictionary<T>
    {
        // Конструктор
        // Постусловие: создан ассоциативный массив размера size
        public NativeDictionary(int size)
        {
        }

        // Команды
        // Предусловие: размер словаря менее лимита
        // Постусловие: значение словаря по ключу key становится равно value
        public abstract void Put(string key, T value);

        // Запросы
        // Предусловие: в словаре существует значение по ключу key 
        public abstract T Get(string key);
        public abstract bool IsKey(string key); // true - ключ имеется; иначе - false

        // Запросы статусов
        public abstract int GetPutStatus(); // добавлен новый элемент; значение ключа обновлено;

        // новое значение вышло за пределы словаря
        public abstract int GetGetStatus(); // успешно; указанный ключ не существует в словаре
    }
}