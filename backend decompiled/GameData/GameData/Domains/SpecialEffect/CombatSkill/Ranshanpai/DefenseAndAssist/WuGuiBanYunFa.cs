using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class WuGuiBanYunFa : DefenseSkillBase
{
	public WuGuiBanYunFa()
	{
	}

	public WuGuiBanYunFa(CombatSkillKey skillKey)
		: base(skillKey, 7500)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
	}

	private void OnCompareDataCalcFinished(CombatContext context, DamageCompareData compareData)
	{
		if (base.CombatChar == context.Defender && base.CanAffect && (base.IsDirect ? (compareData.OuterDefendValue < compareData.InnerAttackValue) : (compareData.InnerDefendValue < compareData.OuterAttackValue)))
		{
			int save = (base.IsDirect ? compareData.OuterDefendValue : compareData.InnerDefendValue);
			if (base.IsDirect)
			{
				compareData.OuterDefendValue = compareData.InnerAttackValue;
				compareData.InnerAttackValue = save;
			}
			else
			{
				compareData.InnerDefendValue = compareData.OuterAttackValue;
				compareData.OuterAttackValue = save;
			}
			ShowSpecialEffectTips(0);
		}
	}
}
