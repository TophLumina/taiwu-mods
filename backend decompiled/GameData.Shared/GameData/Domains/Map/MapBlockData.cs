using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.Story.MainStory;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Map;

public class MapBlockData : ISerializableGameData
{
	[SerializableGameDataField]
	public short AreaId;

	[SerializableGameDataField]
	public short BlockId;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short BelongBlockId;

	[SerializableGameDataField]
	public short RootBlockId;

	[SerializableGameDataField]
	public bool Visible;

	[SerializableGameDataField]
	public HashSet<int> CharacterSet;

	[SerializableGameDataField]
	public HashSet<int> InfectedCharacterSet;

	[SerializableGameDataField]
	public HashSet<int> FixedCharacterSet;

	[SerializableGameDataField]
	public HashSet<int> GraveSet;

	[SerializableGameDataField]
	public List<MapTemplateEnemyInfo> TemplateEnemyList;

	[SerializableGameDataField]
	public HashSet<int> EnemyCharacterSet;

	[SerializableGameDataField]
	public short Malice;

	[SerializableGameDataField]
	public bool Destroyed;

	[SerializableGameDataField]
	public MaterialResources MaxResources;

	[SerializableGameDataField]
	public MaterialResources CurrResources;

	[SerializableGameDataField]
	public SortedList<ItemKeyAndDate, int> Items;

	private static readonly LocalObjectPool<HashSet<int>> IntHashSetPool = new LocalObjectPool<HashSet<int>>(6144, 30720);

	private static readonly LocalObjectPool<List<MapTemplateEnemyInfo>> RandomEnemyListPool = new LocalObjectPool<List<MapTemplateEnemyInfo>>(3072, 15360);

	private static readonly ObjectPool<SortedList<ItemKeyAndDate, int>> ItemCollectionPool = new ObjectPool<SortedList<ItemKeyAndDate, int>>(3072, 15360);

	public List<MapBlockData> GroupBlockList;

	public const int MaxBlockItemCount = 500;

	public bool ShowDestroyed
	{
		get
		{
			if (Destroyed)
			{
				return !GetConfig().IgnoreDestroyed;
			}
			return false;
		}
	}

	public sbyte MoveCost => GetConfig()?.MoveCost ?? (-1);

	public int MoveCostActionPoint
	{
		get
		{
			int cost = MoveCost * 10;
			if (cost <= 0)
			{
				return cost;
			}
			cost *= ExternalDataBridge.Context.MoveTimeCostPercent;
			TwelveImmortalsCacheData cache = ExternalDataBridge.Context.TwelveImmortalsCache;
			Dictionary<Location, int> moveCostMultiplier = cache.MoveCostMultiplier;
			if (moveCostMultiplier != null && moveCostMultiplier.Count > 0)
			{
				cost *= cache.MoveCostMultiplier.GetOrDefault(GetLocation(), 1);
			}
			return Math.Max(1, cost);
		}
	}

	public EMapBlockType BlockType => GetConfig()?.Type ?? EMapBlockType.Invalid;

	public EMapBlockSubType BlockSubType => GetConfig()?.SubType ?? EMapBlockSubType.Invalid;

	public bool IsSingleBlock
	{
		get
		{
			if (RootBlockId < 0)
			{
				List<MapBlockData> groupBlockList = GroupBlockList;
				if (groupBlockList == null || groupBlockList.Count <= 0)
				{
					return GetConfig()?.Size == 1;
				}
			}
			return false;
		}
	}

	public MapBlockData(short areaId, short blockId, short templateId)
	{
		AreaId = areaId;
		BlockId = blockId;
		TemplateId = templateId;
		BelongBlockId = -1;
		RootBlockId = -1;
		Visible = false;
	}

	public static MapBlockData SimpleClone(MapBlockData other)
	{
		return new MapBlockData
		{
			AreaId = other.AreaId,
			BlockId = other.BlockId,
			TemplateId = other.TemplateId,
			BelongBlockId = other.BelongBlockId,
			RootBlockId = other.RootBlockId,
			Visible = other.Visible
		};
	}

