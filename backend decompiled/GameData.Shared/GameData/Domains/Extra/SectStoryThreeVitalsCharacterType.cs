using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 三魔/才类型
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum SectStoryThreeVitalsCharacterType
{
	/// <summary>
	/// 天
	/// </summary>
	Heaven,
	/// <summary>
	/// 地
	/// </summary>
	Earth,
	/// <summary>
	/// 人
	/// </summary>
	Human
}
