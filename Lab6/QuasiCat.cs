using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Класс квазикота
    /// </summary>
    internal class QuasiCat : IMeowable
    {
        private string _name;

        /// <summary>
        /// Получить имя кота
        /// </summary>
        public string Name
        {
            get { return _name; } 
        }

        /// <summary>
        /// Мяукнуть
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{_name}: мяу?");
        }

        /// <summary>
        /// Создать экземпляр с параметром: имя
        /// </summary>
        /// <param name="name"></param>
        public QuasiCat(string name)
        {
            Console.WriteLine($"Появился квазикот по кличке {name}!");
            _name = name;
        }
    }
}
