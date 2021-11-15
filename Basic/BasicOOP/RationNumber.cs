using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP
{
    //Создать класс рациональных чисел.
    //    В классе два поля – числитель и знаменатель.
    //    Предусмотреть конструктор. 
    //    Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. 
    //    Переопределить метод ToString() для вывода дроби.
    //    Определить операторы преобразования типов между типом дробь,float, int. 
    //    Определить операторы *, /, %.
    public class RationNumber
    {
        private int _numerator;//Числитель
        private int _denominator;//Знаменатель

        /// <summary>
        /// Числитель
        /// </summary>
        public int Numerator
        {
            get
            {
                return _numerator;
            }
            set { _numerator = value; }
        }

        /// <summary>
        /// Знаменатель
        /// </summary>
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set { _denominator = value; }
        }

        public RationNumber(int numerator, int denominator)
        {
            _numerator = numerator;
            if (denominator < 1)
                throw new ArgumentException("Знаменатель может быть только натуральным числом! >0");
            _denominator = denominator;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RationNumber);
        }

        public bool Equals(RationNumber number)
        {
            if (number is null)
                return false;

            return number.Numerator == _numerator && number.Denominator == _denominator;
        }

        public override string ToString()
        {
            return $"({_numerator}/{_denominator})";
        }

        public static bool operator ==(RationNumber valueA, RationNumber valueB)
        {
            if(valueA is null && valueB is null)
                return true;

            return valueA.Equals(valueB);
        }

        public static bool operator !=(RationNumber valueA, RationNumber valueB)
        {
            if (valueA is null && valueB is null)
                return false;

            return !valueA.Equals(valueB);
        }

        public static RationNumber operator +(RationNumber valueA, RationNumber valueB)
        {
            if (valueA.Denominator == valueB.Denominator)
            {
                return new RationNumber(valueA.Numerator + valueB.Numerator, valueA.Denominator);
            }
            else
            {
                (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);
                return new RationNumber(numeratorA + numeratorB, valueA.Denominator * valueB.Denominator);

            }
        }

        public static RationNumber operator -(RationNumber valueA, RationNumber valueB)
        {
            if (valueA.Denominator == valueB.Denominator)
            {
                return new RationNumber(valueA.Numerator - valueB.Numerator, valueA.Denominator);
            }
            else
            {
                (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);
                return new RationNumber(numeratorA - numeratorB, valueA.Denominator * valueB.Denominator);

            }
        }

        public static bool operator <(RationNumber valueA, RationNumber valueB)
        {
            (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);

            if (numeratorA < numeratorB)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(RationNumber valueA, RationNumber valueB)
        {
            (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);

            if (numeratorA > numeratorB)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(RationNumber valueA, RationNumber valueB)
        {
            (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);

            if (numeratorA <= numeratorB)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(RationNumber valueA, RationNumber valueB)
        {
            (int numeratorA, int numeratorB) = ReducingToCommonDenominator(valueA, valueB);

            if (numeratorA >= numeratorB)
            {
                return true;
            }

            return false;
        }

        public static RationNumber operator *(RationNumber valueA, RationNumber valueB)
        {
            return new RationNumber(valueA.Numerator * valueB.Numerator, valueA.Denominator * valueB.Denominator);
        }

        public static RationNumber operator /(RationNumber valueA, RationNumber valueB)
        {
            return new RationNumber(valueA.Numerator * valueB.Denominator, valueA.Denominator * valueB.Numerator);
        }

        public static RationNumber operator %(RationNumber valueA, RationNumber valueB)
        {
            RationNumber valueC = valueA / valueB;

            if (valueC.Numerator < valueC.Denominator)
            {
                return new RationNumber(0, 1);
            }
            else
            {
                int integerPart = 0;
                do
                {
                    integerPart++;
                }
                while (valueC.Numerator - (valueC.Denominator * integerPart) > valueC.Denominator);
                
                valueC.Numerator -= valueC.Denominator * integerPart;
            }
            return valueC * valueB;
            
        }

        public static RationNumber operator ++(RationNumber value)
        {
            value.Numerator++;
            value.Denominator++;
            return value;
        }

        public static RationNumber operator --(RationNumber value)
        {
            value.Numerator --;
            value.Denominator--;
            return value;
        }

        public static explicit operator float(RationNumber value)
        {
            return (float)(value.Numerator / value.Denominator);
        }

        public static explicit operator int(RationNumber value)
        {
            return (int)(value.Numerator / value.Denominator);
        }

        public static explicit operator RationNumber(float value)
        {
            throw new NotImplementedException();
        }

        public static explicit operator RationNumber(int value)
        {
            return new RationNumber(value, 1);
        }

        private static (int, int) ReducingToCommonDenominator(RationNumber valueA, RationNumber valueB)
        {
            int numeratorA = valueA.Numerator * valueB.Denominator;
            int numeratorB = valueB.Numerator * valueA.Denominator;

            return (numeratorA, numeratorB);
        }
    }
}