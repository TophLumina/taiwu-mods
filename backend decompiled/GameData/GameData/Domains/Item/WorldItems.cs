using System.Collections.Generic;
using System.Text;
using GameData.Domains.Map;

namespace GameData.Domains.Item;

public class WorldItems
{
	public readonly Dictionary<int, HashSet<ItemKey>> CharacterItems;

	public readonly Dictionary<int, HashSet<ItemKey>> GraveItems;

	public readonly Dictionary<int, HashSet<ItemKey>> KidnapperItems;

	public readonly HashSet<ItemKey> WarehouseItems;

	public readonly HashSet<ItemKey> JiaoPoolItems;

	public readonly HashSet<ItemKey> CricketShowroomItems;

	public readonly Dictionary<Location, HashSet<ItemKey>> MapBlockItems;

	public readonly Dictionary<int, HashSet<ItemKey>> MerchantItems;

	public readonly Dictionary<int, HashSet<ItemKey>> CaravanItems;

	public readonly HashSet<ItemKey> ShopBuildingEarnItems;

	public readonly HashSet<ItemKey> TeaHorseCaravanItems;

	public WorldItems()
	{
		CharacterItems = new Dictionary<int, HashSet<ItemKey>>();
		GraveItems = new Dictionary<int, HashSet<ItemKey>>();
		KidnapperItems = new Dictionary<int, HashSet<ItemKey>>();
		WarehouseItems = new HashSet<ItemKey>();
		JiaoPoolItems = new HashSet<ItemKey>();
		CricketShowroomItems = new HashSet<ItemKey>();
		MapBlockItems = new Dictionary<Location, HashSet<ItemKey>>();
		MerchantItems = new Dictionary<int, HashSet<ItemKey>>();
		CaravanItems = new Dictionary<int, HashSet<ItemKey>>();
		ShopBuildingEarnItems = new HashSet<ItemKey>();
		TeaHorseCaravanItems = new HashSet<ItemKey>();
	}

	public override string ToString()
	{
		StringBuilder text = new StringBuilder();
		text.Append("Character: ");
		text.Append(GetItemsCount(CharacterItems));
		text.Append(", Grave: ");
		text.Append(GetItemsCount(GraveItems));
		text.Append(", Kidnapper: ");
		text.Append(GetItemsCount(KidnapperItems));
		text.Append(", Warehouse: ");
		text.Append(GetItemsCount(WarehouseItems));
		text.Append(", CricketShowroom: ");
		text.Append(GetItemsCount(CricketShowroomItems));
		text.Append(", MapBlock: ");
		text.Append(GetItemsCount(MapBlockItems));
		text.Append(", Merchant: ");
		text.Append(GetItemsCount(MerchantItems));
		text.Append(", Caravan: ");
		text.Append(GetItemsCount(CaravanItems));
		text.Append(", ShopBuildingEarnItems: ");
		text.Append(GetItemsCount(ShopBuildingEarnItems));
		text.Append(", TeaHorseCaravanItems: ");
		text.Append(GetItemsCount(TeaHorseCaravanItems));
		text.Append(", JiaoPool: ");
		text.Append(GetItemsCount(JiaoPoolItems));
		return text.ToString();
	}

	private static int GetItemsCount<T>(Dictionary<T, HashSet<ItemKey>> collection)
	{
		int count = 0;
		foreach (KeyValuePair<T, HashSet<ItemKey>> item in collection)
		{
			count += item.Value.Count;
		}
		return count;
	}

	private static int GetItemsCount(HashSet<ItemKey> collection)
	{
		return collection.Count;
	}
}
