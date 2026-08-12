using System;

namespace Config.ConfigCells;

/// <summary>
/// 较艺的AI贿赂玩家时的物品类型权重，格式为{材料-织物,0}
/// </summary>
[Serializable]
public struct LifeSkillCombatBriberyItemSubTypeWeight(short itemSubType, short weight)
{
	public short ItemSubType = itemSubType;

	public short Weight = weight;
}
