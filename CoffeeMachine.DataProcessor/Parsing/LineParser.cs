using CoffeeMachine.DataProcessor.Exceptions;
using CoffeeMachine.DataProcessor.Models;

namespace CoffeeMachine.DataProcessor.Parsing
{
    public class LineParser
    {
        public static List<MachineDataItem> Parse(string[] lines)
        {
            if(lines == null || lines.Count() == 0)
                throw new ArgumentNullException("message", "File `{0}` is empty!");

            var machineDataItem = new List<MachineDataItem>();

            try
            {
                foreach (var line in lines)
                {
                    if(string.IsNullOrEmpty(line.Trim()))
                        continue;

                    var item = Parse(line);
                    machineDataItem.Add(item);
                }
                return machineDataItem;
            }
            catch (InvalidOperationException err)
            {
                LogError(err);
                return machineDataItem;
            }
            catch (InvalidLineLengthException err)
            {
                LogError(err);
                return machineDataItem;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private static void LogError(Exception err)
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

        private static MachineDataItem Parse(string line)
        {
            var lineArray = line.Split(";").Select(x => x.Trim()).ToArray();

            if (lineArray.Length != 2)
                throw new InvalidLineLengthException($"Error: Invalid line `{line}` length!");

            if (!DateTime.TryParse(lineArray[1], out var datetime))
                throw new InvalidOperationException($"Error: Invalid datetime `{lineArray[1]}` format!");

            var coffeeItem = new MachineDataItem(lineArray[0], datetime);

            return coffeeItem;           
        }
    }
}
