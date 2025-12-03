using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    internal class Fraction : ICloneable
    {
        private int _numerator;
        private int _denominator;
        private float? _cash;

        public int Numerator
        {
            get { return _numerator; } 
        }

        public int Denomerator
        {
            get { return _denominator; }
        }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator; 
            _cash = null;
        }

        public void SetDenomerator(int denominator)
        {
            if (denominator != 0)
            {
                _denominator = denominator;
                _cash = null;
                Check();
            }
        }

        public void Cash()
        {
            _cash = (float)_numerator / _denominator;
        }

        public float? GetValue()
        {
            return _cash; 
        }

        public static Fraction operator +(Fraction a, int b)
        {
            Fraction f = new Fraction(a._numerator + b * a._denominator, a._denominator);
            Console.WriteLine($"{a._numerator}/{a._denominator} + {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator -(Fraction a, int b)
        {
            Fraction f = new Fraction(a._numerator - b * a._denominator, a._denominator);
            Console.WriteLine($"{a._numerator}/{a._denominator} - {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator *(Fraction a, int b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b, a._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} * {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator /(Fraction a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            Fraction f = Reduce(new Fraction(a._numerator, a._denominator * b));
            Console.WriteLine($"{a._numerator}/{a._denominator} / {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} + {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} - {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._numerator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} * {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator, a._denominator * b._numerator));
            Console.WriteLine($"{a._numerator}/{a._denominator} * {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b); 
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a.Equals(b));
        }

        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public override bool Equals(Object o)
        {
            if (o is Fraction f)
            {
                return (f._numerator == _numerator && f._denominator == _denominator);
            }
            return false;
            
        }

        public object Clone()
        {
            return new Fraction( _numerator, _denominator );
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            _numerator = numerator;
            _denominator = denominator;
            Check();
        }

        private void Check()
        {
            if (_denominator < 0)
            {
                _denominator *= -1;
                _numerator *= -1;
            }
        }

        static public Fraction Reduce(Fraction f)
        {
            int a = Math.Abs(f._numerator), b = Math.Abs(f._denominator), temp;

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            f._numerator /= a;
            f._denominator /= a;
            return f;
        }
    }
}
