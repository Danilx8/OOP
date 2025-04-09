using System;
using Newtonsoft.Json;

namespace OOP
{
    // В C# класс и так нельзя менять, если его методам не присвоено ключевое слово virtual, а свойства закрыты
    public partial class General : Object, IComparable
    {
        // Запрос (глубоко копирует ЭТОТ объект в уже существующий объект, переданный в качестве аргумента по ссылке)
        public void CopyTo(General destination)
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            if (destination.GetType() != GetType())
                throw new ArgumentException("Destination must be of the same type.");

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                if (!property.CanWrite) continue;

                var value = property.GetValue(this);

                if (value is General genValue && property.GetValue(destination) is General destGen)
                {
                    genValue.CopyTo(destGen); // Recursively copy nested objects
                }
                else
                {
                    property.SetValue(destination, value);
                }
            }
        }

        // Запрос (склонировать ЭТОТ объект и вернуть новый)
        public General Clone()
        {
            var clone = (General)Activator.CreateInstance(GetType());
            CopyTo(clone);
            return clone;
        }

        // ShallowCompare
        public int CompareTo(object obj)
        {
            return String.Compare(ToString(), obj.ToString(), StringComparison.Ordinal);
        }

        public int DeepCompare(General compared)
        {
            if (compared == null) return 1;

            var type = GetType();
            if (type != compared.GetType())
                throw new ArgumentException("Objects are not of the same type.");

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var thisValue = property.GetValue(this);
                var otherValue = property.GetValue(compared);

                if (thisValue is General thisGeneral && otherValue is General otherGeneral)
                {
                    int result = thisGeneral.DeepCompare(otherGeneral);
                    if (result != 0)
                        return result;
                }
                else if (thisValue is IComparable c1 && otherValue is IComparable c2)
                {
                    int result = c1.CompareTo(c2);
                    if (result != 0)
                        return result;
                }
                else if (thisValue == null && otherValue != null)
                {
                    return -1;
                }
                else if (thisValue != null && otherValue == null)
                {
                    return 1;
                }
            }

            return 0;
        }


        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
        }

        public static T Deserialize<T>(string json) where T : General
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        public void Print()
        {
            Console.WriteLine(Serialize());
        }

        public bool TypeOf(Type type)
        {
            return GetType() == type;
        }

        // General.GetType вызывает Object.GetType, что нам подходит по ковариантности
    }

    public class Any : General
    {
    }
}