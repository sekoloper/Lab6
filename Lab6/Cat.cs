using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Класс кота
    /// </summary>
    internal class Cat : IMeowable
    {
        private string _name;
        private int _counter;

        /// <summary>
        /// Получить имя
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Мяукнуть один раз
        /// </summary>
        public void Meow()
        {
            _counter++;
            Console.WriteLine($"{_name}: мяу!");
        }

        /// <summary>
        /// Мяукнуть несколько раз
        /// </summary>
        /// <param name="n"></param>
        public void Meow(int n)
        {
            if (n > 0)
            {
                _counter += n;
                Console.Write($"{_name}: ");
                for (int i = 1; i < n; i++)
                {
                    Console.Write("мяу-");
                }
                Console.WriteLine("мяу!");
            }
        }

        /// <summary>
        /// Узнать количество мяуканий
        /// </summary>
        /// <returns></returns>
        public string HowMushMeows()
        {
            return $"У кота по кличке {_name} были мяуканья в количестве: {_counter}.";
        }

        /// <summary>
        /// Вывести кота в формате строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"кот: {_name}";
        }

        /// <summary>
        /// Создать экземпляр кота с параметром: имя
        /// </summary>
        /// <param name="name"></param>
        public Cat(string name)
        {
            Console.WriteLine($"Появился кот по кличке {name}.");
            _name = name; 
            _counter = 0;
        }
    }
}