	public MapBlockData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public unsafe int GetSerializedSize()
	{
		int totalSize = 38;
		totalSize = ((CharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CharacterSet.Count)));
		totalSize = ((InfectedCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * InfectedCharacterSet.Count)));
		totalSize = ((FixedCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FixedCharacterSet.Count)));
		totalSize = ((GraveSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * GraveSet.Count)));
		totalSize = ((TemplateEnemyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * TemplateEnemyList.Count)));
		totalSize = ((EnemyCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * EnemyCharacterSet.Count)));
		totalSize = ((Items == null) ? (totalSize + 2) : (totalSize + (2 + (4 + sizeof(ItemKey) + 4) * Items.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = AreaId;
		pCurrData += 2;
		*(short*)pCurrData = BlockId;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = BelongBlockId;
		pCurrData += 2;
		*(short*)pCurrData = RootBlockId;
		pCurrData += 2;
		*pCurrData = (Visible ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CharacterSet != null)
		{
			int elementsCount = CharacterSet.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (int charId in CharacterSet)
			{
				*(int*)pCurrData = charId;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InfectedCharacterSet != null)
		{
			int elementsCount2 = InfectedCharacterSet.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			foreach (int charId2 in InfectedCharacterSet)
			{
				*(int*)pCurrData = charId2;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FixedCharacterSet != null)
		{
			int elementsCount3 = FixedCharacterSet.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			foreach (int charId3 in FixedCharacterSet)
			{
				*(int*)pCurrData = charId3;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GraveSet != null)
		{
			int elementsCount4 = GraveSet.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			foreach (int charId4 in GraveSet)
			{
				*(int*)pCurrData = charId4;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TemplateEnemyList != null)
		{
			int elementsCount5 = TemplateEnemyList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int i = 0; i < elementsCount5; i++)
			{
				pCurrData += TemplateEnemyList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EnemyCharacterSet != null)
		{
			int elementsCount6 = EnemyCharacterSet.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			foreach (int charId5 in EnemyCharacterSet)
			{
				*(int*)pCurrData = charId5;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = Malice;
		pCurrData += 2;
		*pCurrData = (Destroyed ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += MaxResources.Serialize(pCurrData);
		pCurrData += CurrResources.Serialize(pCurrData);
		if (Items != null)
		{
			int elementsCount7 = Items.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			IList<ItemKeyAndDate> keys = Items.Keys;
			IList<int> values = Items.Values;
			for (int j = 0; j < elementsCount7; j++)
			{
				pCurrData += keys[j].Serialize(pCurrData);
				*(int*)pCurrData = values[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		BelongBlockId = *(short*)pCurrData;
		pCurrData += 2;
		RootBlockId = *(short*)pCurrData;
		pCurrData += 2;
		Visible = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharacterSet == null)
			{
				CharacterSet = IntHashSetPool.Get();
			}
			else
			{
				CharacterSet.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int charId = *(int*)pCurrData;
				pCurrData += 4;
				CharacterSet.Add(charId);
			}
		}
		else
		{
			CharacterSet?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (InfectedCharacterSet == null)
			{
				InfectedCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				InfectedCharacterSet.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int charId2 = *(int*)pCurrData;
				pCurrData += 4;
				InfectedCharacterSet.Add(charId2);
			}
		}
		else
		{
			InfectedCharacterSet?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FixedCharacterSet == null)
			{
				FixedCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				FixedCharacterSet.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int charId3 = *(int*)pCurrData;
				pCurrData += 4;
				FixedCharacterSet.Add(charId3);
			}
		}
		else
		{
			FixedCharacterSet?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (GraveSet == null)
			{
				GraveSet = IntHashSetPool.Get();
			}
			else
			{
				GraveSet.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				int charId4 = *(int*)pCurrData;
				pCurrData += 4;
				GraveSet.Add(charId4);
			}
		}
		else
		{
			GraveSet?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TemplateEnemyList == null)
			{
				TemplateEnemyList = RandomEnemyListPool.Get();
			}
			else
			{
				TemplateEnemyList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				MapTemplateEnemyInfo element = default(MapTemplateEnemyInfo);
				pCurrData += element.Deserialize(pCurrData);
				TemplateEnemyList.Add(element);
			}
		}
		else
		{
			TemplateEnemyList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (EnemyCharacterSet == null)
			{
				EnemyCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				EnemyCharacterSet.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				int charId5 = *(int*)pCurrData;
				pCurrData += 4;
				EnemyCharacterSet.Add(charId5);
			}
		}
		else
		{
			EnemyCharacterSet?.Clear();
		}
		Malice = *(short*)pCurrData;
		pCurrData += 2;
		Destroyed = *pCurrData != 0;
		pCurrData++;
		pCurrData += MaxResources.Deserialize(pCurrData);
		pCurrData += CurrResources.Deserialize(pCurrData);
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (Items == null)
			{
				Items = ItemCollectionPool.Get();
			}
			else
			{
				Items.Clear();
			}
			for (int num = 0; num < elementsCount7; num++)
			{
				ItemKeyAndDate itemKeyAndDate = default(ItemKeyAndDate);
				pCurrData += itemKeyAndDate.Deserialize(pCurrData);
				int amount = *(int*)pCurrData;
				pCurrData += 4;
				Items.Add(itemKeyAndDate, amount);
			}
		}
		else
		{
			Items?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public void MakeDestroyed(List<ItemKey> destroyedUniqueItems)
	{
		if (GetConfig().Size <= 1)
		{
			Destroyed = true;
			CurrResources.Initialize();
			DestroyItemsDirect(destroyedUniqueItems);
		}
	}

	public void StopDestroyedByInitResources(IRandomSource random)
	{
		Destroyed = false;
		InitResources(random);
	}

	public void StopDestroyedByRecover()
	{
		if (Destroyed && CurrResources.GetSum() >= MaxResources.GetSum() / 2)
		{
			Destroyed = false;
		}
	}

	public void AddCharacter(int charId)
	{
		if (CharacterSet == null)
		{
			CharacterSet = IntHashSetPool.Get();
		}
		CharacterSet.Add(charId);
	}

	public bool RemoveCharacter(int charId)
	{
		if (CharacterSet != null && CharacterSet.Remove(charId))
		{
			if (CharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(CharacterSet);
				CharacterSet = null;
			}
			return true;
		}
		return false;
	}

	public void AddInfectedCharacter(int charId)
	{
		if (InfectedCharacterSet == null)
		{
			InfectedCharacterSet = IntHashSetPool.Get();
		}
		InfectedCharacterSet.Add(charId);
	}

	public bool RemoveInfectedCharacter(int charId)
	{
		if (InfectedCharacterSet != null && InfectedCharacterSet.Remove(charId))
		{
			if (InfectedCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(InfectedCharacterSet);
				InfectedCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	public void AddFixedCharacter(int charId)
	{
		if (FixedCharacterSet == null)
		{
			FixedCharacterSet = IntHashSetPool.Get();
		}
		FixedCharacterSet.Add(charId);
	}

	public bool RemoveFixedCharacter(int charId)
	{
		if (FixedCharacterSet != null && FixedCharacterSet.Remove(charId))
		{
			if (FixedCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(FixedCharacterSet);
				FixedCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	public void AddEnemyCharacter(int charId)
	{
		if (EnemyCharacterSet == null)
		{
			EnemyCharacterSet = IntHashSetPool.Get();
		}
		EnemyCharacterSet.Add(charId);
	}

	public bool RemoveEnemyCharacter(int charId)
	{
		if (EnemyCharacterSet != null && EnemyCharacterSet.Remove(charId))
		{
			if (EnemyCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(EnemyCharacterSet);
				EnemyCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	public void AddGrave(int charId)
	{
		if (GraveSet == null)
		{
			GraveSet = IntHashSetPool.Get();
		}
		GraveSet.Add(charId);
	}

	public bool RemoveGrave(int charId)
	{
		if (GraveSet != null && GraveSet.Remove(charId))
		{
			if (GraveSet.Count <= 0)
			{
				IntHashSetPool.Return(GraveSet);
				GraveSet = null;
			}
			return true;
		}
		return false;
	}

	public bool AnyTemplateEnemy(short templateId)
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		foreach (MapTemplateEnemyInfo templateEnemy in TemplateEnemyList)
		{
			if (templateEnemy.TemplateId == templateId)
			{
				return true;
			}
		}
		return false;
	}

	public bool AnyTemplateEnemy(short templateIdMin, short templateIdMax)
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		foreach (MapTemplateEnemyInfo enemyInfo in TemplateEnemyList)
		{
			if (enemyInfo.TemplateId >= templateIdMin && enemyInfo.TemplateId <= templateIdMax)
			{
				return true;
			}
		}
		return false;
	}

	public void AddTemplateEnemy(MapTemplateEnemyInfo mapTemplateEnemyInfo)
	{
		if (TemplateEnemyList == null)
		{
			TemplateEnemyList = RandomEnemyListPool.Get();
		}
		TemplateEnemyList.Add(mapTemplateEnemyInfo);
	}

	public bool RemoveTemplateEnemy(MapTemplateEnemyInfo templateEnemyInfo)
	{
		if (TemplateEnemyList != null && TemplateEnemyList.Remove(templateEnemyInfo))
		{
			if (TemplateEnemyList.Count <= 0)
			{
				RandomEnemyListPool.Return(TemplateEnemyList);
				TemplateEnemyList = null;
			}
			return true;
		}
		return false;
	}

	public bool CountDown()
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		bool modified = false;
		int i = TemplateEnemyList.Count;
		while (i-- > 0)
		{
			if (TemplateEnemyList[i].Duration > 0)
			{
				MapTemplateEnemyInfo tmp = TemplateEnemyList[i];
				tmp.Duration--;
				if (tmp.Duration == 0)
				{
					TemplateEnemyList.RemoveAt(i);
				}
				else
				{
					TemplateEnemyList[i] = tmp;
				}
				modified = true;
			}
		}
		return modified;
	}

	public void AddItem(ItemKey itemKey, int amount)
	{
		if (Items == null)
		{
			Items = ItemCollectionPool.Get();
		}
		int currDate = ExternalDataBridge.Context.CurrDate;
		ItemKeyAndDate itemKeyAndDate = new ItemKeyAndDate(GetDestroyedDate(itemKey, currDate), itemKey);
		if (Items.TryGetValue(itemKeyAndDate, out var oriAmount))
		{
			Items[itemKeyAndDate] = oriAmount + amount;
		}
		else
		{
			Items.Add(itemKeyAndDate, amount);
		}
	}

	public void RemoveItem(ItemKeyAndDate itemKeyAndDate)
	{
		if (Items != null)
		{
			Items.Remove(itemKeyAndDate);
			if (Items.Count == 0)
			{
				ItemCollectionPool.Return(Items);
				Items = null;
			}
		}
	}

	public void RemoveItemByCount(ItemKeyAndDate itemKeyAndDate, int count)
	{
		if (Items[itemKeyAndDate] <= count)
		{
			RemoveItem(itemKeyAndDate);
		}
		else
		{
			Items[itemKeyAndDate] -= count;
		}
	}

	public void AddItems(List<(ItemKey itemKey, int amount)> items)
	{
		if (Items == null)
		{
			Items = ItemCollectionPool.Get();
		}
		int currDate = ExternalDataBridge.Context.CurrDate;
		int i = 0;
		for (int count = items.Count; i < count; i++)
		{
			(ItemKey itemKey, int amount) tuple = items[i];
			ItemKey itemKey = tuple.itemKey;
			int amount = tuple.amount;
			ItemKeyAndDate itemKeyAndDate = new ItemKeyAndDate(GetDestroyedDate(itemKey, currDate), itemKey);
			if (Items.TryGetValue(itemKeyAndDate, out var oriAmount))
			{
				Items[itemKeyAndDate] = oriAmount + amount;
			}
			else
			{
				Items.Add(itemKeyAndDate, amount);
			}
		}
	}

	private bool DestroyItemsByDate(int currDate, List<ItemKey> destroyedUniqueItems)
	{
		if (Items == null || Items.Count <= 0)
		{
			return false;
		}
		IList<ItemKeyAndDate> keys = Items.Keys;
		int itemCount = Items.Count;
		int lastIndexToBeRemoved = -1;
		for (int i = 0; i < itemCount && keys[i].Date <= currDate; i++)
		{
			lastIndexToBeRemoved = i;
		}
		if (lastIndexToBeRemoved < 0)
		{
			return false;
		}
		for (int j = 0; j <= lastIndexToBeRemoved; j++)
		{
			ItemKey itemKey = keys[j].ItemKey;
			if (!ItemTemplateHelper.IsPureStackable(itemKey))
			{
				destroyedUniqueItems.Add(itemKey);
			}
		}
		if (lastIndexToBeRemoved < itemCount - 1)
		{
			SortedList<ItemKeyAndDate, int> newItems = ItemCollectionPool.Get();
			IList<int> values = Items.Values;
			for (int k = lastIndexToBeRemoved + 1; k < itemCount; k++)
			{
				newItems.Add(keys[k], values[k]);
			}
			Items.Clear();
			ItemCollectionPool.Return(Items);
			Items = newItems;
		}
		else
		{
			Items.Clear();
			ItemCollectionPool.Return(Items);
			Items = null;
		}
		return true;
	}

	public bool DestroyItems(List<ItemKey> destroyedUniqueItems)
	{
		int currDate = ExternalDataBridge.Context.CurrDate;
		return DestroyItemsByDate(currDate, destroyedUniqueItems);
	}

	public bool DestroyItemsDirect(List<ItemKey> destroyedUniqueItems)
	{
		return DestroyItemsByDate(2147483646, destroyedUniqueItems);
	}

	public static int GetDestroyedDate(ItemKey itemKey, int date)
	{
		short preserveDuration = ItemTemplateHelper.GetPreservationDuration(itemKey.ItemType, itemKey.TemplateId);
		if (preserveDuration < 0)
		{
			return int.MaxValue;
		}
		return date + preserveDuration;
	}

	public MapBlockItem GetConfig()
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock()?.GetConfig();
		}
		return MapBlock.Instance[TemplateId];
	}

	public ResourceCollectionItem GetResourceCollectionConfig()
	{
		return ResourceCollection.Instance[GetConfig().ResourceCollectionType];
	}

	public Location GetLocation()
	{
		return new Location(AreaId, BlockId);
	}

	public ByteCoordinate GetBlockPos()
	{
		byte mapSize = ExternalDataBridge.Context.GetAreaSize(AreaId);
		return ByteCoordinate.IndexToCoordinate(BlockId, mapSize);
	}

	public bool IsCityTown()
	{
		if (BlockType != EMapBlockType.City && BlockType != EMapBlockType.Sect)
		{
			return BlockType == EMapBlockType.Town;
		}
		return true;
	}

	public bool IsVillage()
	{
		return BlockSubType == EMapBlockSubType.Village;
	}

	public bool IsTaiwuCun()
	{
		return BlockSubType == EMapBlockSubType.TaiwuCun;
	}

	public bool IsNonDeveloped()
	{
		EMapBlockType t = BlockType;
		if (t != EMapBlockType.Normal && t != EMapBlockType.Wild && t != EMapBlockType.Bad)
		{
			return t == EMapBlockType.scenery;
		}
		return true;
	}

	public bool IsPassable()
	{
		return MoveCost >= 0;
	}

	public bool CanBeFarmerMigrateTarget(sbyte resourceType)
	{
		if (IsPassable() && !Destroyed && IsSingleBlock)
		{
			return CurrResources[resourceType] >= GlobalConfig.Instance.VillagerRoleFarmerMigrateMinResource;
		}
		return false;
	}

	public bool CanChangeBlockType()
	{
		if (TemplateId != 126 && RootBlockId == -1)
		{
			return !IsCityTown();
		}
		return false;
	}

	public bool CanCollectResource(sbyte resourceType)
	{
		if (GetConfig().ResourceCollectionType >= 0)
		{
			return MaxResources[resourceType] > 0;
		}
		return false;
	}

	public short GetMaxMalice()
	{
		return GetConfig().MaxMalice;
	}

	public int GetAnimalBaseSpawnRate()
	{
		int sum = CurrResources.GetSum();
		int totalMaxRes = MaxResources.GetSum();
		return sum * 10 / totalMaxRes;
	}

	public MapBlockData GetRootBlock()
	{
		if (RootBlockId >= 0)
		{
			return ExternalDataBridge.Context.GetBlockData(new Location(AreaId, RootBlockId));
		}
		return this;
	}

	public byte GetManhattanDistanceToPos(byte x, byte y)
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock().GetManhattanDistanceToPos(x, y);
		}
		ByteCoordinate targetByteCoordinate = new ByteCoordinate(x, y);
		int minManhattan = GetBlockPos().GetManhattanDistance(targetByteCoordinate);
		Location location = new Location(AreaId, BlockId);
		IEnumerable<short> groupBlockIds = ExternalDataBridge.Context.GetGroupBlockIds(location, this);
		byte mapSize = ExternalDataBridge.Context.GetAreaSize(AreaId);
		foreach (short item in groupBlockIds)
		{
			int blockManhattan = ByteCoordinate.IndexToCoordinate(item, mapSize).GetManhattanDistance(targetByteCoordinate);
			if (blockManhattan < minManhattan)
			{
				minManhattan = blockManhattan;
			}
		}
		return (byte)minManhattan;
	}

	public byte GetManhattanDistanceToPosWithoutRoot(byte x, byte y)
	{
		ByteCoordinate targetByteCoordinate = new ByteCoordinate(x, y);
		return (byte)GetBlockPos().GetManhattanDistance(targetByteCoordinate);
	}

	public unsafe int GetCollectItemChance(sbyte resourceType)
	{
		if (MaxResources.Items[resourceType] <= 0)
		{
			return 0;
		}
		return CurrResources.Items[resourceType] * 100 / MaxResources.Items[resourceType] - 25;
	}

	public unsafe int GetCollectResourceAmount(sbyte resourceType)
	{
		return CurrResources.Items[resourceType] * GlobalConfig.Instance.CollectResourcePercent / 100 * GameData.Domains.World.SharedMethods.GetGainResourcePercent(2) / 100;
	}

	public int GetBlockIndexInBigBlock(byte areaSize)
	{
		MapBlockItem configData = GetConfig();
		if (configData != null && configData.Size > 1)
		{
			if (RootBlockId < 0)
			{
				if (configData.Size != 2)
				{
					return 6;
				}
				return 2;
			}
			int offset = BlockId - RootBlockId;
			if (configData.Size == 2)
			{
				if (offset != 1)
				{
					return (offset != areaSize) ? 1 : 0;
				}
				return 3;
			}
			switch (offset)
			{
			default:
				if (offset != areaSize)
				{
					if (offset != areaSize + 1)
					{
						if (offset != areaSize + 2)
						{
							if (offset != areaSize * 2)
							{
								if (offset != areaSize * 2 + 1)
								{
									return 2;
								}
								return 1;
							}
							return 0;
						}
						return 5;
					}
					return 4;
				}
				return 3;
			case 2:
				return 8;
			case 1:
				return 7;
			}
		}
		return -1;
	}

	public override string ToString()
	{
		return $"MapBlockData({AreaId},{BlockId})";
	}

	public unsafe void InitResources(IRandomSource random)
	{
		MapBlockItem configData = GetConfig();
		if (configData == null)
		{
			return;
		}
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			short maxResource = configData.Resources[resourceType];
			if (maxResource < 0)
			{
				maxResource = (short)(random.Next(Math.Abs(maxResource) / 2, Math.Abs(maxResource) + 1) * 5);
			}
			else if (maxResource != 0 && random.CheckPercentProb(50))
			{
				maxResource = (short)Math.Max(random.CheckPercentProb(35) ? (maxResource + random.Next(1, 6) * 5) : (maxResource - random.Next(1, 6) * 5), 0);
			}
			MaxResources.Items[resourceType] = maxResource;
			CurrResources.Items[resourceType] = (short)(maxResource * random.Next(50, 75) / 100 * GameData.Domains.World.SharedMethods.GetGainResourcePercent(0) / 100);
		}
	}

	public void ChangeTemplateId(short newPresetId, bool checkCanChange = true)
	{
		if (!checkCanChange || CanChangeBlockType())
		{
			TemplateId = newPresetId;
			return;
		}
		throw new Exception($"{BlockSubType} can not change PresetId!");
	}

	public void SetToSizeBlock(MapBlockData groupRoot)
	{
		if (groupRoot != null)
		{
			TemplateId = groupRoot.TemplateId;
			RootBlockId = groupRoot.BlockId;
			if (groupRoot.GroupBlockList == null)
			{
				groupRoot.GroupBlockList = new List<MapBlockData>();
			}
			if (!groupRoot.GroupBlockList.Contains(this))
			{
				groupRoot.GroupBlockList.Add(this);
			}
		}
	}

	public short GetCollectItemTemplateId(IRandomSource random, sbyte resourceType)
	{
		ResourceCollectionItem collectionConfig = GetResourceCollectionConfig();
		if (collectionConfig == null || collectionConfig.ItemIdList == null || !collectionConfig.ItemIdList.CheckIndex(resourceType))
		{
			return -1;
		}
		List<short> itemList = collectionConfig.ItemIdList[resourceType].DataList;
		if (resourceType == 5)
		{
			List<Config.ShortList> itemIdList = collectionConfig.ItemIdList;
			Config.ShortList poisons = itemIdList[itemIdList.Count - 1];
			if (poisons.DataList.Count > 0 && random.CheckPercentProb(40))
			{
				itemList = poisons.DataList;
			}
		}
		if (itemList.Count == 0)
		{
			return -1;
		}
		return itemList[random.Next(0, itemList.Count)];
	}

	public MapBlockData GetNearestBlockToTarget(ByteCoordinate pos)
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock().GetNearestBlockToTarget(pos);
		}
		MapBlockData target = this;
		int minManhattan = target.GetBlockPos().GetManhattanDistance(pos);
		if (GroupBlockList != null)
		{
			for (int i = 0; i < GroupBlockList.Count; i++)
			{
				MapBlockData block = GroupBlockList[i];
				int blockManhattan = block.GetBlockPos().GetManhattanDistance(pos);
				if (blockManhattan < minManhattan)
				{
					minManhattan = blockManhattan;
					target = block;
				}
			}
		}
		return target;
	}

	public int CalcFindTreasureChanceByItemsCount(sbyte luck, int itemsCount)
	{
		return itemsCount * (100 + luck * 3) / 100;
	}

	public int CalcFindTreasureChance(sbyte luck)
	{
		if (Items != null)
		{
			return CalcFindTreasureChanceByItemsCount(luck, Items.Count);
		}
		return 0;
	}
}
