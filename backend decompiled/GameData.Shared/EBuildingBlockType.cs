/// <summary>
/// BuildingBlock -&gt; Type
/// </summary>
public enum EBuildingBlockType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 普通资源
	/// </summary>
	NormalResource,
	/// <summary>
	/// 特殊资源
	/// </summary>
	SpecialResource,
	/// <summary>
	/// 无用资源
	/// </summary>
	UselessResource,
	/// <summary>
	/// 建筑
	/// </summary>
	Building,
	/// <summary>
	/// 核心建筑
	/// </summary>
	MainBuilding,
	/// <summary>
	/// 空地
	/// </summary>
	Empty,
	Count
}
