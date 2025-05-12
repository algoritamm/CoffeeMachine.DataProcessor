namespace CoffeeMachine.DataProcessor.Models
{
    //if class is mutable, i.e all properties are readonly, then instead class use record
    public record MachineDataItem(string CoffeeType, DateTime CreatedAt);

    /*
    public class MachineDataItem
    {
        
        public MachineDataItem(string coffeeType, DateTime createdAt) 
        {
            CreatedAt = createdAt;
            CoffeeType = coffeeType;
        }
        public DateTime CreatedAt { get; }
        public string CoffeeType { get; }
    }*/

}
