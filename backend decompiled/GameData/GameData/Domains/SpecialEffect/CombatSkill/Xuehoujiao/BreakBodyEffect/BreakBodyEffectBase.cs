using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public abstract class BreakBodyEffectBase : SpecialEffectBase
{
	private const int AddFatalDamage = 33;

	private const sbyte BreakNeedInjury = 4;

	protected bool IsInner;

	protected short FeatureId;

	protected abstract bool IsAffectBodyParts(sbyte bodyPart);

	protected BreakBodyEffectBase()
	{
	}

	protected BreakBodyEffectBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AutoMonitor(ParseCharDataUid(26), OnInjuriesUpdate);
		CreateAffectedData(191, EDataModifyType.AddPercent, -1);
		CreateAffectedData(168, EDataModifyType.Custom, -1);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (defenderId == base.CharacterId && isInner == IsInner && IsAffectBodyParts(bodyPart) && damageValue > 0)
		{
			CombatCharacter defender = DomainManager.Combat.GetElement_CombatCharacterDict(defenderId);
			sbyte injury = defender.GetInjuries().Get(bodyPart, isInner);
			if (injury >= 4)
			{
				defender.AddFatalDamage(context, damageValue, -1, -1, -1);
			}
		}
	}

	private void OnInjuriesUpdate(DataContext context, DataUid dataUid)
	{
		Injuries injuries = CharObj.GetInjuries();
		bool allHealed = true;
		for (sbyte i = 0; i < 7; i++)
		{
			if (IsAffectBodyParts(i) && injuries.Get(i, IsInner) > 0)
			{
				allHealed = false;
				break;
			}
		}
		if (allHealed)
		{
			CharObj.RemoveFeature(context, FeatureId);
			DomainManager.SpecialEffect.Remove(context, Id);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 191)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		int type = dataKey.CustomParam0;
		if (type != (IsInner ? 1 : 0))
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		if (!IsAffectBodyParts(bodyPart))
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 33;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 168 && IsAffectBodyParts((sbyte)dataKey.CustomParam0) && dataKey.CustomParam1 == (IsInner ? 1 : 0))
		{
			return Math.Min(4, dataValue);
		}
		return dataValue;
	}

	protected override int GetSubClassSerializedSize()
	{
		int length = ((!IsAffectBodyParts(3) && !IsAffectBodyParts(5)) ? 1 : 2);
		return 1 + length + 1 + 2;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		int length = ((!IsAffectBodyParts(3) && !IsAffectBodyParts(5)) ? 1 : 2);
		pCurrData += 1 + length;
		*pCurrData = (IsInner ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = FeatureId;
		pCurrData += 2;
		return (int)(pCurrData - pData);
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData;
		int length = ((!IsAffectBodyParts(3) && !IsAffectBodyParts(5)) ? 1 : 2);
		pCurrData += 1 + length;
		IsInner = *pCurrData != 0;
		pCurrData++;
		FeatureId = *(short*)pCurrData;
		pCurrData += 2;
		return (int)(pCurrData - pData);
	}
}
