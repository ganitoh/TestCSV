using CsvHelper.Configuration;

namespace TestCSV.Application.Services.Abstraction
{
    public interface ICsvHalperParser<TEntity> 
        : ICsvParser<TEntity> 
        where TEntity : class
    {
        Task ParseAndSaveAsync<TEntityMapClass>(MemoryStream fileStream) 
            where TEntityMapClass : ClassMap;

        Task ParseAndSaveAsync<TEntityMapClass>(string fileName)
            where TEntityMapClass : ClassMap;

    }
}
