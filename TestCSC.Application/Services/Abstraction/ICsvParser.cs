namespace TestCSV.Application.Services.Abstraction
{
    public interface ICsvParser<TEntity> where TEntity : class
    {
        Task ParseAndSaveAsync(MemoryStream fileStream);
        Task ParseAndSaveAsync(string filePath);
    }
}
