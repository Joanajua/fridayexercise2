using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Moq.Protected;
using PizzaFactory.Services;
using Xunit;

namespace PizzaFactory.Tests
{
    public class ToppingTests
    {
        public Mock<IConfigurationService> _configurationServiceMock = new Mock<IConfigurationService>();

        [Theory]
        [InlineData(" ", 0)]
        [InlineData("Hello", 500)]
        [InlineData("This is a test", 1100)]
        [InlineData("This-is-a-test", 1400)]
        public void CalculateTotalToppingTime_Should_calculate_appropriate_total_topping_time(string description, double expected)
        {
            //Arrange
            var topping = new Topping(_configurationServiceMock.Object);
            var timePerLetterTopping = 100;
            var configTopping = _configurationServiceMock
                .Setup(x => x.GetToppingCookingTime())
                .Returns(timePerLetterTopping);

            //Act
            var result = topping.CalculateTotalToppingTime(description);

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
