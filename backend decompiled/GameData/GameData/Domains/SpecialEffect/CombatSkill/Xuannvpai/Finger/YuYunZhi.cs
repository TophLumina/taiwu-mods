using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class YuYunZhi : CombatSkillEffectBase
{
	public YuYunZhi()
	{
	}

	public YuYunZhi(CombatSkillKey skillKey)
		: base(skillKey, 8202, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		ShowSpecialEffectTips(0);
		CreateAffectedData(325, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && damageValue > 0 && base.IsDirect != isInner)
		{
			if (DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).GetDefeatMarkCollection().GetTotalCount() > DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).GetDefeatMarkCollection().GetTotalCount())
			{
				ShowSpecialEffectTips(1);
			}
			else
			{
				DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.CombatChar, bodyPart, (!isInner) ? damageValue : 0, isInner ? damageValue : 0, combatSkillId);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 325 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
