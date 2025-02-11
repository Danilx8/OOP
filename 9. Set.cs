namespace OOP
{
    public abstract class ParentHashTable<T>
    {
        // Конструктор 
        // Постусловие: создана пустая хэш-таблица указанного размера
        public ParentHashTable<T> ParentHashTable(int maxSize);

        // Команды
        // Предусловие: таблица содержит передаваемое значение
        // Постусловие: из таблицы удаляется передаваемое значени
        public abstract void Remove(T value);
        
        // Запросы
        public abstract bool Get(T value); // Содержится ли значение value в таблице
        public abstract int Size(); // Количество элементов в таблице
        
        // Запросы статусов
        public abstract int GetRemoveStatus(); // успешно; указанного элемента в таблице не оказалось
    }
    
    public abstract class PowerSet<T>
    {
        // Конструктор
        // Постусловие: создано пустое множество указанного размера
        public PowerSet<T> PowerSet(int maxSize);
        
        // Команды
        // Предусловие: текущее количество элементов в таблице не превышает предела; в множестве нет элемента value
        // Постусловие: в таблицу добавляется новый элемент
        public abstract void Put(T value);

        // Запросы
        public abstract PowerSet<T> Intersection(PowerSet<T> set2);
        public abstract PowerSet<T> Union(PowerSet<T> set2);
        public abstract PowerSet<T> Difference(PowerSet<T> set2);
        public abstract PowerSet<T> IsSubset(PowerSet<T> set2);
        
        // Запросы стстусов
        public abstract int GetPutStatus(); // успешно; элемент уже в наличии; достигнут лимит количества элементов
                                            // множеств
        
    }
}