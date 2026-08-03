namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇状态类型
/// </summary>
public enum EAdventureStatusType : byte
{
	/// <summary>
	/// 正在抓取不可生成的必要人物
	/// </summary>
	Preparing,
	/// <summary>
	/// 可以进入
	/// </summary>
	Ready,
	/// <summary>
	/// 已进入，不可继续抓人
	/// </summary>
	Entered,
	/// <summary>
	/// 因特殊原因隐藏，不可进入
	/// </summary>
	Hide,
	/// <summary>
	/// 正在释放所有资源
	/// </summary>
	Releasing
}
