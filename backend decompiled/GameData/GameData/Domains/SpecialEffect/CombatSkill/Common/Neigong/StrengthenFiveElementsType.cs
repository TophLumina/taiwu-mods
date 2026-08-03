using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class StrengthenFiveElementsType : CombatSkillEffectBase
{
	protected abstract int DirectAddPower { get; }

	protected abstract int ReverseReduceCostPercent { get; }

	protected abstract sbyte FiveElementsType { get; }

	protected StrengthenFiveElementsType()
	{
	}

	protected StrengthenFiveElementsType(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(199, EDataModifyType.Add, -1);
		}
		else
		{
			CreateAffectedData(204, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.CombatSkillId >= 0 && FiveElementsEquals(dataKey, FiveElementsType))
		{
			if (dataKey.FieldId == 199 && base.IsDirect)
			{
				return DirectAddPower;
			}
			if (dataKey.FieldId == 204)
			{
				return ReverseReduceCostPercent;
			}
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1 + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		base.SerializeSubClass(pData);
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		base.DeserializeSubClass(pData);
		return GetSubClassSerializedSize();
	}
}
