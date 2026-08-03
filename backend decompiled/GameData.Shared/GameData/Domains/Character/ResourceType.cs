namespace GameData.Domains.Character;

/// <summary>
/// 资源类型
/// </summary>
public static class ResourceType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 食材
	/// </summary>
	public const sbyte Food = 0;

	/// <summary>
	/// 木材
	/// </summary>
	public const sbyte Wood = 1;

	/// <summary>
	/// 金铁
	/// </summary>
	public const sbyte Metal = 2;

	/// <summary>
	/// 玉石
	/// </summary>
	public const sbyte Jade = 3;

	/// <summary>
	/// 织物
	/// </summary>
	public const sbyte Fabric = 4;

	/// <summary>
	/// 药材
	/// </summary>
	public const sbyte Herb = 5;

	/// <summary>
	/// 银钱
	/// </summary>
	public const sbyte Money = 6;

	/// <summary>
	/// 威望
	/// </summary>
	public const sbyte Authority = 7;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 8;

	/// <summary>
	/// 材料资源个数 (材料资源处于列表的最前面)
	/// </summary>
	public const int MaterialResourceCount = 6;

	/// <summary>
	/// 财富资源个数 (财富资源处于列表的最前面)
	/// </summary>
	public const int WealthResourceCount = 7;

	/// <summary>
	/// 获取类型的名称
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 根据名称获取类型
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
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
