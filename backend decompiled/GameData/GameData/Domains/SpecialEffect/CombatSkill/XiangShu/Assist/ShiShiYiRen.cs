using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class ShiShiYiRen : RanChenZiAssistSkillBase
{
	public ShiShiYiRen()
	{
	}

	public ShiShiYiRen(CombatSkillKey skillKey)
		: base(skillKey, 16415)
	{
		RequireBossPhase = 5;
	}

	protected override void ActivateEffect(DataContext context)
	{
		base.CombatChar.Immortal = true;
		DomainManager.Combat.CastSkillFree(context, base.CombatChar, 869);
		DomainManager.Combat.SetBgmIndex(2, context);
	}
}
