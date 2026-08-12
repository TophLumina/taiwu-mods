using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class RuYiBaoLunDao : CombatSkillEffectBase
{
	public RuYiBaoLunDao()
	{
	}

	public RuYiBaoLunDao(CombatSkillKey skillKey)
		: base(skillKey, 11206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				if (base.IsDirect)
				{
					AppendAffectedAllEnemyData(context, 166, EDataModifyType.Custom, -1);
				}
				else
				{
					AppendAffectedData(context, base.CharacterId, 166, EDataModifyType.Custom, -1);
				}
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (!DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) || dataKey.FieldId != 166)
		{
			return dataValue;
		}
		int stateType = dataKey.CustomParam0;
		if (stateType != (base.IsDirect ? 1 : 2))
		{
			return dataValue;
		}
		short stateId = (short)dataValue;
		int power = dataKey.CustomParam1;
		bool reverse = dataKey.CustomParam2 == 1;
		DataContext context = DomainManager.Combat.Context;
		CombatCharacter enemyChar = (base.IsDirect ? DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId) : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		var (rvsStateId, rvsReverse) = CombatDomain.CalcReversedCombatState(stateId, reverse);
		DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CombatChar : enemyChar, (sbyte)(base.IsDirect ? 1 : 2), stateId, power * 2, reverse, applyEffect: false);
		DomainManager.Combat.AddCombatState(context, base.IsDirect ? enemyChar : base.CombatChar, (sbyte)((!base.IsDirect) ? 1 : 2), rvsStateId, power, rvsReverse, applyEffect: false);
		ShowSpecialEffectTips(0);
		ReduceEffectCount();
		return -1;
	}
}
