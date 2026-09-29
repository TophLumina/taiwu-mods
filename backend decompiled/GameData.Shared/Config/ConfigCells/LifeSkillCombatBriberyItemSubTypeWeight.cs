using System;

namespace Config.ConfigCells;

[Serializable]
public struct LifeSkillCombatBriberyItemSubTypeWeight(short itemSubType, short weight)
{
	public short ItemSubType = itemSubType;

	public short Weight = weight;
}
