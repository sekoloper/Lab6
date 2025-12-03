using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Класс дроби
    /// </summary>
    internal class Fraction : ICloneable, IRealValue, INumeratorDenominator
    {
        private int _numerator;
        private int _denominator;
        private float? _cash;

        /// <summary>
        /// Получить числитель дроби
        /// </summary>
        public int Numerator
        {
            get { return _numerator; } 
        }

        /// <summary>
        /// Получить знаменатель дроби
        /// </summary>
        public int Denominator
        {
            get { return _denominator; }
        }

        /// <summary>
        /// Установить значение числителя
        /// </summary>
        /// <param name="numerator"></param>
        public void SetNumerator(int numerator)
        {
            _numerator = numerator; 
            _cash = null;
        }

        /// <summary>
        /// Установить значение знаменателя
        /// </summary>
        /// <param name="denominator"></param>
        public void SetDenominator(int denominator)
        {
            if (denominator != 0)
            {
                _denominator = denominator;
                _cash = null;
                Check();
            }
        }

        /// <summary>
        /// Вычислить и обновить вещественное значение дроби
        /// </summary>
        public void Cash()
        {
            _cash = (float)_numerator / _denominator;
        }

        /// <summary>
        /// Получить вещественное значение
        /// </summary>
        /// <returns></returns>
        public float? GetRealValue()
        {
            return _cash; 
        }

        /// <summary>
        /// Сложить дробь с числом 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, int b)
        {
            Fraction f = new Fraction(a._numerator + b * a._denominator, a._denominator);
            Console.WriteLine($"{a._numerator}/{a._denominator} + {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Вычесть из дроби число
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a, int b)
        {
            Fraction f = new Fraction(a._numerator - b * a._denominator, a._denominator);
            Console.WriteLine($"{a._numerator}/{a._denominator} - {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Умножить дробь на число
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator *(Fraction a, int b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b, a._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} * {b} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Разделить дробь на число
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
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

        /// <summary>
        /// Сложить два числа
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} + {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Вычесть из одной дроби другую
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} - {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Умножить две дроби
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._numerator, a._denominator * b._denominator));
            Console.WriteLine($"{a._numerator}/{a._denominator} * {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Разделить одну дробь на другую
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction f = Reduce(new Fraction(a._numerator * b._denominator, a._denominator * b._numerator));
            Console.WriteLine($"{a._numerator}/{a._denominator} / {b._numerator}/{b._denominator} = {f._numerator}/{f._denominator}");
            return f;
        }

        /// <summary>
        /// Проверить две дроби на равенство
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b); 
        }

        /// <summary>
        /// Проверить две дроби на неравенство
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a.Equals(b));
        }

        /// <summary>
        /// Вывести дробь в формате строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        /// <summary>
        /// Сравнить две дроби
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (o is Fraction f)
            {
                return (f._numerator == _numerator && f._denominator == _denominator);
            }
            return false;
            
        }

        /// <summary>
        /// Создать копию дроби
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Fraction( _numerator, _denominator );
        }

        /// <summary>
        /// Создать экземпляр с параметрами: числитель, знаменатель
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <exception cref="DivideByZeroException"></exception>
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

        /// <summary>
        /// Проверить знаменатель на неотрицательность
        /// </summary>
        private void Check()
        {
            if (_denominator < 0)
            {
                _denominator *= -1;
                _numerator *= -1;
            }
        }

        /// <summary>
        /// Сократить дробь
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
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
