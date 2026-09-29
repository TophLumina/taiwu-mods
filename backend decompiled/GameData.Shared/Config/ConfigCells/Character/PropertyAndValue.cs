using System;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PropertyAndValue(short propertyId, short value)
{
	public readonly short PropertyId = propertyId;

	public readonly short Value = value;
}
