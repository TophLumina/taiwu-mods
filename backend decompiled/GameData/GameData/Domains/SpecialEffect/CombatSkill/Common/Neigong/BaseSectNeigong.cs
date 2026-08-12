using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class BaseSectNeigong : CombatSkillEffectBase
{
	private const sbyte DirectAddMaxPower = 30;

	private const sbyte ReverseReduceRequirementPercent = -10;

	protected sbyte SectId;

	protected BaseSectNeigong()
	{
	}

	protected BaseSectNeigong(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 200, -1), EDataModifyType.Add);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 202, -1), EDataModifyType.Add);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.CombatSkillId >= 0 && Config.CombatSkill.Instance[dataKey.CombatSkillId].SectId == SectId)
		{
			if (dataKey.FieldId == 200)
			{
				return 30;
			}
			if (dataKey.FieldId == 202)
			{
				return -10;
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
		*pCurrData = (byte)SectId;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		SectId = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
