using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Serializer;

namespace GameData.Domains.SpecialEffect.CombatSkill;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatStateEffect : SpecialEffectBase
{
	private readonly sbyte _stateType;

	private readonly bool _reverse;

	private readonly Dictionary<ushort, (short value, EDataModifyType modifyType, int[] requireCustomParam)> _fieldDict = new Dictionary<ushort, (short, EDataModifyType, int[])>();

	private short _statePower;

	public CombatStateEffect()
	{
	}

	public CombatStateEffect(int charId, sbyte stateType, short stateId, short power, bool reverse)
		: base(charId, -1)
	{
		_stateType = stateType;
		_reverse = reverse;
		List<CombatStateProperty> propertyList = CombatState.Instance[stateId].PropertyList;
		foreach (CombatStateProperty property in propertyList)
		{
			SpecialEffectDataFieldItem dataFieldConfig = SpecialEffectDataField.Instance[property.SpecialEffectDataId];
			ushort fieldId = AffectedDataHelper.FieldName2FieldId[dataFieldConfig.FieldName];
			_fieldDict.Add(fieldId, (property.Value, (EDataModifyType)property.ModifyType, dataFieldConfig.RequireCustomParam));
		}
		_statePower = power;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		foreach (KeyValuePair<ushort, (short, EDataModifyType, int[])> property in _fieldDict)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, property.Key, -1), property.Value.Item2);
		}
	}

	public void ChangePower(DataContext context, short power)
	{
		_statePower = power;
		InvalidateCache(context);
	}

	public void InvalidateCache(DataContext context)
	{
		foreach (ushort fieldId in _fieldDict.Keys)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, fieldId);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		(short, EDataModifyType, int[]) fieldInfo = _fieldDict[dataKey.FieldId];
		if ((fieldInfo.Item3[0] >= 0 && fieldInfo.Item3[0] != dataKey.CustomParam0) || (fieldInfo.Item3[1] >= 0 && fieldInfo.Item3[1] != dataKey.CustomParam1) || (fieldInfo.Item3[2] >= 0 && fieldInfo.Item3[2] != dataKey.CustomParam2))
		{
			return 0;
		}
		(int, int) totalPercentModify = DomainManager.SpecialEffect.GetTotalPercentModifyValue(base.CharacterId, -1, 155, _stateType);
		int totalPercent = Math.Max(100 + totalPercentModify.Item1 + totalPercentModify.Item2, 0);
		return fieldInfo.Item1 * _statePower / 100 * totalPercent / 100 * ((!_reverse) ? 1 : (-1));
	}
}
