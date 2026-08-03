using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class StrengthenMainAttribute : CombatSkillEffectBase
{
	private const sbyte AddMaxValue = 30;

	protected sbyte MainAttributeType;

	private ushort _fieldId;

	protected virtual bool ConsummateLevelRelatedMainAttributesHitAvoid => false;

	protected virtual bool ConsummateLevelRelatedMainAttributesPenetrations => false;

	protected StrengthenMainAttribute()
	{
	}

	protected StrengthenMainAttribute(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_fieldId = (ushort)(1 + MainAttributeType);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, _fieldId, -1), EDataModifyType.Add);
		if (ConsummateLevelRelatedMainAttributesHitAvoid)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 237 : 236), -1), EDataModifyType.Custom);
		}
		if (ConsummateLevelRelatedMainAttributesPenetrations)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 239 : 238), -1), EDataModifyType.Custom);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == _fieldId)
		{
			return 30;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam0 != MainAttributeType)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 236) <= 3u;
		return flag || dataValue;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)MainAttributeType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		MainAttributeType = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
