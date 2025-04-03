namespace OOP
{
    public abstract class DynamicArray<T>
    {
        // Коды результатов
        public const int GET_ITEM_NIL = 0; // GetItem() не вызывалась
        public const int GET_ITEM_OK = 1; // GetItem() отработала нормально
        public const int GET_ITEM_ERR = 2; // Переданного индекса не оказалось в списке

        public const int RESIZE_NIL = 0; // Resize() не вызывалась
        public const int RESIZE_OK = 1; // Resize() отработала успешно
        public const int RESIZE_ERR = 2; // Количество элементов оказалось больше нового размера массива

        public const int APPEND_NIL = 0; // Append() не вызывалась
        public const int APPEND_OK = 1; // Append() отработала успешно
        public const int APPEND_ERR = 2; // Размер массива оказался слишком мал, чтобы вставить в него новый элемент

        public const int INSERT_NIL = 0; // Insert() не вызывалась
        public const int INSERT_OK = 1; // Insert() отработала успешно
        public const int INSERT_FULL = 2; // Массив оказался полным
        public const int INSERT_ERR = 3; // Индекс оказался вне границ массива

        public const int REMOVE_NIL = 0; // Remove() не вызывалась
        public const int REMOVE_OK = 1; // Remove() отработала нормально 
        public const int REMOVE_ERR = 2; // Индекс оказался вне границ массива
        public const int REMOVE_NONE = 3; // По указанному индексу не оказалось элемента

        // Конструктор
        // Постусловие: создан динамический массив
        public DynamicArray()
        {
        }

        // Запросы
        // Предусловие: список имеет длину >= index
        public abstract T GetItem(int index);

        public abstract int GetCount();

        public abstract int GetCapacity();

        // Команды
        // Постусловие: массив списка становится равным newSize
        public abstract void Resize(uint newSize);

        // Предусловие: массив не полон
        // Постусловие: в конце массива добавляется новый элемент
        public abstract void Append(T item);

        // Предусловие: массив не полон; указанный индекс в массиве существует
        // Постусловие: в указанный индекс вставляется новый элемент
        public abstract void Insert(T item, int index);

        // Предусловие: в массиве на указанном индексе есть элемент; в массиве нет указанного индекса
        // Постусловие: в массиве на указанном индексе пропадает элемент
        public abstract void Remove(int index);

        // запросы статусов
        public abstract int GetItemStatus(); // GET_ITEM_*
        public abstract int ResizeStatus(); // RESIZE_*
        public abstract int AppendStatus(); // APPEND_*
        public abstract int InsertStatus(); // INSERT_*
        public abstract int RemoveStatus(); // REMOVE_*
    }
}