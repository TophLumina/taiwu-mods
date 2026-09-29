namespace GameData.Domains.Character;

public static class ResourceType
{
	public const sbyte Invalid = -1;

	public const sbyte Food = 0;

	public const sbyte Wood = 1;

	public const sbyte Metal = 2;

	public const sbyte Jade = 3;

	public const sbyte Fabric = 4;

	public const sbyte Herb = 5;

	public const sbyte Money = 6;

	public const sbyte Authority = 7;

	public const int Count = 8;

	public const int MaterialResourceCount = 6;

	public const int WealthResourceCount = 7;

	public static string GetName(sbyte type)
	{
		return type switch
		{
			0 => "Food", 
			1 => "Wood", 
			2 => "Metal", 
			3 => "Jade", 
			4 => "Fabric", 
			5 => "Herb", 
			6 => "Money", 
			7 => "Authority", 
			_ => string.Empty, 
		};
	}

	public static sbyte GetType(string name)
	{
		return name switch
		{
			"Food" => 0, 
			"Wood" => 1, 
			"Metal" => 2, 
			"Jade" => 3, 
			"Fabric" => 4, 
			"Herb" => 5, 
			"Money" => 6, 
			"Authority" => 7, 
			_ => -1, 
		};
	}
}
