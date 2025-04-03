using NUnit.Framework;

namespace OOP.Tests
{
    public class GeneralTests
    {
        public class TestClass : Any
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Any Nested { get; set; }
        }

        [Test]
        public void DeepCopy_CreatesNewNestedInstances()
        {
            var original = new TestClass
            {
                Name = "Jane",
                Age = 25,
                Nested = new TestClass { Name = "Nested", Age = 5 }
            };

            var copy = new TestClass();
            original.CopyTo(copy);

            Assert.That(copy.Name, Is.EqualTo("Jane"));
            Assert.That(copy.Age, Is.EqualTo(25));
            Assert.That(copy.Nested, Is.Not.Null);
            Assert.That(((TestClass)copy.Nested).Name, Is.EqualTo("Nested"));
            Assert.That(ReferenceEquals(original.Nested, copy?.Nested), Is.True);
        }

        [Test]
        public void Clone_CreatesDeepCopy()
        {
            var original = new TestClass
            {
                Name = "Clone",
                Age = 40,
                Nested = new TestClass { Name = "Inner", Age = 10 }
            };

            var clone = original.Clone() as TestClass;
            Assert.That(clone, Is.Not.Null);
            Assert.That(clone?.Name, Is.EqualTo("Clone"));
            Assert.That(clone?.Age, Is.EqualTo(40));
            Assert.That(ReferenceEquals(original, clone), Is.False);
            Assert.That(ReferenceEquals(original.Nested, clone?.Nested), Is.True);
        }

        [Test]
        public void CompareTo_UsesToString()
        {
            var obj1 = new Any();
            var obj2 = new Any();

            int result = obj1.CompareTo(obj2);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DeepCompare_ReturnsZeroForEqualObjects()
        {
            var a = new TestClass { Name = "Same", Age = 10 };
            var b = new TestClass { Name = "Same", Age = 10 };

            int result = a.DeepCompare(b);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DeepCompare_ReturnsNonZeroForDifferentObjects()
        {
            var a = new TestClass { Name = "A", Age = 10 };
            var b = new TestClass { Name = "B", Age = 10 };

            int result = a.DeepCompare(b);
            Assert.That(result, Is.Not.EqualTo(0));
        }

        [Test]
        public void Serialize_ProducesJson()
        {
            var obj = new TestClass { Name = "Json", Age = 99 };

            var json = obj.Serialize();

            Assert.That(json, Does.Contain("\"Name\":\"Json\""));
        }

        [Test]
        public void Deserialize_RestoresObject()
        {
            var original = new TestClass { Name = "Back", Age = 55 };
            var json = original.Serialize();

            var deserialized = General.Deserialize<TestClass>(json);

            Assert.That(deserialized.Name, Is.EqualTo("Back"));
            Assert.That(deserialized.Age, Is.EqualTo(55));
        }

        [Test]
        public void TypeOf_ReturnsCorrectType()
        {
            var obj = new Any();

            Assert.That(obj.TypeOf(typeof(Any)), Is.True);
            Assert.That(obj.TypeOf(typeof(General)), Is.False);
        }
    }
}