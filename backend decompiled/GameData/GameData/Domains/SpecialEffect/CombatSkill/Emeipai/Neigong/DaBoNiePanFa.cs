using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class DaBoNiePanFa : CombatSkillEffectBase
{
	private static readonly sbyte[] AddPower = new sbyte[3] { 1, 3, 5 };

	private const sbyte ReincarnationBonusFeatureAddPower = 20;

	private const sbyte ProfessionReincarnationBonusFeatureAddPower = 10;

	private sbyte _addPowerValue;

	private DataUid _featureUid;

	public DaBoNiePanFa()
	{
	}

	public DaBoNiePanFa(CombatSkillKey skillKey)
		: base(skillKey, 2007, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		_featureUid = ParseCharDataUid(17);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_featureUid, base.DataHandlerKey, OnFeaturesChange);
		UpdateAddPowerValue();
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_featureUid, base.DataHandlerKey);
	}

	private void UpdateAddPowerValue()
	{
		_addPowerValue = 0;
		List<short> featureIds = CharObj.GetFeatureIds();
		if (AnyReincarnationBonusFeature(featureIds))
		{
			_addPowerValue += 20;
		}
		if (AnyProfessionReincarnationBonusFeature(featureIds))
		{
			_addPowerValue += 10;
		}
		List<DeadCharacter> deadCharList = DomainManager.Character.GetCharacterSamsaraData(base.CharacterId).DeadCharacters;
		sbyte fameThreshold = (sbyte)(base.IsDirect ? 4 : 2);
		for (int i = 0; i < deadCharList.Count; i++)
		{
			if (deadCharList[i] != null)
			{
				sbyte fameType = deadCharList[i].FameType;
				bool flag = ((fameType < 0 || fameType > 6) ? true : false);
				if (!flag && !(base.IsDirect ? (fameType < fameThreshold) : (fameType > fameThreshold)))
				{
					_addPowerValue += AddPower[base.IsDirect ? (fameType - fameThreshold) : (fameThreshold - fameType)];
				}
			}
		}
	}

	private bool AnyReincarnationBonusFeature(List<short> featureIds)
	{
		return featureIds.Exists(base.IsDirect ? new Predicate<short>(GameData.Domains.Character.Character.IsPositiveReincarnationBonusFeature) : new Predicate<short>(GameData.Domains.Character.Character.IsNegativeReincarnationBonusFeature));
	}

	private bool AnyProfessionReincarnationBonusFeature(List<short> featureIds)
	{
		return featureIds.Exists(base.IsDirect ? new Predicate<short>(GameData.Domains.Character.Character.IsProfessionPositiveReincarnationBonusFeature) : new Predicate<short>(GameData.Domains.Character.Character.IsProfessionNegativeReincarnationBonusFeature));
	}

	private void OnFeaturesChange(DataContext context, DataUid dataUid)
	{
		UpdateAddPowerValue();
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPowerValue;
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)_addPowerValue;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		_addPowerValue = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
