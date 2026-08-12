namespace GameData.Domains.CombatSkill;

/// <summary>
/// 命中或化解类型
/// </summary>
public static class AttackHitType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 力道 / 卸力
	/// </summary>
	public const sbyte Strength = 0;

	/// <summary>
	/// 精妙 / 拆招
	/// </summary>
	public const sbyte Technique = 1;

	/// <summary>
	/// 迅疾 / 闪避
	/// </summary>
	public const sbyte Speed = 2;

	/// <summary>
	/// 动心 / 守心
	/// </summary>
	public const sbyte Mind = 3;

	/// <summary>
	/// 命中类型个数
	/// </summary>
	public const int Count = 4;
}
