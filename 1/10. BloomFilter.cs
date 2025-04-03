namespace OOP
{
    public abstract class BloomFilter<T>
    {
        // Конструктор
        // Постусловие: создаётся фильтр блюма длиной fLen
        public BloomFilter(int fLen)
        {
        }

        // Команды
        // Предусловие: значения нет в фильтре
        // Постусловие: новое значение добавлено в фильтр
        public abstract void Add(T value);

        // Запросы
        public abstract bool IsValue(T value); // проверка принадлежит ли значение фильтру
        public abstract int Size(); // возврат размера фильтра (указанного при создании)

        // Дополнительные запросы
        public abstract int GetAddStatus(); // успех; значение возможно уже добавлено
    }
}