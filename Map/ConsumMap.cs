using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC2;

namespace AC2.Map
{
    public class ConsumMap : ClassMap <Consum>
    {
        public ConsumMap()
        {
            Map(x => x.Any).Name("Any");
            Map(x => x.CodiComarca).Name("CodiComarca");
            Map(x => x.Comarca).Name("Comarca");
            Map(x => x.Poblacio).Name("Poblacio");
            Map(x => x.DomesticXarxa).Name("DomesticXarxa");
            Map(x => x.Activitas).Name("Activitats");
            Map(x => x.Total).Name("Total");
            Map(x => x.ConsumDomesticPC).Name("ConsumDomesticPC");
        }
    }
}
