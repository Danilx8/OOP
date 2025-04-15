using System;

namespace OOP
{
    public partial class General
    {
        // Это базовый метод сложения, реализуемый в классе General
        public virtual General Add(General value)
        {
            return Deserialize<General>(Serialize() + value.Serialize());
        }

        // Этот оператор смотрит на тип складываемых данных и вызывает метод Add, реализуемый в нём
        public static General operator +(General first, General second)
        {
            return first.Add(second);
        }
    }
    
    public class Vector<T> : General where T : General
    {
        private const float SHRINK_FRACTION = 0.5F;
        private T[] array;
        private int count;
        private int capacity;

        public Vector()
        {
            count = 0;
            MakeArray(16);
        }

        public override General Add(General value)
        {
            Vector<T> newValue = value as Vector<T>;
            if (newValue == null)
            {
                throw new ArgumentException("Added values have to be of the same type");
            }
            
            if (count != newValue.count) return null;

            Vector<T> result = new Vector<T>();
            for (int i = 0; i < count; ++i)
            {
                T item1 = GetItem(i);
                T item2 = newValue.GetItem(i);
                result.Insert((T)item1.Add(item2), i);
            }

            return result;
        }

        private void MakeArray(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            int transferringCapacity = Math.Min(capacity, newCapacity);
            if (!(array is null) && array != Array.Empty<T>()) Array.Copy(array, newArray, transferringCapacity);
            capacity = newCapacity;
            array = newArray;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException("Index out of range.");
            return array[index];
        }

        public Vector<T> Append(T itm)
        {
            if (count + 1 > capacity) MakeArray(capacity * 2);
            array[count++] = itm;
            return this;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count) throw new IndexOutOfRangeException("Index out of range.");
            if (++count > capacity) MakeArray(capacity * 2);

            for (int i = count - 2; i >= index; --i)
            {
                array[i + 1] = array[i];
            }

            array[index] = itm;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException("Index out of range.");
            for (int i = index; i < count - 1; ++i)
            {
                array[i] = array[i + 1];
            }

            array[count - 1] = default(T);

            if (--count < SHRINK_FRACTION * capacity) MakeArray(Math.Max((int)(capacity / 1.5), 16));
        }
    }
}