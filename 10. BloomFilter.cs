namespace OOP
{
    public abstract class BloomFilter<T>
    {
        // Конструктор
        // Постусловие: создаётся битовый массив длиной fLen
        public abstract BloomFilter<T> BloomFilter(int fLen);
        
        // Команды
        // Предусловие: размер фмльтра не достиг лимита
        // Постусловие: новое значение добавлено в фильтр
        public abstract void Add(T value);
        
        // Запросы
        public abstract bool IsValue(T value); // проверка принадлежит ли значение фильтру
        public abstract int Size(); // возврат размера фильтра (указанного при создании)
        
        // Дополнительные запросы
        public abstract int GetAddStatus(); // успех; достигнут лимит; значение возможно уже добавлено
    }
}