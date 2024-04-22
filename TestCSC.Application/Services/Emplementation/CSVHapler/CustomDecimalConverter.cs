using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace TestCSV.Application.Services.Emplementation.CSVHapler
{
    public class CustomDecimalConverter : DefaultTypeConverter
    {

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            try
            {
                var result = Convert.ToDecimal(text);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}
