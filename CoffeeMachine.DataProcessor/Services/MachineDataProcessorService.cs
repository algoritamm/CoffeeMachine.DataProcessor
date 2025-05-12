using CoffeeMachine.DataProcessor.Interfaces.Services;
using CoffeeMachine.DataProcessor.Models;

namespace CoffeeMachine.DataProcessor.Services
{
    public class MachineDataProcessorService
    {

        private readonly Dictionary<string, int> _countPerCoffeeType = new();
        private readonly ICoffeeCountStore _coffeeCountStore;

        public MachineDataProcessorService() {   }
        public MachineDataProcessorService(ICoffeeCountStore coffeeCountStore)
        {
            _coffeeCountStore = coffeeCountStore;
        }

        public void ProcessItems(List<MachineDataItem> items)
        {
            _countPerCoffeeType.Clear();

            if (items == null || items.Count() == 0)
                return;

            foreach (MachineDataItem item in items)
            {
                ProcessItem(item);
            }

            SaveCountPerCoffeeType();
        }


        private void SaveCountPerCoffeeType()
        {
            foreach (var entry in _countPerCoffeeType)
            {
                _coffeeCountStore.Save(new CoffeeCountItem(entry.Key, entry.Value)); 
            }
        }

        private void ProcessItem(MachineDataItem item)
        {
            if (!_countPerCoffeeType.ContainsKey(item.CoffeeType))
            {
                _countPerCoffeeType.Add(item.CoffeeType, 1);
            }
            else
            {
                _countPerCoffeeType[item.CoffeeType]++;
            }
        }
    }
}