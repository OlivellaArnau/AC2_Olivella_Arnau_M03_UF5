using System.Runtime.CompilerServices;

namespace AC2;
public class Consum
{
	public int Any {  get; set; }
	public int CodiComarca { get; set; }
	public string? Comarca { get; set; }
	public int Poblacio { get; set; }
	public int DomesticXarxa { get; set; }
	public int Activitats { get; set; }
	public int Total { get; set; }
	public float ConsumDomesticPC { get; set; }

	public string ConsumWriter()
	{
		return $"Any:{Any}\nCodi Comarca:{CodiComarca}\nComarca:{Comarca}\nPoblació:{Poblacio}\nXarxa Domestica:{DomesticXarxa}\nActivitats:{Activitats}\nTotal{Total}\nConsum Domestic per Capita:{ConsumDomesticPC}";
	}
}
