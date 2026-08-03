using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class XunHu : AddWuTrick
{
	public XunHu()
	{
	}

	public XunHu(CombatSkillKey skillKey)
		: base(skillKey, 17040)
	{
		AddTrickCount = 3;
	}
}
