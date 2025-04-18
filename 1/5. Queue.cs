namespace OOP
{
    public abstract class Queue<T>
    {
        // Конструктор
        // Постусловие: создана пустая очередь
        public Queue()
        {
        }

        // Запросы
        public abstract int Size();

        // Предусловие: индекс i лежит внутри очереди 
        public abstract T Get(int i);

        // Команды
        // Предусловие: индекс лежит внутри очереди
        // Постусловие: справа от указанного индекса помещается новый элемент
        public abstract void PutRight(int i, T item);

        // Предусловие: индекс лежит внутри очереди
        // Постусловие: слева от указанного индекса помещается новый элемент
        public abstract void PutLeft(int i, T item);

        // Предусловие: индекс i лежит внутри очереди
        // Постусловие: элемент по указанному индексу удаляется 
        public abstract void Remove(int i);

        // Предусловие: очередь не пустая
        // Постусловие: в начале очереди удаляется элемент
        public abstract T Dequeue();

        // Предусловие: длина очереди меньше её максимума
        // Постусловие: в конец очереди помещается новый элемент
        public abstract void Enqueue(T item);

        public abstract int GetGetStatus(); // успешно; индекс за пределами очереди
        public abstract int GetPutRightStatus(); // успешно; индекс за пределами очереди; длина очереди равна максимуму
        public abstract int GetPutLeftStatus(); // успешно; индекс за пределами очереди; длина очереди равна максимуму
        public abstract int GetRemoveStatus(); // успешно; индекс за пределами очереди
        public abstract int GetDequeueStatus(); // успешно; очередь пустая
        public abstract int GetEnqueueStatus(); // успешно; длина очереди равна максимуму
    }
}