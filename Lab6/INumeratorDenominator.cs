using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Интерфейс для установление числителя и знаменателя
    /// </summary>
    internal interface INumeratorDenominator
    {
        /// <summary>
        /// Установить значение числителя
        /// </summary>
        /// <param name="numerator"></param>
        public void SetNumerator(int numerator);
        /// <summary>
        /// Установить значение знаменателя
        /// </summary>
        /// <param name="denominator"></param>
        public void SetDenominator(int denominator);
    }
}
