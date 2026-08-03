using System;

namespace Config.ConfigCells;

/// <summary>
/// 较艺的AI贿赂玩家时的物品类型权重，格式为{武器,0}
/// </summary>
[Serializable]
public struct LifeSkillCombatBriberyItemTypeWeight(sbyte itemType, short weight)
{
	public sbyte ItemType = itemType;

	public short Weight = weight;
}
