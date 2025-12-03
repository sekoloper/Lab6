using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    internal class QuasiCat : IMeowable
    {
        private string _name;

        public string Name
        {
            get { return _name; } 
        }

        public void Meow()
        {
            Console.WriteLine($"{_name}: мяу?");
        }

        public QuasiCat(string name)
        {
            Console.WriteLine($"Появился квазикот по кличке {name}!");
            _name = name;
        }
    }
}
