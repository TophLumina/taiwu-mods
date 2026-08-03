using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 功法突破盘玄机格类型
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum ESkillBreakPlateBonusType
{
	/// <summary>
	/// 未放置
	/// </summary>
	None,
	/// <summary>
	/// 道具类型
	/// </summary>
	Item,
	/// <summary>
	/// 关系类型
	/// </summary>
	Relation,
	/// <summary>
	/// 历练类型
	/// </summary>
	Exp,
	/// <summary>
	/// 亲友类型
	/// </summary>
	Friend
}
