using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    public class Fraction
    {
        public int numerator { get; }
        public int denomirator { get; }
        public Fraction(int numerator, int denomirator)
        {
            if (denomirator == 0)
                throw new DivideByZeroException();

            this.numerator = numerator;
            this.denomirator = denomirator;
        }

        public static Fraction operator +(Fraction fractionA, Fraction fractionB)
        {
            Fraction resultFraction = Normalization(
                fractionA.numerator * fractionB.denomirator + fractionB.numerator * fractionA.denomirator,
                fractionA.denomirator * fractionB.denomirator
                );

            return resultFraction;
        }
        public static Fraction operator -(Fraction fractionA, Fraction fractionB)
        {
            Fraction resultFraction = Normalization(
                fractionA.numerator * fractionB.denomirator - fractionB.numerator * fractionA.denomirator,
                fractionA.denomirator * fractionB.denomirator
                );

            return resultFraction;
        }
        public static Fraction operator *(Fraction fractionA,Fraction fractionB)
        {
            Fraction resultFraction = Normalization(
                fractionA.numerator * fractionB.numerator,
                fractionA.denomirator * fractionB.denomirator
                );
            return resultFraction;
        }
        public static Fraction operator /(Fraction fractionA,Fraction fractionB)
        {
            Fraction resultFraction = Normalization(
                fractionA.numerator * fractionB.denomirator,
                fractionA.denomirator * fractionB.numerator
                );
            return resultFraction;
        }

        public double ConversionToDouble()
        {
            return (double)numerator / denomirator;
        }

        public static Fraction Normalization(int numerator, int denomirator)
        {
            return new Fraction(
                numerator / GetCommonDivisor(numerator, denomirator),
                denomirator / GetCommonDivisor(numerator, denomirator)
                );
        }

        private static int GetCommonDivisor(int i, int j)
        {
            i = Math.Abs(i);
            j = Math.Abs(j);
            while (i != j)
                if (i > j) { i -= j; }
                else { j -= i; }
            return i;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^
                denomirator.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Fraction fraction = (Fraction)obj;
                return (numerator == fraction.numerator) && (denomirator == fraction.denomirator);
            }
        }
    }
}
