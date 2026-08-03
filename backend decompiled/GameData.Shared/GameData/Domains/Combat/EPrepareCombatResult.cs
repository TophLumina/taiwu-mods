using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 准备战斗结果
/// </summary>
[SerializeAs(typeof(int))]
public enum EPrepareCombatResult
{
	/// <summary>
	/// 无效值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 己方先手
	/// </summary>
	SelfFirst,
	/// <summary>
	/// 敌方先手
	/// </summary>
	EnemyFirst,
	/// <summary>
	/// 平手随机决定先后手
	/// </summary>
	EqualsRandom
}
