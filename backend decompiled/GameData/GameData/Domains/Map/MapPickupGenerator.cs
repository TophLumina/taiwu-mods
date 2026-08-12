using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Map;

public class MapPickupGenerator
{
	private class GenerateRequest
	{
		public MapPickupsItem PickupConfig;

		public int XiangshuLevelIndex;
	}

	private const int BlockTypeCount = 4;

	private readonly EMapBlockType[] _mapBlockTypes = new EMapBlockType[4]
	{
		EMapBlockType.City,
		EMapBlockType.Sect,
		EMapBlockType.Town,
		EMapBlockType.Invalid
	};

	private static readonly Dictionary<short, HashSet<short>> _cachedConfigBlockSet = new Dictionary<short, HashSet<short>>();

	private static readonly Dictionary<sbyte, IList<int>> _cacheItemTypeToAllIdDict = new Dictionary<sbyte, IList<int>>();

	private static int BlockTypeToIndex(EMapBlockType blockType)
	{
		if (1 == 0)
		{
		}
		int result = blockType switch
		{
			EMapBlockType.City => 0, 
			EMapBlockType.Sect => 1, 
			EMapBlockType.Town => 2, 
			_ => 3, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public void Generate(IRandomSource random, Dictionary<Location, MapPickupCollection> outDict)
	{
		PreGenerate();
		outDict.Clear();
		Dictionary<int, Dictionary<sbyte, List<GenerateRequest>>> requestsByState = CollectRequestsByState();
		foreach (var (stateId, xiangshuLevelRequestDict) in requestsByState)
		{
			GeneratePerState(random, outDict, stateId, xiangshuLevelRequestDict);
		}
		Dictionary<short, List<GenerateRequest>> specialAreaRequestDict = CollectSpecialRequests();
		foreach (var (areaId, reqList) in specialAreaRequestDict)
		{
			GenerateForSpecialArea(random, areaId, reqList, outDict);
		}
		PostGenerate();
	}

	private void PreGenerate()
	{
		ClearCaches();
	}

	private void PostGenerate()
	{
		ClearCaches();
	}

	private void ClearCaches()
	{
		_cachedConfigBlockSet.Clear();
		_cacheItemTypeToAllIdDict.Clear();
	}

	private static Dictionary<int, Dictionary<sbyte, List<GenerateRequest>>> CollectRequestsByState()
	{
		Dictionary<int, Dictionary<sbyte, List<GenerateRequest>>> requestsByState = new Dictionary<int, Dictionary<sbyte, List<GenerateRequest>>>();
		foreach (MapPickupsItem pickupConfig in (IEnumerable<MapPickupsItem>)MapPickups.Instance)
		{
			if (pickupConfig.Type == EMapPickupsType.Event)
			{
				continue;
			}
			for (int stateIndex = 0; stateIndex < pickupConfig.StateTimes.Length; stateIndex++)
			{
				byte repeat = pickupConfig.StateTimes[stateIndex];
				if (repeat <= 0)
				{
					continue;
				}
				for (int levelIndex = 0; levelIndex < pickupConfig.XiangshuLevel.Length; levelIndex++)
				{
					sbyte level = pickupConfig.XiangshuLevel[levelIndex];
					if (!requestsByState.TryGetValue(stateIndex, out var levelDict))
					{
						levelDict = (requestsByState[stateIndex] = new Dictionary<sbyte, List<GenerateRequest>>());
					}
					if (!levelDict.TryGetValue(level, out var requestList))
					{
						requestList = (levelDict[level] = new List<GenerateRequest>());
					}
					for (int i = 0; i < repeat; i++)
					{
						requestList.Add(new GenerateRequest
						{
							PickupConfig = pickupConfig,
							XiangshuLevelIndex = levelIndex
						});
					}
				}
			}
		}
		return requestsByState;
	}

	private static Dictionary<short, List<GenerateRequest>> CollectSpecialRequests()
	{
		Dictionary<short, List<GenerateRequest>> result = new Dictionary<short, List<GenerateRequest>>();
		short[] targetAreas = new short[3] { 135, 137, 138 };
		short[] array = targetAreas;
		foreach (short areaId in array)
		{
			List<GenerateRequest> requestList = (result[areaId] = new List<GenerateRequest>());
			foreach (MapPickupsItem pickupConfig in (IEnumerable<MapPickupsItem>)MapPickups.Instance)
			{
				if (pickupConfig.Type == EMapPickupsType.Event)
				{
					continue;
				}
				byte repeat = pickupConfig.SpecialAreaTimes;
				if (repeat <= 0 || ((IEnumerable<sbyte>)pickupConfig.XiangshuLevel).Contains((sbyte)0))
				{
					for (int j = 0; j < repeat; j++)
					{
						requestList.Add(new GenerateRequest
						{
							PickupConfig = pickupConfig,
							XiangshuLevelIndex = 0
						});
					}
				}
			}
		}
		return result;
	}

	private void GeneratePerState(IRandomSource random, Dictionary<Location, MapPickupCollection> outDict, int stateId, Dictionary<sbyte, List<GenerateRequest>> xiangshuLevelRequestDict)
	{
		List<MapBlockData>[] areaBlocks = GetShuffledGroupedBlocksInState(random, stateId);
		Dictionary<EMapBlockType, int> areaTypeLoad = new Dictionary<EMapBlockType, int>();
		Dictionary<Location, int> locationLoad = new Dictionary<Location, int>();
		foreach (KeyValuePair<sbyte, List<GenerateRequest>> item in xiangshuLevelRequestDict)
		{
			List<GenerateRequest> reqList = item.Value;
			CollectionUtils.Shuffle(random, reqList);
			foreach (GenerateRequest req in reqList)
			{
				GeneratePerRequest(random, outDict, req, areaBlocks, areaTypeLoad, locationLoad);
			}
		}
	}

	private void GenerateForSpecialArea(IRandomSource random, short areaId, List<GenerateRequest> reqList, Dictionary<Location, MapPickupCollection> outDict)
	{
		List<MapBlockData> blockList = GetShuffledBlocksInArea(random, areaId);
		Dictionary<Location, int> locationLoad = new Dictionary<Location, int>();
		foreach (GenerateRequest req in reqList)
		{
			GeneratePerSpecialRequest(random, outDict, req, blockList, locationLoad);
		}
	}

	private void GeneratePerRequest(IRandomSource random, Dictionary<Location, MapPickupCollection> outDict, GenerateRequest req, List<MapBlockData>[] areaBlocks, Dictionary<EMapBlockType, int> areaLoad, Dictionary<Location, int> locationLoad)
	{
		MapPickupsItem config = req.PickupConfig;
		Dictionary<EMapBlockType, List<MapBlockData>> validAreaBlocks = GetValidAreaBlocks(areaBlocks, config);
		if (validAreaBlocks.Any())
		{
			EMapBlockType chosenAreaType = validAreaBlocks.Keys.OrderBy((EMapBlockType aid) => areaLoad.GetValueOrDefault(aid, 0)).First();
			List<MapBlockData> candidateBlocks = validAreaBlocks[chosenAreaType];
			MapBlockData chosenBlock = PickBlockByLoad(candidateBlocks, locationLoad, random);
			Location pickupLocation = chosenBlock.GetLocation();
			locationLoad[pickupLocation] = locationLoad.GetValueOrDefault(pickupLocation, 0) + 1;
			MapPickup pickup = GenerateOnePickup(config, req.XiangshuLevelIndex, random, needXiangshuMinion: true);
			pickup.Location = pickupLocation;
			AddPickupToResult(outDict, pickup);
			areaLoad.TryAdd(chosenAreaType, 0);
			areaLoad[chosenAreaType]++;
		}
	}

	private void GeneratePerSpecialRequest(IRandomSource random, Dictionary<Location, MapPickupCollection> outDict, GenerateRequest req, List<MapBlockData> blockList, Dictionary<Location, int> locationLoad)
	{
		MapPickupsItem config = req.PickupConfig;
		if (!_cachedConfigBlockSet.TryGetValue(config.TemplateId, out var blockSet))
		{
			blockSet = config.BlockList.ToHashSet();
		}
		MapBlockData chosenBlock = PickBlockByLoad(blockList.Where((MapBlockData b) => blockSet.Contains(b.TemplateId)).ToList(), locationLoad, random);
		if (chosenBlock != null)
		{
			Location pickupLocation = chosenBlock.GetLocation();
			locationLoad[pickupLocation] = locationLoad.GetValueOrDefault(pickupLocation, 0) + 1;
			MapPickup pickup = GenerateOnePickup(config, req.XiangshuLevelIndex, random, needXiangshuMinion: false);
			pickup.Location = pickupLocation;
			AddPickupToResult(outDict, pickup);
		}
	}

	private Dictionary<EMapBlockType, List<MapBlockData>> GetValidAreaBlocks(List<MapBlockData>[] areaBlocks, MapPickupsItem config)
	{
		if (!_cachedConfigBlockSet.TryGetValue(config.TemplateId, out var blockSet))
		{
			blockSet = config.BlockList.ToHashSet();
		}
		Dictionary<EMapBlockType, List<MapBlockData>> validAreaBlocks = new Dictionary<EMapBlockType, List<MapBlockData>>();
		for (int blockTypeIndex = 0; blockTypeIndex < 4; blockTypeIndex++)
		{
			EMapBlockType areaType = _mapBlockTypes[blockTypeIndex];
			List<MapBlockData> blocks = areaBlocks[blockTypeIndex];
			List<MapBlockData> validBlocks = new List<MapBlockData>();
			foreach (MapBlockData block in blocks)
			{
				if (blockSet.Contains(block.TemplateId))
				{
					validBlocks.Add(block);
				}
			}
			if (validBlocks.Any())
			{
				validAreaBlocks[areaType] = validBlocks;
			}
		}
		return validAreaBlocks;
	}

	private static List<MapBlockData>[] GetShuffledGroupedBlocksInState(IRandomSource random, int stateId)
	{
		List<MapBlockData>[] result = new List<MapBlockData>[4];
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = new List<MapBlockData>();
		}
		List<short> areaIdList = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllAreaInState((sbyte)stateId, areaIdList);
		foreach (short areaId in areaIdList)
		{
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
			MapAreaItem areaConfig = DomainManager.Map.GetAreaByAreaId(areaId).GetConfig();
			EMapBlockType areaType1 = GetAreaType(areaConfig);
			List<MapBlockData> blockList = result[BlockTypeToIndex(areaType1)];
			Span<MapBlockData> span = areaBlocks;
			for (int j = 0; j < span.Length; j++)
			{
				MapBlockData block = span[j];
				blockList.Add(block);
			}
		}
		List<MapBlockData>[] array = result;
		foreach (List<MapBlockData> blockList2 in array)
		{
			CollectionUtils.Shuffle(random, blockList2);
		}
		ObjectPool<List<short>>.Instance.Return(areaIdList);
		return result;
	}

	private static List<MapBlockData> GetShuffledBlocksInArea(IRandomSource random, short areaId)
	{
		List<MapBlockData> blockList = new List<MapBlockData>();
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			blockList.Add(block);
		}
		CollectionUtils.Shuffle(random, blockList);
		return blockList;
	}

