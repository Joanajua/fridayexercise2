using System;

using Moq;
using PizzaFactory.Services;
using Xunit;

namespace PizzaFactory.Tests
{
    public class BaseTests
    {
        public Mock<IConfigurationService> _configurationServiceMock = new Mock<IConfigurationService>();

        [Theory]
        [InlineData(" ", 0)]
        [InlineData("Test", 400)]
        [InlineData("This is a test", 1100)]
        [InlineData("This-is-a-test", 1400)]
        public void CalculateTotalBaseTime_Should_calculate_appropriate_total_base_time(string baseType, double expected)
        {
            //Arrange
            var baseInstance = new Base(_configurationServiceMock.Object);
            var baseCookingTime = 1000;
            var baseMultiplier = 1.3;

            var configBaseCookingTime = _configurationServiceMock
                .Setup(x => x.GetBaseCookingTime())
                .Returns(baseCookingTime);

            var configBaseMultiplier = _configurationServiceMock
                .Setup(x => x.GetBaseMultiplier(baseType))
                .Returns(baseMultiplier);


            //Act
            var result = baseInstance.CalculateTotalBaseTime(baseType);

            //Assert
            Assert.IsType<Double>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateTotalToppingTime_Should_return_zero_when_description_is_empty()
        {
            //Arrange
            var topping = new Topping(_configurationServiceMock.Object);
            var timePerLetterTopping = 100;
            var description = "";
            var expected = 0;

            var configTopping = _configurationServiceMock
                .Setup(x => x.GetToppingCookingTime())
                .Returns(timePerLetterTopping);

            //Act
            var result = topping.CalculateTotalToppingTime(description);

            //Assert
            Assert.IsType<Double>(result);
            Assert.Equal(expected, result);
        }
    }
}
