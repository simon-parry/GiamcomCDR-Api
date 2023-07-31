using CsvHelper.Configuration;

namespace GiacomCDR_Api.Models
{
    public class CsvRow
    {
        [CsvHelper.Configuration.Attributes.Index(0)]
        public string caller_id { get; set; } = string.Empty;

        [CsvHelper.Configuration.Attributes.Index(1)]
        public string recipient { get; set; } = string.Empty;

        [CsvHelper.Configuration.Attributes.Index(2)]
        public DateTime call_date { get; set; }

        [CsvHelper.Configuration.Attributes.Index(3)]
        public string end_time { get; set; } = string.Empty;

        [CsvHelper.Configuration.Attributes.Index(4)]
        public int duration { get; set; }

        [CsvHelper.Configuration.Attributes.Index(5)]
        public decimal cost { get; set; }

        [CsvHelper.Configuration.Attributes.Index(6)]
        public string reference { get; set; } = string.Empty;

        [CsvHelper.Configuration.Attributes.Index(7)]
        public string currency { get; set; } = string.Empty;
    }

    internal class CsvRowMap : ClassMap<CsvRow>
    {
        public CsvRowMap()
        {
            Map(m => m.call_date)
                .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
                .TypeConverterOption.Format("dd/mm/yyyy");
            Map(m => m.caller_id);
            Map(m => m.recipient);
            Map(m => m.end_time);
            Map(m => m.duration);
            Map(m => m.cost);
            Map(m => m.reference);
            Map(m => m.currency);
        }
    }
}


