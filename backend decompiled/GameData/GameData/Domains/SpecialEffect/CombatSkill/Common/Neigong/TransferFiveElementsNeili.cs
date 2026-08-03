using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class TransferFiveElementsNeili : CombatSkillEffectBase
{
	private const sbyte AddPowerRatio = 10;

	protected sbyte SrcFiveElementsType;

	protected sbyte DestFiveElementsType;

	protected TransferFiveElementsNeili()
	{
	}

	protected TransferFiveElementsNeili(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 26, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 234, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
	}

	public unsafe override NeiliProportionOfFiveElements GetModifiedValue(AffectedDataKey dataKey, NeiliProportionOfFiveElements dataValue)
	{
		ref sbyte reference = ref dataValue.Items[DestFiveElementsType];
		reference += dataValue.Items[SrcFiveElementsType];
		dataValue.Items[SrcFiveElementsType] = 0;
		return dataValue;
	}

	public unsafe override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || dataKey.FieldId != 234)
		{
			return dataValue;
		}
		NeiliProportionOfFiveElements baseProportion = CharObj.GetBaseNeiliProportionOfFiveElements();
		if (baseProportion.Items[SrcFiveElementsType] > 0)
		{
			return dataValue;
		}
		if (!FiveElementsEqualsEnemy(dataKey.CombatSkillId, SrcFiveElementsType) && !FiveElementsEqualsEnemy(dataKey.CombatSkillId, DestFiveElementsType))
		{
			return dataValue;
		}
		ShowSpecialEffectTips(0);
		return false;
	}

	public unsafe override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId >= 0 && FiveElementsEquals(dataKey, DestFiveElementsType))
		{
			NeiliProportionOfFiveElements proportion = CharObj.GetNeiliProportionOfFiveElements();
			NeiliProportionOfFiveElements baseProportion = CharObj.GetBaseNeiliProportionOfFiveElements();
			return Math.Max(proportion.Items[DestFiveElementsType] - baseProportion.Items[DestFiveElementsType], 0) / 10;
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1 + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)SrcFiveElementsType;
		pCurrData++;
		*pCurrData = (byte)DestFiveElementsType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		SrcFiveElementsType = (sbyte)(*pCurrData);
		pCurrData++;
		DestFiveElementsType = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
