using CoffeeMachine.DataProcessor.Interfaces.Services;
using CoffeeMachine.DataProcessor.Models;

namespace CoffeeMachine.DataProcessor.Services
{
    public class CoffeeCountStoreService : ICoffeeCountStore
    {
        private readonly TextWriter _textWriter;

        public CoffeeCountStoreService() : this(Console.Out)
        {
            
        }

        public CoffeeCountStoreService(TextWriter textWriter)
        {
            _textWriter = textWriter;   
        }

        public void Save(CoffeeCountItem item)
        {
            var line = item == null ? string.Empty : $"{item.CoffeeType}: {item.Count}";
            _textWriter.WriteLine(line);
        }
    }
}
