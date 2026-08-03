using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public class ChangeLegSkillHit : AgileSkillBase
{
	private const sbyte DirectAddPercent = 60;

	protected sbyte BuffHitType;

	private short _affectingLegSkill;

	protected ChangeLegSkillHit()
	{
	}

	protected ChangeLegSkillHit(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
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
		if (!base.CanAffect || combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		AutoRemove = false;
		_affectingLegSkill = legSkillId;
		if (AffectDatas == null || AffectDatas.Count == 0)
		{
			if (base.IsDirect)
			{
				AppendAffectedData(context, base.CharacterId, (ushort)(56 + BuffHitType), EDataModifyType.TotalPercent, legSkillId);
			}
			else
			{
				AppendAffectedData(context, base.CharacterId, 224, EDataModifyType.Custom, legSkillId);
			}
		}
		ShowSpecialEffectTips(0);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
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
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _affectingLegSkill)
		{
			return 0;
		}
		if (dataKey.FieldId == 56 + BuffHitType)
		{
			return 60;
		}
		return 0;
	}

	public unsafe override HitOrAvoidInts GetModifiedValue(AffectedDataKey dataKey, HitOrAvoidInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _affectingLegSkill)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 224)
		{
			sbyte transferValue = 0;
			for (sbyte hitType = 0; hitType < 3; hitType++)
			{
				if (hitType != BuffHitType)
				{
					sbyte changedValue = (sbyte)Math.Max(dataValue.Items[hitType] / 20 * 10, 10);
					transferValue = (sbyte)(transferValue + dataValue.Items[hitType] - changedValue);
					dataValue.Items[hitType] = changedValue;
				}
			}
			ref int reference = ref dataValue.Items[BuffHitType];
			reference += transferValue;
		}
		return dataValue;
	}
}
