using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

public class NeiliAllocationChangeInjury : AssistSkillBase
{
	private const short DamageChangePercent = 15;

	protected byte RequireNeiliAllocationType;

	private bool _affected;

	protected NeiliAllocationChangeInjury()
	{
	}

	protected NeiliAllocationChangeInjury(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 102 : 69), -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && base.CombatChar == (base.IsDirect ? defender : attacker))
		{
			_affected = false;
			ShowSpecialEffectTips(0);
			ShowEffectTips(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && base.CombatChar == (base.IsDirect ? context.Defender : context.Attacker))
		{
			_affected = false;
			ShowSpecialEffectTips(0);
			ShowEffectTips(context);
		}
	}

	public unsafe override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect || (!base.IsDirect && (!DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) || base.CombatChar.TeammateBeforeMainChar >= 0)))
		{
			return 0;
		}
		NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		short selfValue = selfNeiliAllocation.Items[(int)RequireNeiliAllocationType];
		NeiliAllocation enemyNeiliAllocation = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetNeiliAllocation();
		short enemyValue = enemyNeiliAllocation.Items[(int)RequireNeiliAllocationType];
		if (!(base.IsDirect ? (selfValue > enemyValue) : (selfValue > enemyValue * 2)))
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 102 : 69))
		{
			_affected = true;
			return base.IsDirect ? (-15) : 15;
		}
		return 0;
	}
}
