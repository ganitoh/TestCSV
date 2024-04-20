namespace TestCSV.Infrastructure.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException(string message) 
            : base(message) { }
    }
}
