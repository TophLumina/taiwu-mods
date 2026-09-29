using System;
using Redzen.Random;

namespace Config.ConfigCells.Character;

[Serializable]
public struct CharacterFilterElement(int[] propertyType, int valueMin, int valueMax)
{
	public int PropertyType = propertyType[0];

	public int PropertySubType = ((propertyType.Length > 1) ? propertyType[1] : (-1));

	public int ValueMin = valueMin;

	public int ValueMax = valueMax;

	public bool IsFixed => ValueMax <= ValueMin;

	public int GetRandomValue(IRandomSource random)
	{
		if (ValueMin >= ValueMax)
		{
			return ValueMin;
		}
		return random.Next(ValueMin, ValueMax + 1);
	}
}
