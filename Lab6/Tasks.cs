using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    internal class Tasks
    {
        static public void Choose(int taskNum)
        {
            switch (taskNum)
            {
                case 0: break;
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: TestTask(); break;
                default: Console.WriteLine("Некорректный номер задания."); break;
            }
        }

        static private void Task1()
        {
            Cat cat1 = new("Барсик");
            cat1.Meow();
            cat1.Meow(3);
            Console.WriteLine(cat1.HowMushMeows());

            Cat cat2 = new("Мурзик");
            QuasiCat quasiCat = new("wxwd7891");
            UniversalMeow(cat1, cat2, quasiCat);

            Console.WriteLine(cat1.HowMushMeows());
        }

        static private void Task2()
        {
            try
            {
                int numerator, denominator;

                numerator = InputValidation.InputIntegerWithValidation("Введите числитель первой дроби", int.MinValue, int.MaxValue);
                denominator = InputValidation.InputIntegerWithValidation("Введите знаменатель первой дроби", int.MinValue, int.MaxValue);
                Fraction f1 = new Fraction(numerator, denominator);

                numerator = InputValidation.InputIntegerWithValidation("Введите числитель второй дроби", int.MinValue, int.MaxValue);
                denominator = InputValidation.InputIntegerWithValidation("Введите знаменатель второй дроби", int.MinValue, int.MaxValue);
                Fraction f2 = new Fraction(numerator, denominator);

                numerator = InputValidation.InputIntegerWithValidation("Введите числитель третей дроби", int.MinValue, int.MaxValue);
                denominator = InputValidation.InputIntegerWithValidation("Введите знаменатель третей дроби", int.MinValue, int.MaxValue);
                Fraction f3 = new Fraction(numerator, denominator);

                Fraction f4 = (f1 + f2) / f3 - 5;

                Fraction f5 = new Fraction(1, 2);
                Fraction f6 = new Fraction(1, 2);
                Console.WriteLine($"Равны ли дроби {f5} и {f6}? {f6 == f5}");

                f5 = new Fraction(1, 3);
                Console.WriteLine($"Равны ли дроби {f5} и {f6}? {f6 == f5}");

                Fraction f7 = (Fraction)f6.Clone();
                Console.WriteLine($"Дробь f7({f7}) это клон дроби f6({f6})");

                Console.WriteLine($"Вещественное значение дроби f7({f7}) до вычисления кэша: {f7.GetRealValue()}");
                f7.Cash();
                Console.WriteLine($"Вещественное значение f7({f7}) после вычисления кэша: {f7.GetRealValue()}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static private void TestTask()
        {

        }

        static private void UniversalMeow(params IMeowable[] meowlist)
        {
            foreach (IMeowable meowobject in meowlist)
            {
                meowobject.Meow();
            }
        }
    }
}
