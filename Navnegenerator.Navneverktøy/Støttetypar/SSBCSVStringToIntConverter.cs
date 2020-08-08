using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Navnegenerator.Navneverktøy.Støttetypar
{
    internal class SSBCSVStringToIntConverter : ITypeConverter
    {

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) {
            throw new NotImplementedException();
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) {
            var result = 0;
            int.TryParse(text, out result);
            return result;
        }
    }
}