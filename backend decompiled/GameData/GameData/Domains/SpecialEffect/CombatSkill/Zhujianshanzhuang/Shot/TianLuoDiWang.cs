using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class TianLuoDiWang : CombatSkillEffectBase
{
	public TianLuoDiWang()
	{
	}

	public TianLuoDiWang(CombatSkillKey skillKey)
		: base(skillKey, 9404, -1)
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
				AddMaxEffectCount();
				AppendAffectedAllEnemyData(context, 151, EDataModifyType.Custom, -1);
				ShowSpecialEffectTips(0);
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
		if (!IsSrcSkillPerformed || DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId).IsAlly == base.CombatChar.IsAlly || !DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 151 && dataValue != 0 && dataKey.CustomParam0 == (base.IsDirect ? 1 : 0))
		{
			int costEffectCount = Math.Min(Math.Abs(dataValue), base.EffectCount);
			ReduceEffectCount(costEffectCount);
			return dataValue + (base.IsDirect ? costEffectCount : (-costEffectCount));
		}
		return dataValue;
	}
}
