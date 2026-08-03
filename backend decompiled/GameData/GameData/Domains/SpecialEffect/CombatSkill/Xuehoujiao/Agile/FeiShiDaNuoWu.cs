using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;

public class FeiShiDaNuoWu : AgileSkillBase
{
	private short _affectingLegSkill;

	private const int AgileSkillRemainingTimeAddPercent = 20;

	public FeiShiDaNuoWu()
	{
	}

	public FeiShiDaNuoWu(CombatSkillKey skillKey)
		: base(skillKey, 15604)
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
		if (base.CanAffect && combatChar.GetId() == base.CharacterId)
		{
			AutoRemove = false;
			_affectingLegSkill = legSkillId;
			if (AffectDatas == null || AffectDatas.Count == 0)
			{
				AppendAffectedData(context, 325, EDataModifyType.Custom, legSkillId);
			}
			ShowSpecialEffectTips(0);
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId != base.CharacterId || skillId != _affectingLegSkill)
		{
			return;
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (AgileSkillChanged)
		{
			RemoveSelf(context);
			return;
		}
		AutoRemove = true;
		if (power == 100)
		{
			int agileAdd = 20 * MoveSpecialConstants.MaxMobility / 100;
			ChangeMobilityValue(context, base.CombatChar, agileAdd);
			ShowSpecialEffectTips(1);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CombatSkillId != _affectingLegSkill || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		if (dataKey.FieldId != 325 || dataKey.CustomParam2 != 1)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return false;
	}
}
