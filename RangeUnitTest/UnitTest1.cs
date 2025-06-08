using NUnit.Framework;
using RangeStruct;

namespace RangeStruct.UnitTests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void ConstructorTest()
        {
            var range = new Range(5, 10);
            Assert.That(range.A, Is.EqualTo(5));
            Assert.That(range.B, Is.EqualTo(10));
        }

        [Test]
        public void Constructor_EmptyRange_Valid()
        {
            var range = new Range(0, 0);
            Assert.That(range.A, Is.EqualTo(0));
            Assert.That(range.B, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_InvalidRange_ArgumentException()
        {
            Assert.That(() => new Range(10, 5), Throws.ArgumentException);
        }

        [TestCase(5, 10, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, 5, 10)]
        public void CountTest(int a, int b, int result)
        {
            var range = new Range(a, b);
            Assert.That(range.Count, Is.EqualTo(result));
        }

        [TestCase(5, 10, 7, true)]
        [TestCase(5, 10, 5, true)]
        [TestCase(5, 10, 10, false)]
        [TestCase(5, 10, 4, false)]
        public void IsContainsTest(int a, int b, int number, bool result)
        {
            var range = new Range(a, b);
            Assert.That(range.IsContains(number), Is.EqualTo(result));
        }

        [TestCase(5, 10, "[5; 10)")]
        [TestCase(0, 0, "[0; 0)")]
        [TestCase(-3, 5, "[-3; 5)")]
        public void ToStringTest(int a, int b, string result)
        {
            var range = new Range(a, b);
            Assert.That(range.ToString(), Is.EqualTo(result));
        }

        [TestCase(5, 10, 5, 10, true)]
        [TestCase(5, 10, 5, 15, false)]
        [TestCase(0, 0, 0, 0, true)]
        public void Equals_TwoRanges_ExpectedResult(int a1, int b1, int a2, int b2, bool result)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            Assert.That(range1.Equals(range2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var range = new Range();
            var obj = new object();
            Assert.That(() => range.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Range(5, 10);
            var y = new Range(5, 10);
            var z = new Range(1, 3);

            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new Range(5, 10);
            var y = new Range(5, 10);
            var z = new Range(1, 3);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(5, 10, 7, 12, 7, 10)]
        [TestCase(5, 10, 1, 6, 5, 6)]
        [TestCase(5, 10, 15, 20, 0, 0)] // Пустое пересечение
        public void IntersectionTest(int a1, int b1, int a2, int b2, int resultA, int resultB)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            var result = new Range(resultA, resultB);

            Assert.That(range1 & range2, Is.EqualTo(result));
        }

        [TestCase(5, 10, 7, 12, 5, 12)]
        [TestCase(5, 10, 1, 6, 1, 10)]
        [TestCase(5, 10, 15, 20, 5, 20)]
        public void UnionTest(int a1, int b1, int a2, int b2, int resultA, int resultB)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            var result = new Range(resultA, resultB);

            Assert.That(range1 | range2, Is.EqualTo(result));
        }
    }
}