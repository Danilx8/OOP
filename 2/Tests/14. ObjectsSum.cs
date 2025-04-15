using System;
using NUnit.Framework;

namespace OOP.Tests
{
    public class Number : General
    {
        public int Value { get; }
        
        public Number(int value)
        {
            Value = value;
        }

        public override General Add(General value)
        {
            var newNumber = value as Number;
            if (newNumber == null)
                throw new ArgumentException("Invalid type, expected Number.");
            return new Number(Value + newNumber.Value) ;
        }

        public static implicit operator Number(int value) => new Number(value);
    }
    
    [TestFixture]
    public class VectorAdditionTests
    {
        [Test]
        public void TripleNestedVectorAddition_WorksCorrectly()
        {
            var a = new Vector<Vector<Vector<Number>>>();

            {
                var inner1 = new Vector<Vector<Number>>();
                inner1.Append(new Vector<Number>().Append(1).Append(2));
                inner1.Append(new Vector<Number>().Append(3).Append(4));
                a.Append(inner1);

                var inner2 = new Vector<Vector<Number>>();
                inner2.Append(new Vector<Number>().Append(5).Append(6));
                inner2.Append(new Vector<Number>().Append(7).Append(8));
                a.Append(inner2);
            }

            var b = new Vector<Vector<Vector<Number>>>();

            {
                var inner1 = new Vector<Vector<Number>>();
                inner1.Append(new Vector<Number>().Append(10).Append(20));
                inner1.Append(new Vector<Number>().Append(30).Append(40));
                b.Append(inner1);

                var inner2 = new Vector<Vector<Number>>();
                inner2.Append(new Vector<Number>().Append(50).Append(60));
                inner2.Append(new Vector<Number>().Append(70).Append(80));
                b.Append(inner2);
            }
            
            var result = a + b as Vector<Vector<Vector<Number>>> ?? throw new AggregateException();

            Assert.Multiple(() =>
            {
                Assert.That(result.GetItem(0).GetItem(0).GetItem(0).Value, Is.EqualTo(11));
                Assert.That(result.GetItem(0).GetItem(0).GetItem(1).Value, Is.EqualTo(22));
                Assert.That(result.GetItem(0).GetItem(1).GetItem(0).Value, Is.EqualTo(33));
                Assert.That(result.GetItem(0).GetItem(1).GetItem(1).Value, Is.EqualTo(44));
                Assert.That(result.GetItem(1).GetItem(0).GetItem(0).Value, Is.EqualTo(55));
                Assert.That(result.GetItem(1).GetItem(0).GetItem(1).Value, Is.EqualTo(66));
                Assert.That(result.GetItem(1).GetItem(1).GetItem(0).Value, Is.EqualTo(77));
                Assert.That(result.GetItem(1).GetItem(1).GetItem(1).Value, Is.EqualTo(88));
            });
        }
    }
}