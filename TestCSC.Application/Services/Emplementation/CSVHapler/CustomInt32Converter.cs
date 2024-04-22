using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace TestCSV.Application.Services.Emplementation.CSVHapler
{
    public class CustomInt32Converter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text.Contains('-'))
                return Convert.ToInt32(text.Split('-')[1]);
            else if (text.Contains('>'))
                return Convert.ToInt32(text.Trim('>'));
            else if (text.Contains('<'))
                return Convert.ToInt32(text.Trim('<'));
            else
                return Convert.ToInt32(text);

        }
    }
}
