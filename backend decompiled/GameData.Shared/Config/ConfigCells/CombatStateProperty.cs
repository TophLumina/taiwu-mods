using System;

namespace Config.ConfigCells;

[Serializable]
public struct CombatStateProperty(short specialEffectDataId, short value, sbyte modifyType)
{
	public short SpecialEffectDataId = specialEffectDataId;

	public short Value = value;

	public sbyte ModifyType = modifyType;
}
