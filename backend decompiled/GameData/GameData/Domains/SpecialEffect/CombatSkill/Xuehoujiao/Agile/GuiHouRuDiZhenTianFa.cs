using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;

public class GuiHouRuDiZhenTianFa : AgileSkillBase
{
	private const sbyte AddDamagePercent = 30;

	private short _affectingLegSkill;

	public GuiHouRuDiZhenTianFa()
	{
	}

	public GuiHouRuDiZhenTianFa(CombatSkillKey skillKey)
		: base(skillKey, 15603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	private void OnCastLegSkillWithAgile(DataContext context, CombatCharacter combatChar, short legSkillId)
	{
		if (base.CanAffect && combatChar == base.CombatChar)
		{
			AutoRemove = false;
			_affectingLegSkill = legSkillId;
			if (AffectDatas == null || AffectDatas.Count == 0)
			{
				AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, legSkillId);
			}
			ShowSpecialEffectTips(0);
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _affectingLegSkill)
		{
			Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
			if (AgileSkillChanged)
			{
				RemoveSelf(context);
			}
			else
			{
				AutoRemove = true;
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId != _affectingLegSkill || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return 30;
		}
		return 0;
	}
}
