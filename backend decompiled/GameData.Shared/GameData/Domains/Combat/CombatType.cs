using System;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗类型
/// </summary>
[Serializable]
public enum CombatType : sbyte
{
	/// <summary>
	/// 切磋
	/// </summary>
	Play,
	/// <summary>
	/// 恶斗
	/// </summary>
	Beat,
	/// <summary>
	/// 死斗
	/// </summary>
	Die,
	/// <summary>
	/// 接招
	/// </summary>
	Test
}
