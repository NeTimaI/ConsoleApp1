using System;

namespace RangeStruct
{
    public struct Range
    {
        public int A { get; set; }

        private int b;
        public int B
        {
            get => b;
            set
            {
                if (value < A && !(A == 0 && value == 0))
                    throw new ArgumentException("Правая граница должна быть больше левой или диапазон должен быть (0;0)");
                b = value;
            }
        }

        public int Count => B - A;

        public Range(int a, int b) : this()
        {
            A = a;
            B = b;
        }

        public bool IsContains(int number) => number >= A && number < B;

        public override string ToString() => $"[{A}; {B})";

        public override bool Equals(object obj)
        {
            if (obj is Range)
                return A == ((Range)obj).A && B == ((Range)obj).B;

            throw new ArgumentException("Объект для сравнения не является диапазоном");
        }

        public override int GetHashCode() => (A, B).GetHashCode();

        public static bool operator ==(Range x, Range y) => x.Equals(y);
        public static bool operator !=(Range x, Range y) => !x.Equals(y);

        public static Range operator &(Range x, Range y)
        {
            int newA = Math.Max(x.A, y.A);
            int newB = Math.Min(x.B, y.B);

            if (newA > newB)
                return new Range(0, 0); // Пустой диапазон

            return new Range(newA, newB);
        }

        public static Range operator |(Range x, Range y)
        {
            int newA = Math.Min(x.A, y.A);
            int newB = Math.Max(x.B, y.B);

            return new Range(newA, newB);
        }
    }
}