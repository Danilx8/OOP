using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class BoundedStack<T> {
        private List<T> stack; 
        private int peek_status;
        private int pop_status;
        private int push_status;
        
        private uint Limit;

        public const int POP_NIL = 0;
        public const int POP_OK = 1;
        public const int POP_ERR = 2;
        public const int PEEK_NIL = 0;
        public const int PEEK_OK = 1;
        public const int PEEK_ERR = 2;
        public const int PUSH_NIL = 0;
        public const int PUSH_OK = 1;
        public const int PUSH_ERR = 2;

        // Предусловие: параметр limit - целое положительное число
        // Постусловие: создан новый пустой стек. Установлено предельное число элементов
        // З.Ы. 4) По возможности применяем статическую типизацию.
        // Если лучше сводить использование таких языковых конструкций к минимуму на данном курсе, то в дальнейшем буду
        // их избегать
        public void Stack(uint limit = 32)
        {
            Clear();
            Limit = limit;
        }

        // Предусловие: размер стека меньше лимита
        // Постусловие: в стек добавлено новое значение
        public void Push(T value)
        {
            if (Size() != Limit)
            {
                stack.Append(value);
                push_status = PUSH_OK;
            }
            else
            {
                push_status = PUSH_ERR;
            }
        }

        // Предусловие: стек не пустой
        // Постусловие: верхний элемент удаляется из стека
        public void Pop()
        {
            if (Size() > 0)
            {
                stack.RemoveAt(-1);
                pop_status = POP_OK;
            }
            else
            {
                pop_status = POP_ERR;
            }
        }

        // Постусловие: из стека удаляются все элементы
        public void Clear()
        {
            stack = new List<T>();
            peek_status = PEEK_NIL;
            pop_status = POP_NIL;
            push_status = PUSH_NIL;
        }
        
        // Предусловие: стек не пустой
        public T Peek()
        {
            T result;
            
            if (Size() > 0)
            {
                result = stack[-1];
                peek_status = PEEK_OK;
            }
            else
            {
                result = default;
                peek_status = PEEK_ERR;
            }

            return result;
        }
        
        public int Size()
        {
            return stack.Count;
        }
        
        public int get_pop_status()
        {
            return pop_status;
        }

        public int get_peek_status()
        {
            return peek_status;
        }

        public int get_push_status()
        {
            return push_status;
        }
    }
}