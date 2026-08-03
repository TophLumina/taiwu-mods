using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class YangXianGongJinShenFa : DefenseSkillBase
{
	private const sbyte TrickCountUnit = 3;

	private const sbyte DirectChangeDamageUnit = -10;

	private const sbyte ReverseChangeDamageUnit = 10;

	private bool _affected;

	public YangXianGongJinShenFa()
	{
	}

	public YangXianGongJinShenFa(CombatSkillKey skillKey)
		: base(skillKey, 2606)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.TotalPercent);
			Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
			Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 70, -1), EDataModifyType.AddPercent);
			Events.RegisterHandler_BounceInjury(OnBounceInjury);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
			Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		}
		else
		{
			Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && context.DefenderId == base.CharacterId)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (_affected)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		int usableTrickCount = base.CombatChar.UsableTrickCount;
		int changeDamageCount = (base.IsDirect ? (usableTrickCount / 3) : usableTrickCount);
		if (changeDamageCount <= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			_affected = true;
			return -10 * changeDamageCount;
		}
		if (dataKey.FieldId == 70)
		{
			_affected = true;
			return 10 * changeDamageCount;
		}
		return 0;
	}
}
