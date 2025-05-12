using CoffeeMachine.DataProcessor.Parsing;

namespace CoffeeMachine.DataProcessor.Test.Parsing
{
    public class LineParserTests
    {
        [Fact]
        public void ShouldParseValidLine()
        {
            //Arrange
            string[] lines = new[] { "Cappuccino;2025-05-11T13:45:24" };

            //Act
            var machineDataItem = LineParser.Parse(lines);

            //Assert
            Assert.NotNull(machineDataItem);
            Assert.Single(machineDataItem);
            Assert.Equal("Cappuccino", machineDataItem.First().CoffeeType);
            Assert.Equal(new DateTime(2025,05,11,13,45,24), machineDataItem.First().CreatedAt);
        }

        [Fact]
        public void ShouldSkipEmptyLine()
        {
            //Arrange
            string[] lines = new[] { " " };

            //Act
            var machineDataItem = LineParser.Parse(lines);

            //Assert
            Assert.NotNull(machineDataItem);
            Assert.Empty(machineDataItem);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidLine()
        {
            //Arrange
            string[] lines = Array.Empty<string>();

            //Assert + Act
            var exception = Assert.Throws<ArgumentNullException>(() => LineParser.Parse(lines));
            Assert.Equal("File `{0}` is empty! (Parameter 'message')", exception.Message);
        }

        [InlineData("Espresso")]
        [InlineData("Cappuccino;")]
        [InlineData(";")]
        [Theory]
        public void ShouldThrowException(string line)
        {
            //Arrange
            string[] lines = new[] { line };

            //Act
            var item = LineParser.Parse(lines);

            //Assert
            Assert.NotNull(item);
            Assert.Empty(item);
        }
    }
}
