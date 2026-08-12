using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthLoseOverloadItemsModification
{
	public Character Character;

	public List<(MapBlockData block, ItemKey itemKey, int amount)> ItemsToBeLost;

	public PeriAdvanceMonthLoseOverloadItemsModification(Character character)
	{
		Character = character;
	}
}
