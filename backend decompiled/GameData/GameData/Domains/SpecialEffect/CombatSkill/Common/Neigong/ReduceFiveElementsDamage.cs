using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class ReduceFiveElementsDamage : CombatSkillEffectBase
{
	private const sbyte DirectDamageReducePercent = -30;

	private const sbyte ReduceGongMadInjury = -50;

	protected sbyte RequireSelfFiveElementsType;

	protected sbyte AffectFiveElementsType;

	protected ReduceFiveElementsDamage()
	{
	}

	protected ReduceFiveElementsDamage(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 117, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		sbyte selfNeiliFiveElementsType = (sbyte)NeiliType.Instance[CharObj.GetNeiliType()].FiveElements;
		if (dataKey.CombatSkillId >= 0 && selfNeiliFiveElementsType == RequireSelfFiveElementsType && FiveElementsEquals(dataKey, AffectFiveElementsType))
		{
			if (dataKey.FieldId == 117)
			{
				return -50;
			}
			if (dataKey.FieldId == 102)
			{
				return -30;
			}
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
		*pCurrData = (byte)RequireSelfFiveElementsType;
		pCurrData++;
		*pCurrData = (byte)AffectFiveElementsType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		RequireSelfFiveElementsType = (sbyte)(*pCurrData);
		pCurrData++;
		AffectFiveElementsType = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
