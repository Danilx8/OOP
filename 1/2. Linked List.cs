namespace OOP
{
    public abstract class LinkedList<T>
    {
        public const int HEAD_NIL = 0; // Head() не вызывалась
        public const int HEAD_OK = 1; // Head() отработала нормально
        public const int HEAD_ERR = 2; // Список пуст

        public const int TAIL_NIL = 0; // Tail() не вызывалась
        public const int TAIL_OK = 1; // Tail() отработала нормально
        public const int TAIL_ERR = 2; // список пуст

        public const int GET_NIL = 0; // Get() не вызывалась
        public const int GET_OK = 1; // Get() отработала нормально
        public const int GET_ERR = 2; // Список пуст
        
        public const int RIGHT_NIL = 0; // Right() не вызывалась 
        public const int RIGHT_OK = 1; // Right() отработала нормально
        public const int RIGHT_ERR = 2; // курсор в хвосте
        public const int RIGHT_EMPTY = 3; // список пуст
        
        public const int PUT_RIGHT_NIL = 0; // PutRight() не вызывалась
        public const int PUT_RIGHT_OK = 1; // PutRight() отработала нормально
        public const int PUT_RIGHT_ERR = 2; // курсор в хвосте
        public const int PUT_RIGHT_EMPTY = 3; // Список пуст
        
        public const int PUT_LEFT_NIL = 0; // PutLeft() не вызывалась
        public const int PUT_LEFT_OK = 1; // PutLeft() отработала нормально
        public const int PUT_LEFT_ERR = 2; // курсор в голове
        public const int PUT_LEFT_EMPTY = 3; // список пуст

        public const int REMOVE_NIL = 0; // Remove() не вызывалась
        public const int REMOVE_RIGHT = 1; // Remove() отработала нормально; курсор сдвинулся вправо
        public const int REMOVE_LEFT = 2; // Remove() отработала нормально; курсор сдвинулся влево
        public const int REMOVE_LAST = 3; // Remove() отработала нормально; список теперь пуст
        public const int REMOVE_ERR = 4; // Список пуст

        public const int ADD_TO_EMPTY_NIL = 0; // AddToEmpty() не вызывалась
        public const int ADD_TO_EMPTY_OK = 1; // AddToEmpty() отработала нормально
        public const int ADD_TO_EMPTY_ERR = 2; // Список не пуст

        public const int ADD_TAIL_NIL = 0; // AddTail() не вызывалась
        public const int ADD_TAIL_OK = 1; // AddTail() отработала нормально
        public const int ADD_TAIL_ERR = 2; // Список пуст

        public const int REPLACE_NIL = 0; // Replace() не вызывалась
        public const int REPLACE_OK = 1; // Replace() отработала нормально
        public const int REPLACE_ERR = 2; // список пуст

        public const int FIND_NIL = 0; // Find() не вызывалась
        public const int FIND_OK = 1; // Find() отработала нормально
        public const int FIND_ERR = 2; // Искомого значения не оказалось в списке
        public const int FIND_EMPTY = 3; // список пуст
        
        // Запросы
        // Предусловие: список не пустой
        public abstract T Get();
        
        public abstract int Size();

        public abstract bool IsHead();

        public abstract bool IsTail();

        public abstract bool IsValue();

        // Команды
        // Предусловие: список не пустой
        // Постусловие: курсор установлен на головной элемент списка
        public abstract void Head();

        // Предусловие: список не пустой
        // Постусловие: курсор установлен на хвостовой элемент списка
        public abstract void Tail();

        // Предусловие: справа от текущего курсора есть другой элемент
        // Постусловие: курсор установлен на элемент, справа от предыдущего
        public abstract void Right();

        // Предусловие: список не пустой
        // Постусловие: справа от курсора вставлен новый элемент 
        public abstract void PutRight(T value);

        // Предусловие: список не пустой
        // Постусловие: слева от курсора вставлен новый элемент
        public abstract void PutLeft(T value);

        // Предусловие: список не пустой
        // Постусловие: узел, где раньше был курсор, удалён; курсор переместился вправо,
        // если там есть узел, или влево, если там есть узел. В случае, если курсор указывал
        // на единственный узел, список становится пустым
        public abstract void Remove();

        // Постусловие: список становится пустым
        public abstract void Clear();

        // Предусловие: список пустой
        // Постусловие: курсор устанавливается на новый узел, переданный в параметре. Он же
        // устанавливается в качестве головного и хвостового элемента
        public abstract void AddToEmpty(T value);

        // Предусловие: список не пустой
        // Постусловие: в хвосте спика появляется элемент, курсор перемещается на элемент
        // слева от него
        public abstract void AddTail(T value);

        // Предусловие: список не пустой;
        // Постусловие: узел, на который указывает курсор, принимает переданное значение
        public abstract void Replace(T value);
        
        // Предусловие: список не пустой; передеанное значение существует в списке
        // Постусловие: курсор установлен на следующий узел с искомым значением
        public abstract void Find(T value);

        // Постусловие: из списка удаляются все элементы, значение которых равно переданному
        public abstract void RemoveAll(T value);

        // Дополнительные запросы
        public abstract int GetHeadStatus(); // HEAD_*
        public abstract int GetTailStatus(); // TAIL_*
        public abstract int GetRightStatus(); // RIGHT_*
        public abstract int GetGetStatus(); // GET_*
        public abstract int GetPutRightStatus(); // PUT_RIGHT_*
        public abstract int GetPutLeftStatus(); // PUT_LEFT_*
        public abstract int GetRemoveStatus(); // REMOVE_*
        public abstract int GetAddToEmptyStatus(); // ADD_TO_EMPTY_*
        public abstract int GetAddTailStatus(); // ADD_TAIL_*
        public abstract int GetReplaceStatus(); // REPLACE_*
        public abstract int GetFindStatus(); // FIND_*
    }
}