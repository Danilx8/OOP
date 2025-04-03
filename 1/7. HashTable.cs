namespace OOP
{
    public abstract class HashTable<T>
    {
        public HashTable(int maxSize)
        {
        }

        // Команды
        // Предусловие: текущее количество элементов в таблице не превышает предела
        // Постусловие: в таблицу добавляется новый элемент
        public abstract void Put(T value);

        // Предусловие: таблица содержит передаваемое значение
        // Постусловие: из таблицы удаляется передаваемое значени
        public abstract void Remove(T value);

        // Запросы
        public abstract bool Find(T value); // Содержится ли значение value в таблице

        public abstract int Size(); // Количество элементов в таблице

        // Запросы статусов
        public abstract int GetPutStatus(); // успешно; таблица заполнена; коллизия разрешилась неудачно
        public abstract int GetRemoveStatus(); // успешно; указанного элемента в таблице не оказалось
    }
}