using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 分段攻击结果
/// </summary>
[Flags]
[SerializeAs(typeof(byte))]
public enum ESkillDamageSectionResult : byte
{
	/// <summary>
	/// 未判定
	/// </summary>
	Uncheck = 0,
	/// <summary>
	/// 已判定
	/// </summary>
	Checked = 1,
	/// <summary>
	/// 命中
	/// </summary>
	Hit = 2,
	/// <summary>
	/// 暴击
	/// </summary>
	Critical = 4
}
