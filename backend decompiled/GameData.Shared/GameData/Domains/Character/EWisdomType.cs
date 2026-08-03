using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 机略类型
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EWisdomType
{
	/// <summary>
	/// 无类型
	/// </summary>
	None = -1,
	/// <summary>
	/// 正向（蓝）
	/// </summary>
	Positive,
	/// <summary>
	/// 负向（红）
	/// </summary>
	Negative
}
