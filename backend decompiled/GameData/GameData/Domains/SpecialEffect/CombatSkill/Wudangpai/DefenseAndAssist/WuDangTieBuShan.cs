using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;

public class WuDangTieBuShan : DefenseSkillBase
{
	private const sbyte ReduceDamagePercent = -15;

	private bool _affected;

	public WuDangTieBuShan()
	{
	}

	public WuDangTieBuShan(CombatSkillKey skillKey)
		: base(skillKey, 4500)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnCompareDataCalcFinished(CombatContext context, DamageCompareData compareData)
	{
		if (base.CombatChar == context.Defender && base.CanAffect)
		{
			if (base.IsDirect)
			{
				int totalDefend = compareData.OuterDefendValue + compareData.InnerDefendValue;
				compareData.OuterDefendValue = (compareData.InnerDefendValue = totalDefend / 2);
			}
			else
			{
				int totalAttack = compareData.OuterAttackValue + compareData.InnerAttackValue;
				compareData.OuterAttackValue = (compareData.InnerAttackValue = totalAttack / 2);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(1);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && context.Defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			_affected = true;
			return -15;
		}
		return 0;
	}
}
