using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class ShenHuoZhaoGong : DefenseSkillBase
{
	private const sbyte ReduceDamagePercent = -30;

	private const sbyte ChangeNeiliAllocation = 1;

	private bool _affected;

	public ShenHuoZhaoGong()
	{
	}

	public ShenHuoZhaoGong(CombatSkillKey skillKey)
		: base(skillKey, 14502)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
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
		if (_affected && context.Defender == base.CombatChar)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (attackerId == base.CharacterId && base.CanAffect)
		{
			if (base.IsDirect)
			{
				base.CombatChar.ChangeNeiliAllocation(context, 2, 1);
			}
			else
			{
				base.CurrEnemyChar.ChangeNeiliAllocation(context, 2, -1);
			}
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || dataKey.CustomParam0 != 1)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			_affected = true;
			return -30;
		}
		return 0;
	}
}
