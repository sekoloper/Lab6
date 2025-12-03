using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    internal class Cat : IMeowable
    {
        private string _name;
        private int _counter;

        public string Name
        {
            get { return _name; }
        }

        public void Meow()
        {
            _counter++;
            Console.WriteLine($"{_name}: мяу!");
        }

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

        public string HowMushMeows()
        {
            return $"У кота по кличке {_name} были мяуканья в количестве: {_counter}.";
        }

        public override string ToString()
        {
            return $"кот: {_name}";
        }

        public Cat(string name)
        {
            Console.WriteLine($"Появился кот по кличке {name}.");
            _name = name; 
            _counter = 0;
        }
    }
}
