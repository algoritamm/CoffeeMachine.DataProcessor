using CoffeeMachine.DataProcessor.Parsing;
using CoffeeMachine.DataProcessor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var _machineDataProcessorService = new MachineDataProcessorService(new CoffeeCountStoreService());

const string filename = "CustomerCoffeeData.csv";

try
{
    string[] lines = File.ReadAllLines(filename);

    Console.WriteLine("---------------------------------");
    Console.WriteLine(" Coffee machine - Data Processor ");
    Console.WriteLine("---------------------------------");
    Console.WriteLine();

    var machineDataItems = LineParser.Parse(lines);
    _machineDataProcessorService.ProcessItems(machineDataItems);

    Console.WriteLine();
    Console.WriteLine($"File `{filename}` was successfully processed!");
}
catch (ArgumentNullException err)
{
    Console.WriteLine(string.Format(err.Message, filename));
    Console.WriteLine();
}
catch (Exception err)
{
    Console.Error.WriteLine("----- ERROR LOG -----");
    Console.Error.WriteLine($"Message: {err.Message}");
    if (err.InnerException != null)
    {
        Console.Error.WriteLine($"InnerException: {err.InnerException.Message}");
    }
    Console.Error.WriteLine("StackTrace:");
    Console.Error.WriteLine(err.StackTrace);
    Console.Error.WriteLine();
}
