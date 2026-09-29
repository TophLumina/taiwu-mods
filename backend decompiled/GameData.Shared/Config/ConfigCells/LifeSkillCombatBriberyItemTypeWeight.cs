using System;

namespace Config.ConfigCells;

[Serializable]
public struct LifeSkillCombatBriberyItemTypeWeight(sbyte itemType, short weight)
{
	public sbyte ItemType = itemType;

	public short Weight = weight;
}
