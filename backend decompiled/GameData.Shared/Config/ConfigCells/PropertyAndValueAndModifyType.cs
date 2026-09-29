using System;
using GameData.Combat.Math;

namespace Config.ConfigCells;

[Serializable]
public struct PropertyAndValueAndModifyType(short type, int value, EDataModifyType modify)
{
	public readonly ECharacterPropertyReferencedType Type = (ECharacterPropertyReferencedType)type;

	public readonly int Value = value;

	public readonly EDataModifyType Modify = modify;

	public PropertyAndValueAndModifyType(short propertyId, int value, sbyte modifyType)
		: this(propertyId, value, (EDataModifyType)modifyType)
	{
	}

	public PropertyAndValueAndModifyType(short propertyId, int value, bool percent)
		: this(propertyId, value, percent ? EDataModifyType.AddPercent : EDataModifyType.Add)
	{
	}

	public static implicit operator CValueModifyDelta(PropertyAndValueAndModifyType pvm)
	{
		return new CValueModifyDelta(pvm.Modify, pvm.Value);
	}
}
