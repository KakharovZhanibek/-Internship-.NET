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
            if (numerator == 0)
                throw new ArgumentException();

            this.numerator = numerator;
            this.denomirator = denomirator;
        }

        public Fraction Addition(Fraction fraction)
        {
            Fraction resultFraction = Normalization(
                this.numerator * fraction.denomirator + fraction.numerator * this.denomirator, 
                this.denomirator * fraction.denomirator
                );

            return resultFraction;
        }
        public Fraction Difference(Fraction fraction)
        {
            if (this.Equals(fraction))
                return new Fraction(0, 1);

            Fraction resultFraction = Normalization(
                this.numerator * fraction.denomirator - fraction.numerator * this.denomirator,
                this.denomirator * fraction.denomirator
                );

            return resultFraction;
        }
        public Fraction Multiplication(Fraction fraction)
        {
            Fraction resultFraction = Normalization(
                this.numerator * fraction.numerator,
                this.denomirator * fraction.denomirator
                );
            return resultFraction;
        }
        public Fraction Division(Fraction fraction)
        {
            Fraction resultFraction = Normalization(
                this.numerator * fraction.denomirator,
                this.denomirator * fraction.numerator
                );
            return resultFraction;
        }

        public double ConversionToDouble()
        {
            return (double)numerator / denomirator;
        }

        public Fraction Normalization(int numerator,int denomirator)
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
            return numerator.GetHashCode()^
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
