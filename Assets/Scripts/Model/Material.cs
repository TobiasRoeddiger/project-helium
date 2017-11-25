using System.Collections;
using System.Collections.Generic;

public partial class MaterialSample 
{
	/// <summary>
	/// Produktfamilie
	/// </summary>
	public string Family { get; set; }
	/// <summary>
	/// Unterfamilie / Klassenkennung
	/// </summary>
	public string SubFamily { get; set; }
	/// <summary>
	/// Materialnummer
	/// </summary>
	public string MaterialCode { get; set; }
	/// <summary>
	/// Werkstoffart
	/// </summary>
	public virtual string Type { 
		get { 
			return "Generic Material";
		}
	}

	/// <summary>
	/// Elastizitätsmodul (MPa)
	/// </summary>
	public double ElasticModulus { get; set; }
	/// <summary>
	/// Dichte (kg/m^3)
	/// </summary>
	public double Density { get; set; }
	/// <summary>
	/// Zugfestigkeit (kPa)
	/// </summary>
	public double TensileStrength { get; set; }
	/// <summary>
	/// Bruchdehnung (%)
	/// </summary>
	public double ElongationAtRupture { get; set; }

	public string Name 
	{
		get 
		{
			return string.Format ("{0} {1} - {2}", Family, SubFamily, MaterialCode);
		}
	}
}

public class FoamMaterial : MaterialSample 
{
	public override string Type 
	{
		get 
		{
			return "Foam";
		}
	}
}

public class TechnicalPlasticMaterial : MaterialSample
{
	public override string Type 
	{
		get 
		{
			return "Technical Plastic";
		}
	}
}


public class MetalMaterial : MaterialSample
{
	public override string Type 
	{
		get 
		{
			return "Metal";
		}
	}
} 
