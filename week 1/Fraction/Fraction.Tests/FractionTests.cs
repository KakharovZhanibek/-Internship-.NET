using System;
using Xunit;

namespace Fraction.Tests
{
    public class FractionTests
    {
        [Fact]
        public void Addition_59_7and48_36_Return()
        {
            //Arrange
            Fraction fraction1 = new Fraction(57, 9);
            Fraction fraction2 = new Fraction(48, 36);
            Fraction expected = new Fraction(23, 3);


            //Act
            var resFraction = fraction1.Addition(fraction2);
            //Assert

            Assert.Equal(expected, resFraction);
        }
        [Fact]
        public void Difference_452_49and356_67_Return()
        {
            //Arrange
            Fraction fraction1 = new Fraction(452, 49);
            Fraction fraction2 = new Fraction(356, 67);

            Fraction expected = new Fraction(12840, 3283);
            //Act
            var resFraction = fraction1.Difference(fraction2);
            //Assert

            Assert.Equal(expected, resFraction);
        }
        [Fact]
        public void Multiplication_356_46and462_62_Return()
        {
            //Arrange
            Fraction fraction1 = new Fraction(356, 46);
            Fraction fraction2 = new Fraction(462, 62);

            Fraction expected = new Fraction(41118, 713);
            //Act
            var resFraction = fraction1.Multiplication(fraction2);
            //Assert

            Assert.Equal(expected, resFraction);
        }
        [Fact]
        public void Division_45679_4567and37452_954_Return()
        {
            //Arrange
            Fraction fraction1 = new Fraction(45679, 4567);
            Fraction fraction2 = new Fraction(37452, 954);

            Fraction expected = new Fraction(7262961, 28507214);
            //Act
            var resFraction = fraction1.Division(fraction2);
            //Assert

            Assert.Equal(expected, resFraction);
        }
        [Fact]
        public void ConversionToDouble_452_49and356_67_Return()
        {
            //Arrange
            Fraction fraction1 = new Fraction(452, 49);


            var expected = (double)452 / 49;
            //Act
            var resFraction = fraction1.ConversionToDouble();
            //Assert

            Assert.Equal(expected, resFraction);
        }
    }
}
