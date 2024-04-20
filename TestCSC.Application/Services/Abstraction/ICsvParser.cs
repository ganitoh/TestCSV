namespace TestCSV.Application.Services.Abstraction
{
    public interface ICsvParser<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Parse(MemoryStream fileStream);
        IEnumerable<TEntity> Parse(string filePath);
    }
}
