using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class BaWangDao : CombatSkillEffectBase
{
	public BaWangDao()
	{
	}

	public BaWangDao(CombatSkillKey skillKey)
		: base(skillKey, 6205, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (!IsSrcSkillPerformed && PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
				ShowSpecialEffectTips(0);
				AppendAffectedAllEnemyData(context, 151, EDataModifyType.Custom, -1);
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (IsSrcSkillPerformed && (outerMarkCount > 0 || innerMarkCount > 0))
		{
			ReduceEffectCount(outerMarkCount + innerMarkCount);
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
		if (!IsSrcSkillPerformed || !DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 151 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && DomainManager.Combat.InAttackRange(DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly)))
		{
			return 0;
		}
		return dataValue;
	}
}