	private static void AddPickupToResult(Dictionary<Location, MapPickupCollection> outDict, MapPickup pickup)
	{
		if (!outDict.TryGetValue(pickup.Location, out var pickupCollection))
		{
			pickupCollection = new MapPickupCollection();
			outDict.Add(pickup.Location, pickupCollection);
		}
		pickupCollection.AddPickup(pickup);
	}

	public static EMapBlockType GetAreaType(MapAreaItem areaConfig)
	{
		short[] settlementBlockCore = areaConfig.SettlementBlockCore;
		short[] array = settlementBlockCore;
		foreach (short blockId in array)
		{
			MapBlockItem blockConfig = MapBlock.Instance[blockId];
			switch (blockConfig.Type)
			{
			case EMapBlockType.City:
				return EMapBlockType.City;
			case EMapBlockType.Sect:
				return EMapBlockType.Sect;
			case EMapBlockType.Town:
				return EMapBlockType.Town;
			}
		}
		return EMapBlockType.Invalid;
	}

	private static MapPickup GenerateOnePickup(MapPickupsItem pickupConfig, int xiangshuLevelIndex, IRandomSource random, bool needXiangshuMinion)
	{
		Location location = Location.Invalid;
		sbyte xiangshuLevel = pickupConfig.XiangshuLevel[xiangshuLevelIndex];
		if (pickupConfig.Type == EMapPickupsType.Event)
		{
			throw new Exception("Event pickup type is invalid for disabled.");
		}
		bool hasXiangshuMinion = needXiangshuMinion && random.CheckPercentProb(GlobalConfig.Instance.MapPickupHasXiangshuMinionProbability);
		if (pickupConfig.BonusCount.Length != 0)
		{
			int baseBonusCount = pickupConfig.BonusCount[xiangshuLevelIndex];
			short randomFactor = GlobalConfig.Instance.MapPickupResourceCountRandomFactor;
			int min = baseBonusCount * (100 - randomFactor) / 100;
			int max = baseBonusCount * (100 + randomFactor) / 100;
			int bonusCount = random.Next(min, max);
			if (pickupConfig.IsExpBonus)
			{
				return MapPickup.CreateExpBonus(location, pickupConfig.TemplateId, bonusCount, xiangshuLevel, hasXiangshuMinion);
			}
			if (pickupConfig.IsDebtBonus)
			{
				return MapPickup.CreateDebtBonus(location, pickupConfig.TemplateId, bonusCount, xiangshuLevel, hasXiangshuMinion);
			}
			return MapPickup.CreateResource(location, pickupConfig.TemplateId, bonusCount, xiangshuLevel, hasXiangshuMinion);
		}
		if (pickupConfig.ItemGrade.Length != 0)
		{
			sbyte baseGrade = pickupConfig.ItemGrade[xiangshuLevelIndex];
			short itemId = RandomPickItemWithBaseGrade(random, pickupConfig, baseGrade);
			return MapPickup.CreateItem(location, pickupConfig.TemplateId, pickupConfig.ItemGroup.ItemType, itemId, xiangshuLevel, hasXiangshuMinion);
		}
		if (pickupConfig.LoopEffect)
		{
			return MapPickup.CreateLoopEffect(location, pickupConfig.TemplateId, xiangshuLevel, hasXiangshuMinion);
		}
		if (pickupConfig.ReadEffect)
		{
			return MapPickup.CreateReadEffect(location, pickupConfig.TemplateId, xiangshuLevel, hasXiangshuMinion);
		}
		throw new ArgumentException("Invalid pickup config");
	}

