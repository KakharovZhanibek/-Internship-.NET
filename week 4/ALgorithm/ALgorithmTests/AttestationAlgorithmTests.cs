using ALgorithm;
using System;
using Xunit;

namespace ALgorithmTests
{
    public class AttestationAlgorithmTests
    {
        [Fact]
        public void MaxSubArraySum_Array_ReturnsMaxSubArraySum()
        {
            //Arrange
            int[] test = { 5, -4, 1, 7, 8 };
            int expected = 17;

            //Act
            int actual = AttestationAlgorithm.MaxSubArray(test);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MaxSubArraySum_Array_ThrowsArgumentNullException()
        {   //Arrange
            int[] test = null;

            //Act
            Action act = () => AttestationAlgorithm.MaxSubArray(test);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}