using CoffeeMachine.DataProcessor.Models;
using CoffeeMachine.DataProcessor.Services;

namespace CoffeeMachine.DataProcessor.Test.Services
{
    public class CoffeeCountStoreServiceTests
    {
        [Fact]
        public void ShouldWriteOutputToConsole()
        {
            //Arrange
            var _writer = new StringWriter();   
            var _countStoreService = new CoffeeCountStoreService(_writer);
            var item = new CoffeeCountItem("Mocha", 7);

            //Act
            _countStoreService.Save(item);

            //Assert
            var result = _writer.ToString();
            Assert.Equal($"{item.CoffeeType}: {item.Count}{Environment.NewLine}", result);
        }
    }
}
