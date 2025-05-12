using CoffeeMachine.DataProcessor.Interfaces.Services;
using CoffeeMachine.DataProcessor.Models;
using CoffeeMachine.DataProcessor.Services;

namespace CoffeeMachine.DataProcessor.Test.Services
{
    public class MachineDataProcessorServiceTests : IDisposable
    {
        private readonly TestCoffeeCountStore _coffeeCountStore;
        private readonly MachineDataProcessorService _machineDataProcessor;

        //Constructor runs before every test
        public MachineDataProcessorServiceTests()
        {
            _coffeeCountStore = new TestCoffeeCountStore();
            _machineDataProcessor = new MachineDataProcessorService(_coffeeCountStore);
        }

        [Fact]
        public void ShouldSaveCountPerCoffeeType()
        {
            //Arrange
            var items = new List<MachineDataItem>()
            {
                new MachineDataItem("Espresso", new DateTime(2025,5,16,11,15,24)),
                new MachineDataItem("Espresso", new DateTime(2025,5,16,12,17,24)),
                new MachineDataItem("Mocha", new DateTime(2025,5,16,11,45,44))
            };

            //Act
            _machineDataProcessor.ProcessItems(items);

            //Assert
            Assert.Equal(2, _coffeeCountStore.SavedItems.Count);

            var item = _coffeeCountStore.SavedItems[0];
            Assert.Equal("Espresso", item.CoffeeType);
            Assert.Equal(2, item.Count);

            item = _coffeeCountStore.SavedItems[1];
            Assert.Equal("Mocha", item.CoffeeType);
            Assert.Equal(1, item.Count);


        }

        [Fact]
        public void ShouldClearPreviousCoffeeCount()
        {
            //Arrange
            var items = new List<MachineDataItem>()
            {
                new MachineDataItem("Espresso", new DateTime(2025,5,16,11,15,24)),
            };

            //Act
            _machineDataProcessor.ProcessItems(items);
            _machineDataProcessor.ProcessItems(items);

            //Assert
            Assert.Equal(2, _coffeeCountStore.SavedItems.Count);

            foreach(var item in _coffeeCountStore.SavedItems)
            {
                Assert.Equal("Espresso", item.CoffeeType);
                Assert.Equal(1, item.Count);
            }
        }

        public void Dispose()
        {
            //This runs after every test
            //This use for cleanup
            //For this test is empty
        }
    }

    public class TestCoffeeCountStore : ICoffeeCountStore
    {
        public List<CoffeeCountItem> SavedItems { get; } = new();

        public void Save(CoffeeCountItem item)
        {
            SavedItems.Add(item);
        }
    }

}
