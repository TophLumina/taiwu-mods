using GameData.Combat.Math;

namespace GameData.Combat.Cricket;

public readonly struct CricketCombatSkillPropertyModify(ECricketCombatPropertyModifyLifeCycle lifeCycle, ECricketCombatPropertyType propertyType, EDataModifyType modifyType, int modifyValue)
{
	public readonly ECricketCombatPropertyModifyLifeCycle LifeCycle = lifeCycle;

	public readonly ECricketCombatPropertyType PropertyType = propertyType;

	public readonly CValueModifyDelta ModifyDelta = new CValueModifyDelta(modifyType, modifyValue);

	public override string ToString()
	{
		return $"Modify({LifeCycle}.{PropertyType}.{ModifyDelta})";
	}
}
