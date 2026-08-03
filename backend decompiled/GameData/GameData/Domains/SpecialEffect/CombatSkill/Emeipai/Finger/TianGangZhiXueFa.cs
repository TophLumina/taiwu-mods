using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class TianGangZhiXueFa : CombatSkillEffectBase
{
	public TianGangZhiXueFa()
	{
	}

	public TianGangZhiXueFa(CombatSkillKey skillKey)
		: base(skillKey, 2207, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 133 : 128), base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (base.IsDirect)
		{
			Events.RegisterHandler_AcuPointRemoved(OnFlawOrAcuPointRemoved);
		}
		else
		{
			Events.RegisterHandler_FlawRemoved(OnFlawOrAcuPointRemoved);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_AcuPointRemoved(OnFlawOrAcuPointRemoved);
		}
		else
		{
			Events.UnRegisterHandler_FlawRemoved(OnFlawOrAcuPointRemoved);
		}
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

	private void OnFlawOrAcuPointRemoved(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (IsSrcSkillPerformed && combatChar.IsAlly != base.CombatChar.IsAlly && DomainManager.Combat.IsCurrentCombatCharacter(combatChar) && level < GlobalConfig.Instance.AcupointBaseKeepTime.Length - 1)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddAcupoint(context, combatChar, (sbyte)(level + 1), SkillKey, bodyPart, 1, raiseEvent: false);
			}
			else
			{
				DomainManager.Combat.AddFlaw(context, combatChar, (sbyte)(level + 1), SkillKey, bodyPart, 1, raiseEvent: false);
			}
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 133 || dataKey.FieldId == 128)
		{
			return false;
		}
		return dataValue;
	}
}
