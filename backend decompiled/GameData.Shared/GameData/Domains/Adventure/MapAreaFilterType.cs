namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇生成区域筛选规则类型
/// </summary>
public static class MapAreaFilterType
{
	/// 表示不限定在什么地区发生
	public const sbyte None = -1;

	/// 太吾村所在地区(MapStateId要求自动失效)
	public const sbyte TaiwuVillageArea = 0;

	/// 省份主要城市所在地区
	public const sbyte MainArea = 1;

	/// 省份门派所属地区
	public const sbyte SectArea = 2;

	/// 非主要城市和门派所在地区
	public const sbyte SecondaryArea = 3;
}
