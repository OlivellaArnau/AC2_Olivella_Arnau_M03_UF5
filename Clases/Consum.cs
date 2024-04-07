using System;
namespace AC2;
public class Consum
{
	public int Any {  get; set; }
	public int CodiComarca { get; set; }
	public string Comarca { get; set; }
	public int Poblacio { get; set; }
	public int DomesticXarxa { get; set; }
	public int Activitas { get; set; }
	public int Total { get; set; }
	public float ConsumDomesticPC { get; set; }

	public Consum (int any, int codiComarca, string comarca, int poblacio, int domesticXarxa, int activitats, int total, float consumDomesticPC)
	{
		Any = any;
		CodiComarca = codiComarca;
		Comarca = comarca;
		Poblacio = poblacio;
		DomesticXarxa = domesticXarxa;
		Activitas = activitats;
		Total = total;
		ConsumDomesticPC = consumDomesticPC;
	}
}
