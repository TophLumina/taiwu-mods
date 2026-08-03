namespace GameData.Domains.Combat;

/// <summary>
/// 标记类型
/// </summary>
public enum EMarkType
{
	/// <summary>
	/// 无效类型
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 外伤
	/// </summary>
	Outer,
	/// <summary>
	/// 内伤
	/// </summary>
	Inner,
	/// <summary>
	/// 破绽
	/// </summary>
	Flaw,
	/// <summary>
	/// 封穴
	/// </summary>
	Acupoint,
	/// <summary>
	/// 毒素
	/// </summary>
	Poison,
	/// <summary>
	/// 失神
	/// </summary>
	Mind,
	/// <summary>
	/// 重创
	/// </summary>
	Fatal,
	/// <summary>
	/// 必死
	/// </summary>
	Die,
	/// <summary>
	/// 蛊虫
	/// </summary>
	Wug,
	/// <summary>
	/// 内息
	/// </summary>
	QiDisorder,
	/// <summary>
	/// 状态
	/// </summary>
	State,
	/// <summary>
	/// 真气
	/// </summary>
	NeiliAllocation,
	/// <summary>
	/// 健康
	/// </summary>
	Health,
	/// <summary>
	/// 愈合
	/// </summary>
	Scar,
	/// <summary>
	/// 疲敝
	/// </summary>
	Tired
}
