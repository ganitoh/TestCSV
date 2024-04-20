using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TestCSV.Application.Services.Abstraction;

namespace TestCSV.Application.Services.Emplementation
{
    public class CsvHalperParser<TEntity> 
        : ICsvHalperParser<TEntity>
        where TEntity : class
    {
        public  IEnumerable<TEntity> Parse<TEntityMapClass>(MemoryStream fileStream)
            where TEntityMapClass : ClassMap
        {
            using var streamReader = new StreamReader(fileStream);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null
            };

            using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
            {
                csvReader.Context.RegisterClassMap<TEntityMapClass>();
                csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
                csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

                return csvReader.GetRecords<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> Parse(MemoryStream fileStream)
        {
            using var streamReader = new StreamReader(fileStream);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null
            };

            using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
            {
                csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
                csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

                return csvReader.GetRecords<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> Parse<TEntityMapClass>(string fileName)
            where TEntityMapClass : ClassMap
        {
            using var streamReader = new StreamReader(fileName);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null
            };

            using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
            {
                csvReader.Context.RegisterClassMap<TEntityMapClass>();
                csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
                csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

                return csvReader.GetRecords<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> Parse(string filePath)
        {
            using var streamReader = new StreamReader(filePath);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null
            };

            using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
            {
                csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
                csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

                return csvReader.GetRecords<TEntity>().ToList();
            }
        }
    }
}
