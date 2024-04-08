using System.Globalization;
using System.IO;
using System.Xml.Linq;
using AC2.Map;
using CsvHelper;

namespace AC2
{
    public class Helper
    {
        public static List<Consum> CSVReader()
        {
            const string csvFilePath = @"..\..\..\CSV_Files\Consum_d_aigua_a_Catalunya_per_comarques_20240402.csv";

            List<Consum> recConsums;

            using var reader = new StreamReader(csvFilePath);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ConsumMap>();
                return csv.GetRecords<Consum>().ToList();
            }
            
        }
        public static void XMLConverter()
        {
            const string xmlFilePath = @"..\..\..\CACat_20240402.xml";
            XElement xmlConsum = new XElement("Consums",
                from consum in CSVReader()
                select new XElement("Consum",
                    new XElement("Any", consum.Any),
                    new XElement("CodiComarca", consum.CodiComarca),
                    new XElement("Comarca", consum.Comarca),
                    new XElement("Poblacio", consum.Poblacio),
                    new XElement("DomesticXarxa", consum.DomesticXarxa),
                    new XElement("Activitats", consum.Activitas),
                    new XElement("Total", consum.Total),
                    new XElement("ConsumDomesticPC", consum.ConsumDomesticPC)
                )
            );

            xmlConsum.Save(xmlFilePath);
        }
    }
}