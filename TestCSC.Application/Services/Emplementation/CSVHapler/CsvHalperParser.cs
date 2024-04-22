using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using System.Globalization;
using System.IO;
using TestCSV.Application.Services.Abstraction;

namespace TestCSV.Application.Services.Emplementation.CSVHapler
{
    public class CsvHalperParser<TEntity>
        : ICsvHalperParser<TEntity>
        where TEntity : class
    {
        private readonly IMediator _mediator;

        public CsvHalperParser(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ParseAndSaveAsync<TEntityMapClass>(MemoryStream fileStream)
            where TEntityMapClass : ClassMap
        {
            using var streamReader = new StreamReader(fileStream);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,

            };

            
            using CsvReader csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Context.RegisterClassMap<TEntityMapClass>();
            csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
            csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

            foreach (var item in csvReader.GetRecords<TEntity>())
                await _mediator.Send(item);
        }

        public async Task ParseAndSaveAsync<TEntityMapClass>(string fileName)
            where TEntityMapClass : ClassMap
        {
            using var streamReader = new StreamReader(fileName);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,

            };

            using CsvReader csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Context.RegisterClassMap<TEntityMapClass>();
            csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
            csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

            foreach (var item in csvReader.GetRecords<TEntity>())
                await _mediator.Send(item);

        }

        public async Task ParseAndSaveAsync(MemoryStream fileStream)
        {
            using var streamReader = new StreamReader(fileStream);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,

            };

            using CsvReader csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
            csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

            foreach (var item in csvReader.GetRecords<TEntity>())
                await _mediator.Send(item);
        }

        public async Task ParseAndSaveAsync(string filePath)
        {
            using var streamReader = new StreamReader(filePath);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                BadDataFound = null,

            };

            using CsvReader csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Context.TypeConverterCache.AddConverter<int>(new CustomInt32Converter());
            csvReader.Context.TypeConverterCache.AddConverter<decimal>(new CustomDecimalConverter());

            foreach (var item in csvReader.GetRecords<TEntity>())
                await _mediator.Send(item);
        }

    }
}
