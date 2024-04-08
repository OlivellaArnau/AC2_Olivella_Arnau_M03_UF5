using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization.DataContracts;
using System.Xml.Linq;
using System.Xml.XPath;
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
                    new XElement("Activitats", consum.Activitats),
                    new XElement("Total", consum.Total),
                    new XElement("ConsumDomesticPC", consum.ConsumDomesticPC)
                )
            );
            xmlConsum.Save(xmlFilePath);
        }
        public static void PopulationSearch(int PopulationNum)
        {
            XDocument xmlConsum = XDocument.Load(@"..\..\..\CACat_20240402.xml");
            var Comarques = (from x in xmlConsum.Descendants("Consum") where (int)x.Element("Poblacio")>PopulationNum select x).ToList();
            foreach (var Comarca in Comarques)
            {
                Console.WriteLine(Comarca.Element("Comarca"));
            }
        }
        public static double ConsumDomMitjaPC()
        {
            XDocument xmlConsum = XDocument.Load(@"..\..\..\CACat_20240402.xml");
            var consumos = xmlConsum.Descendants("Consum")
                                     .GroupBy(c => c.Element("Comarca").Value)
                                     .Select(group => new
                                     {
                                         Comarca = group.Key,
                                         ConsumoMedio = group.Average(c => double.Parse(c.Element("ConsumDomesticPC").Value))
                                     });

            Console.WriteLine("Consumo doméstico medio por comarca:");
            foreach (var consumo in consumos)
            {
                Console.WriteLine($"{consumo.Comarca}: {consumo.ConsumoMedio}");
            }

            return consumos.Average(c => c.ConsumoMedio);
        }
        public static void ComarquesMaxConsum()
        {
            XDocument xmlConsum = XDocument.Load(@"..\..\..\CACat_20240402.xml");
            var comarques = xmlConsum.Descendants("Consum")
                                      .OrderByDescending(c => double.Parse(c.Element("ConsumDomesticPC").Value))
                                      .Take(5)
                                      .Select(c => c.Element("Comarca").Value);

            Console.WriteLine("Comarcas con el consumo doméstico per cápita más alto:");
            foreach (var comarca in comarques)
            {
                Console.WriteLine(comarca);
            }
        }
        public static void ComarquesMinConsum()
        {
            XDocument xmlConsum = XDocument.Load(@"..\..\..\CACat_20240402.xml");
            var comarques = xmlConsum.Descendants("Consum")
                                      .OrderBy(c => double.Parse(c.Element("ConsumDomesticPC").Value))
                                      .Take(5)
                                      .Select(c => c.Element("Comarca").Value);

            Console.WriteLine("Comarcas con el consumo doméstico per cápita más bajo:");
            foreach (var comarca in comarques)
            {
                Console.WriteLine(comarca);
            }
        }
        public static void FiltrarComarques()
        {
            string filtro = Console.ReadLine();
            XDocument xmlConsum = XDocument.Load(@"..\..\..\CACat_20240402.xml");
            var comarques = xmlConsum.Descendants("Consum")
                                      .Where(c => c.Element("Comarca").Value.Contains(filtro) || c.Element("CodiComarca").Value == filtro)
                                      .Select(c => new
                                      {
                                          NomComarca = c.Element("Comarca").Value,
                                          CodiComarca = c.Element("CodiComarca").Value
                                      });

            Console.WriteLine($"Comarcas que coinciden con '{filtro}':");
            foreach (var comarca in comarques)
            {
                Console.WriteLine($"Nombre: {comarca.NomComarca}, Código: {comarca.CodiComarca}");
            }
        }

    }
}