using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace AC2
{
    public class Program
    {
        public static void Main()
        {
            const string Menu = "Introdueix la acció que vols realitzar:\n1-Identificar les comarques amb una població superior a 200000.\n2-Calcular el consum domèstic mitjà per comarca.\n3-Mostrar les comarques amb el consum domèstic per càpita més alt\n4-Mostrar les comarques amb el consum domèstic per càpita més baix.\n5-Filtrar les comarques per nom o codi.";
            const string IncorrectOption = "Introdueix una opció numerica del menú";
            int selection;
            Helper.XMLConverter();
            do
            {
                Console.WriteLine(Menu);
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection < 1 || selection > 5)
                {
                    Console.Clear();
                    Console.WriteLine(IncorrectOption);
                }
            }while (selection < 1||selection >5);
            switch (selection)
            {
                case 1:
                    Helper.PopulationSearch(200000);
                    break;
                case 2:
                    Helper.ConsumDomMitjaPC();
                    break;
                case 3:
                    Helper.ComarquesMaxConsum();
                    break;
                case 4:
                    Helper.ComarquesMinConsum();
                    break;
                case 5:
                    break;
            }
        }
    }
}