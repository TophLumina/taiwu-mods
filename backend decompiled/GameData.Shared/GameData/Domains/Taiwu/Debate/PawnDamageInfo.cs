namespace GameData.Domains.Taiwu.Debate;

public class PawnDamageInfo
{
	public int Damage;

	public bool IsTaiwuCasted;

	public bool IsToSelf;

	public bool IsStrategyDamage;

	public PawnDamageInfo(int damage, bool isTaiwuCasted, bool isToSelf, bool isStrategyDamage = false)
	{
		Damage = damage;
		IsTaiwuCasted = isTaiwuCasted;
		IsToSelf = isToSelf;
		IsStrategyDamage = isStrategyDamage;
	}
}
