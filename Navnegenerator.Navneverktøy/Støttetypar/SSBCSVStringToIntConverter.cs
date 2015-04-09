using System;
using CsvHelper.TypeConversion;

namespace Navnegenerator.Navneverktøy.Støttetypar
{
    internal class SSBCSVStringToIntConverter : ITypeConverter
    {
        public string ConvertToString(TypeConverterOptions options, object value)
        {
            throw new NotImplementedException();
        }

        public object ConvertFromString(TypeConverterOptions options, string text)
        {
            var result = 0;
            int.TryParse(text, out result);
            return result;
        }

        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            throw new NotImplementedException();
        }
    }
}