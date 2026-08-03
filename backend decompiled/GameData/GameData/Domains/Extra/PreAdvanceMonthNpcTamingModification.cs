using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;

namespace GameData.Domains.Extra;

public class PreAdvanceMonthNpcTamingModification
{
	public List<(int, Location, ItemKey)> TamerRecords = new List<(int, Location, ItemKey)>();
}
