using CsvHelper.Configuration;

namespace TestCSV.Application.Services.Abstraction
{
    public interface ICsvHalperParser<TEntity> 
        : ICsvParser<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> Parse<TEntityMapClass>(MemoryStream fileStream) 
            where TEntityMapClass : ClassMap;

        IEnumerable<TEntity> Parse<TEntityMapClass>(string fileName)
            where TEntityMapClass : ClassMap;

    }
}
