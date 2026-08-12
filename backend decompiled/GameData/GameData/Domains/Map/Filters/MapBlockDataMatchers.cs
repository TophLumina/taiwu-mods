namespace GameData.Domains.Map.Filters;

public static class MapBlockDataMatchers
{
	public static bool IsNormalOrWild(MapBlockData blockData)
	{
		EMapBlockType blockType = blockData.BlockType;
		return blockType == EMapBlockType.Normal || blockType == EMapBlockType.Wild;
	}

	public static bool HasNoIntelligentCharacter(MapBlockData blockData)
	{
		return blockData.CharacterSet == null && blockData.InfectedCharacterSet == null;
	}

	public static bool IsValidForRandomEnemy(MapBlockData blockData)
	{
		return blockData.BlockSubType != EMapBlockSubType.DLCLoong;
	}

	public static bool IsValidForJuniorXiangshu(MapBlockData blockData)
	{
		return blockData.BlockSubType != EMapBlockSubType.DLCLoong;
	}

	public static bool CanBeRuinedByXiangshu(MapBlockData blockData)
	{
		return blockData.TemplateId != 38 && !blockData.IsCityTown() && blockData.BlockSubType != EMapBlockSubType.DLCLoong;
	}
}