	private static short RandomPickItemWithBaseGrade(IRandomSource random, MapPickupsItem pickupConfig, sbyte baseGrade)
	{
		List<short> possibleIds = ObjectPool<List<short>>.Instance.Get();
		possibleIds.Clear();
		byte randomFactor = GlobalConfig.Instance.MapPickupItemGradeRandomFactor;
		sbyte itemType = pickupConfig.ItemGroup.ItemType;
		short groupId = pickupConfig.ItemGroup.TemplateId;
		if (!_cacheItemTypeToAllIdDict.TryGetValue(itemType, out var templateIds))
		{
			templateIds = ItemTemplateHelper.GetTemplateDataAllKeys(itemType);
			_cacheItemTypeToAllIdDict[itemType] = templateIds;
		}
		sbyte exceptedMinGrade = (sbyte)(baseGrade - randomFactor);
		sbyte exceptedMaxGrade = baseGrade;
		possibleIds.AddRange(from tid in templateIds
			where ItemTemplateHelper.GetGroupId(itemType, (short)tid) == groupId && ItemTemplateHelper.GetGrade(itemType, (short)tid) >= exceptedMinGrade && ItemTemplateHelper.GetGrade(itemType, (short)tid) <= exceptedMaxGrade
			select (short)tid);
		if (possibleIds.Count == 0)
		{
			throw new ArgumentException($"Invalid pickup config {pickupConfig.TemplateId} {pickupConfig.Name}. No item found in group {groupId} with grade between {exceptedMinGrade} and {exceptedMaxGrade}. itemType: {itemType}.");
		}
		int randomIndex = random.Next(0, possibleIds.Count);
		short itemId = possibleIds[randomIndex];
		ObjectPool<List<short>>.Instance.Return(possibleIds);
		return itemId;
	}

	private static MapBlockData PickBlockByLoad(IList<MapBlockData> sourceList, Dictionary<Location, int> locationLoad, IRandomSource random)
	{
		if (sourceList == null || sourceList.Count == 0)
		{
			return null;
		}
		int[] cumulativeWeights = new int[sourceList.Count];
		int totalWeight = 0;
		for (int i = 0; i < sourceList.Count; i++)
		{
			Location location = sourceList[i].GetLocation();
			int load = locationLoad.GetValueOrDefault(location, 0);
			int weight = 1 << 7 - Math.Min(load, 7);
			totalWeight = (cumulativeWeights[i] = totalWeight + weight);
		}
		int randomValue = random.Next(0, totalWeight);
		int index = Array.BinarySearch(cumulativeWeights, randomValue);
		if (index < 0)
		{
			index = ~index;
		}
		return sourceList[index];
	}
}
