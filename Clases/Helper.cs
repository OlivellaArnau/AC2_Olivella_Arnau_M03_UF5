using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AC2.Map;
using CsvHelper;

namespace AC2
{
    public class Helper
    {
        public static void XMLConverter()
        {
            const string csvFilePath = @"..\..\..\CSV_Files\Consum_d_aigua_a_Catalunya_per_comarques_20240402.csv";
            const string xmlFilePath = @"..\..\..\XML_Files\Consum_d_aigua_a_Catalunya_per_comarques_20240402.xml";
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture)
            {
            csv.Context.RegisterClassMap<>(ConsumMap);
            var recConsums = csv.GetRecords<Consum>().ToList();
            }
            XElement xmlConsum = new XElement("Consums", from consum in recConsums select new XElement("Consum",
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
