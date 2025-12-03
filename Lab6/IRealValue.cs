using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Интерфейс для получение вещественного значения
    /// </summary>
    internal interface IRealValue
    {
        /// <summary>
        /// Получить вещественное значение
        /// </summary>
        /// <returns></returns>
        public float? GetRealValue();
    }
}
