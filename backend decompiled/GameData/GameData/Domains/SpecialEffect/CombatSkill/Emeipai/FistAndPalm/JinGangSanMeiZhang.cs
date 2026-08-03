using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;

public class JinGangSanMeiZhang : CombatSkillEffectBase
{
	private const sbyte ReduceNeiliAllocation = 5;

	private const sbyte ReducePenetrateResistPercent = 50;

	private bool _canAffect;

	public JinGangSanMeiZhang()
	{
	}

	public JinGangSanMeiZhang(CombatSkillKey skillKey)
		: base(skillKey, 2106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 215, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 74, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_canAffect = true;
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DamageCompareData damageCompareData = DomainManager.Combat.GetDamageCompareData();
			if (damageCompareData.AvoidValue[0] > damageCompareData.HitValue[0])
			{
				TryReduceNeiliAllocation(context);
			}
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index > 2)
		{
			return;
		}
		DamageCompareData damageCompareData = DomainManager.Combat.GetDamageCompareData();
		if (index < 2 && damageCompareData.AvoidValue[index + 1] > damageCompareData.HitValue[index + 1])
		{
			TryReduceNeiliAllocation(context);
		}
		if (index == 2 && _canAffect)
		{
			if (base.IsDirect)
			{
				damageCompareData.OuterDefendValue -= Math.Min(damageCompareData.InnerDefendValue * 50 / 100, damageCompareData.OuterDefendValue / 2);
			}
			else
			{
				damageCompareData.InnerDefendValue -= Math.Min(damageCompareData.OuterDefendValue * 50 / 100, damageCompareData.InnerDefendValue / 2);
			}
			DomainManager.Combat.SetDamageCompareData(damageCompareData, context);
			ShowSpecialEffectTips(0);
		}
	}

	private unsafe void TryReduceNeiliAllocation(DataContext context)
	{
		NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
		if (neiliAllocation.Items[3] >= 5)
		{
			base.CombatChar.ChangeNeiliAllocation(context, 3, -5);
		}
		else
		{
			_canAffect = false;
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 215)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_canAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 74)
		{
			return -1;
		}
		return dataValue;
	}
}
