using GameData.Serializer;

namespace GameData.Domains.LegendaryBook;

/// <summary>
/// 奇书突破盘数量状态
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum ELegendaryBookSlotState : sbyte
{
	/// <summary>
	/// 未解锁
	/// </summary>
	Locked = -1,
	/// <summary>
	/// 仅解锁阴
	/// </summary>
	OnlyYin,
	/// <summary>
	/// 仅解锁阳
	/// </summary>
	OnlyYang,
	/// <summary>
	/// 已解锁2个
	/// </summary>
	BothUnlocked
}
