using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Operation
    {
        /// <summary>
        /// Method to add two numbers
        /// </summary>
        /// <param name="_a">First number</param>
        /// <param name="_b">Second number</param>
        /// <returns>Sum from a and b</returns>
        public static double Plus(double _a, double _b)
        {
            return _a + _b;
        }

        /// <summary>
        /// Method to subtract two numbers
        /// </summary>
        /// <param name="_a">First number</param>
        /// <param name="_b">Second number</param>
        /// <returns>Subtract from a and b</returns>
        public static double Subtract(double _a, double _b)
        {
            return _a - _b;
        }

        /// <summary>
        /// Method to multiply two numbers
        /// </summary>
        /// <param name="_a">First number</param>
        /// <param name="_b">Second number</param>
        /// <returns>Multiplication from a and b</returns>
        public static double Times(double _a, double _b)
        {
            return _a * _b;
        }

        /// <summary>
        /// Method to divide two numbers
        /// </summary>
        /// <param name="_a">First number</param>
        /// <param name="_b">Second number</param>
        /// <returns>Divisoin from a and b</returns>
        public static double Divide(double _a, double _b)
        {
            return _a / _b;
        }
    }
}
