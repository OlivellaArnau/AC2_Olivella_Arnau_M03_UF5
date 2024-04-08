using CsvHelper.Configuration;
namespace AC2.Map
{
    public class ConsumMap : ClassMap <Consum>
    {
        public ConsumMap()
        {
            Map(x => x.Any).Name("Any");
            Map(x => x.CodiComarca).Name("Codi comarca");
            Map(x => x.Comarca).Name("Comarca");
            Map(x => x.Poblacio).Name("Població");
            Map(x => x.DomesticXarxa).Name("Domèstic xarxa");
            Map(x => x.Activitats).Name("Activitats econòmiques i fonts pròpies");
            Map(x => x.Total).Name("Total");
            Map(x => x.ConsumDomesticPC).Name("Consum domèstic per càpita");
        }
    }
}
