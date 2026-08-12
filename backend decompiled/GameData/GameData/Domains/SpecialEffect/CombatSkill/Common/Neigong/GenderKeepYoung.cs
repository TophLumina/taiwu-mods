using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class GenderKeepYoung : CombatSkillEffectBase
{
	private const sbyte AddPower = 10;

	private const sbyte AddMaxMainAttribute = 20;

	private const int ReverseChangeNeiliAllocationPercent = 100;

	private const int DirectChangeFatalDamageValueTotalPercent = -50;

	private const int ReverseChangeFatalDamageValueTotalPercent = 100;

	private const int ReverseChangeFatalDamageCountMultiplier = 2;

	protected sbyte RequireGender;

	private DataUid _featureUid;

	protected abstract sbyte ReduceFatalDamageValueType { get; }

	protected GenderKeepYoung()
	{
	}

	protected GenderKeepYoung(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 1, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 2, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 3, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 4, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 5, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 6, -1), EDataModifyType.Add);
		}
		else
		{
			Events.RegisterHandler_ChangeNeiliAllocationAfterCombatBegin(ChangeNeiliAllocationAfterCombatBegin);
		}
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 191, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 192, -1), EDataModifyType.Custom);
		if (CharObj.GetGender() == RequireGender)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 25, -1), EDataModifyType.Custom);
		}
		_featureUid = new DataUid(4, 0, (ulong)base.CharacterId, 17u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_featureUid, base.DataHandlerKey, OnFeaturesChange);
	}

	public override void OnDataAdded(DataContext context)
	{
		UpdateAvatar(context);
	}

	public override void OnDisable(DataContext context)
	{
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_ChangeNeiliAllocationAfterCombatBegin(ChangeNeiliAllocationAfterCombatBegin);
		}
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_featureUid, base.DataHandlerKey);
		UpdateAvatar(context);
	}

	private void ChangeNeiliAllocationAfterCombatBegin(DataContext context, CombatCharacter character, NeiliAllocation allocationAfterBegin)
	{
		if (character.GetId() == base.CharacterId && character.GetNeiliAllocation().GetTotal() == allocationAfterBegin.GetTotal())
		{
			ShowSpecialEffectTips(1);
			character.ChangeAllNeiliAllocation(context, 100, raiseEvent: true, applyChallengeModeQiDisorder: false);
		}
	}

	private void OnFeaturesChange(DataContext context, DataUid dataUid)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 25);
	}

	private void UpdateAvatar(DataContext context)
	{
		AvatarData avatar = CharObj.GetAvatar();
		if (avatar.UpdateGrowableElementsShowingAbilities(CharObj))
		{
			CharObj.SetAvatar(avatar, context);
		}
	}

	private bool IsAffectType(int type)
	{
		return base.IsDirect ? (type == ReduceFatalDamageValueType) : (type != ReduceFatalDamageValueType);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 191 && IsAffectType(dataKey.CustomParam0))
		{
			EDamageType damageType = (EDamageType)dataKey.CustomParam1;
			if (damageType != EDamageType.Direct && base.IsDirect)
			{
				return 0;
			}
			ShowSpecialEffectTips(0);
			return base.IsDirect ? (-50) : 100;
		}
		if (CharObj.HasVirginity() && dataKey.FieldId == 199)
		{
			return 10;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 1) <= 5u)
		{
			return 20;
		}
		return 0;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (CharObj.HasVirginity() && dataKey.FieldId == 25)
		{
			return Math.Min(dataValue, GlobalConfig.Instance.RejuvenatedAge);
		}
		if (dataKey.FieldId == 192 && dataKey.CustomParam2 == 0 && !base.IsDirect && IsAffectType(dataKey.CustomParam0))
		{
			ShowSpecialEffectTips(0);
			return dataValue * 2;
		}
		return dataValue;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)RequireGender;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		RequireGender = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
