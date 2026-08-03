namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 额外伤害数据
/// </summary>
public class PawnDamageInfo
{
	public int Damage;

	public bool IsTaiwuCasted;

	public bool IsToSelf;

	/// <summary>
	/// 是否为策略伤害，策略伤害不会被视为 该论点对对方造成的伤害
	/// </summary>
	public bool IsStrategyDamage;

	public PawnDamageInfo(int damage, bool isTaiwuCasted, bool isToSelf, bool isStrategyDamage = false)
	{
		Damage = damage;
		IsTaiwuCasted = isTaiwuCasted;
		IsToSelf = isToSelf;
		IsStrategyDamage = isStrategyDamage;
	}
}
