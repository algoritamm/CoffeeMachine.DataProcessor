namespace CoffeeMachine.DataProcessor.Exceptions
{
    public class InvalidLineLengthException : Exception
    {
        public InvalidLineLengthException()        {   }
        public InvalidLineLengthException(string message) : base(message) { }
        public InvalidLineLengthException(string message, Exception inner) : base(message, inner) { }
    }
}
