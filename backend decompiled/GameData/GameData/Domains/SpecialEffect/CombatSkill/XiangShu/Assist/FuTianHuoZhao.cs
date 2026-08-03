using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class FuTianHuoZhao : RanChenZiAssistSkillBase
{
	public FuTianHuoZhao()
	{
	}

	public FuTianHuoZhao(CombatSkillKey skillKey)
		: base(skillKey, 16413)
	{
		RequireBossPhase = 3;
	}

	protected override void ActivateEffect(DataContext context)
	{
		base.CombatChar.LockMaxBreath = true;
		base.CombatChar.LockMaxStance = true;
		ChangeBreathValue(context, base.CombatChar, 30000);
		ChangeStanceValue(context, base.CombatChar, 4000);
		DomainManager.Combat.SetBgmIndex(1, context);
	}

	protected override void DeactivateEffect(DataContext context)
	{
		base.CombatChar.LockMaxBreath = false;
		base.CombatChar.LockMaxStance = false;
	}
}
