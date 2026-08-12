using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Common;

public abstract class AddDamage : CombatSkillEffectBase
{
	protected const short MaxAddDamage = 180;

	protected AddDamage()
	{
		IsLegendaryBookEffect = true;
	}

	protected AddDamage(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(274, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(69, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && !base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.SilenceSkill(context, base.CombatChar, base.SkillTemplateId, -1, -1);
		}
	}

	protected abstract int GetAddDamagePercent();

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey || base.CombatChar.GetAutoCastingSkill())
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 69 || fieldId == 274) ? true : false)
		{
			return Math.Min(GetAddDamagePercent(), 180);
		}
		return 0;
	}
}
