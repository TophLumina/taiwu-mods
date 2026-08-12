using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.FistAndPalm;

public class ZhangXueGong : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 3;

	protected override short DirectStateId => 216;

	protected override short ReverseStateId => 217;

	public ZhangXueGong()
	{
	}

	public ZhangXueGong(CombatSkillKey skillKey)
		: base(skillKey, 10102)
	{
	}
}
