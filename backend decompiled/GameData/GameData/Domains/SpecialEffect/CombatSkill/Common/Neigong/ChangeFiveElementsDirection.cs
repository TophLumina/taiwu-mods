using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class ChangeFiveElementsDirection : CombatSkillEffectBase
{
	private readonly CostNeiliAllocationImplement _costNeiliAllocationImplement;

	protected abstract sbyte FiveElementsType { get; }

	protected abstract byte NeiliAllocationType { get; }

	private CostNeiliAllocationImplement NewCostNeiliAllocationImplement => new CostNeiliAllocationImplement(CostNeiliAllocationImplement.EType.AddRange, CostNeiliAllocationImplement.EType.DamageCannotReduce, FiveElementsType, NeiliAllocationType);

	protected ChangeFiveElementsDirection()
	{
		_costNeiliAllocationImplement = NewCostNeiliAllocationImplement;
		_costNeiliAllocationImplement.EffectBase = this;
	}

	protected ChangeFiveElementsDirection(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		_costNeiliAllocationImplement = NewCostNeiliAllocationImplement;
		_costNeiliAllocationImplement.EffectBase = this;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 240, -1), EDataModifyType.Custom);
		_costNeiliAllocationImplement.OnEnable(context);
		_costNeiliAllocationImplement.AutoAffectedData();
	}

	public override void OnDisable(DataContext context)
	{
		_costNeiliAllocationImplement.OnDisable(context);
	}

	public override List<CastBoostEffectDisplayData> GetModifiedValue(AffectedDataKey dataKey, List<CastBoostEffectDisplayData> dataValue)
	{
		return _costNeiliAllocationImplement.GetModifiedValue(dataKey, dataValue);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return _costNeiliAllocationImplement.GetModifyValue(dataKey, currModifyValue);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		return _costNeiliAllocationImplement.GetModifiedValue(dataKey, dataValue);
	}

	public override BoolArray8 GetModifiedValue(AffectedDataKey dataKey, BoolArray8 dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.CustomParam0 == 5)
		{
			dataValue[FiveElementsType] = true;
		}
		return dataValue;
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
