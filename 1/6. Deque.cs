namespace OOP
{
    public abstract class ParentQueue<T>
    {
        // Конструктор
        public ParentQueue()
        {
        }

        // Команды
        // предусловие: очередь не пуста;
        // постусловие: из головы очереди удалён элемент
        public abstract T RemoveFront();

        // Постусловие: в конец очереди помещается новый элемент
        public abstract void AddTail(T item);

        // Запросы
        // предусловие: очередь не пуста
        public abstract T Get(); // получить элемент из головы очереди; 

        public abstract int Size(); // текущий размер очереди

        // запросы статусов (возможные значения статусов)
        public abstract int GetRemoveFrontStatus(); // успешно; очередь пуста
        public abstract int GetGetStatus(); // успешно; очередь пуста
    }

    public abstract class NewQueue<T> : ParentQueue<T>
    {
        // Конструктор
        public NewQueue()
        {
        }
    }

    public abstract class Deque<T> : ParentQueue<T>
    {
        // Конструктор
        public Deque()
        {
        }

        // Команды
        // Постусловие: в голову очереди помещается новый элемент 
        public abstract void AddHead(T item);

        // Предусловие: очередь не пуста
        // Постусловие: из хвоста очереди удален элемент
        public abstract T RemoveTail();

        // запросы статусов (возможные значения статусов)
        public abstract int GetRemoveTailStatus(); // успешно; очередь пуста
    }
}