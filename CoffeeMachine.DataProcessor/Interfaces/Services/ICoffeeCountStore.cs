using CoffeeMachine.DataProcessor.Models;

namespace CoffeeMachine.DataProcessor.Interfaces.Services
{
    public interface ICoffeeCountStore
    {
       void Save(CoffeeCountItem item);
    }
}
